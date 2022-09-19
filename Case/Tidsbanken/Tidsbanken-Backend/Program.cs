using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Tidsbanken_Backend.Controllers;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(ManagementAccess));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    OpenApiSecurityScheme securitySchema = new()
	{
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securitySchema);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    });

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tidsbanken v1",
        Version = "v1",
        Description = "ASP.NET Core Web API for Tidsbanken Webapp",
        Contact = new OpenApiContact
        {
            Name = "Ina F. Pedersen & Sigurd Riis Haugen & Sondre Nygrd & Mikael Bjerga",
            Email = String.Empty,
        }
    });
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);


});

// Setup authentication
ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
       builder =>
       {
           builder.WithOrigins("https://tidsbankenappfront.azurewebsites.net/", "http://localhost:3000")
                  .WithHeaders("Authorization", "content-type")
                  .AllowAnyMethod();
       });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
    options.Audience = Configuration["Auth0:Audience"];

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                (c.Type == "permissions" &&
                c.Value == "read:messages") &&
                c.Issuer == $"https://{Configuration["Auth0:Domain"]}/")));
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<TidsbankenDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
