using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Domain;
#nullable disable
namespace Tidsbanken_Backend.Models.Data
{
    public class TidsbankenDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<VacationStatus> VacationStatuses { get; set; }
        public DbSet<IneligiblePeriod> IneligiblePeriods { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public TidsbankenDbContext(DbContextOptions options) : base(options)
        {

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add data to the database for testing purposes.
            User testUser1 = new User()
            {
                Id = "1",
                ProfilePicture = "https://bobleesays.com/wp-content/uploads/2012/07/beautiful-tuxedo-cat-wide-high-resolution-wallpaper-for-desktop-background-download-tuxedo-cat-images-free-300x240.jpg",
                IsAdmin = true,
                Email = "Sindre@test.no",
                FirstName = "Sindre",
                LastName = "Nygård",
                PhoneNumber = 98765434
            };
            User testUser2 = new User() 
            { 
                Id = "2", 
                ProfilePicture = "https://torange.biz/photofxnew/66/HD/very-vivid-colours-fragment-view-cat-66325.jpg", 
                IsAdmin = false, 
                Email = "Signe@test.no", 
                FirstName = "Signe", 
                LastName = "Nygård",
                PhoneNumber = 98765433 
            };

            User testUser3 = new User() 
            { 
                Id = "3", 
                ProfilePicture = "https://mcdn.wallpapersafari.com/medium/36/8/RmU0Au.jpg", 
                IsAdmin = false, 
                Email = "Sondre@test.no", 
                FirstName = "Sondre", 
                LastName = "Nygård", 
                PhoneNumber = 98765432 
            };
            
            User AdminTestUser = new User()
            {
                Id = "KdsQcW5Vb575sLEfIaX3mR01HKDTEqbg@clients",
                ProfilePicture = "https://bobleesays.com/wp-content/uploads/2012/07/beautiful-tuxedo-cat-wide-high-resolution-wallpaper-for-desktop-background-download-tuxedo-cat-images-free-300x240.jpg",
                IsAdmin = true,
                Email = "Admin@test.no",
                FirstName = "Test",
                LastName = "Admin",
                PhoneNumber = 98765434
            };
            
            VacationStatus status1 = new VacationStatus() { Id = 1, Status = "Rejected" };
            VacationStatus status2 = new VacationStatus() { Id = 2, Status = "Pending" };
            VacationStatus status3 = new VacationStatus() { Id = 3, Status = "Approved" };
            IneligiblePeriod ineligible1 = new IneligiblePeriod() 
            { 
                Id = 1, 
                Title = "Forbidden! No cats will rest on this day.", 
                EndDate = new DateTime(2022, 3, 10), 
                StartDate = new DateTime(2022, 3, 10),
                UserId = "1",
            };

            modelBuilder.Entity<VacationRequest>(
                entity =>
                {
                    entity.HasOne(d => d.User)
                    .WithMany(p => p.VacationRequests)
                    .HasForeignKey("UserId");
                });
            modelBuilder.Entity<Comment>(
                entity =>
                {
                    entity.HasOne(d => d.VacationRequest)
                    .WithMany(p => p.Comments)
                    .HasForeignKey("VacationRequestId");
            
                    entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comments)
                    .HasForeignKey("AuthorId");
                });
            modelBuilder.Entity<User>().HasData(testUser1, testUser2, testUser3, AdminTestUser);



            VacationRequest request1 = new VacationRequest() { UserId = "1", VacationStatusId = 1, Id = 1, Title = "two days off coz im a cat", StartDate = new DateTime(2022, 3, 15), EndDate = new DateTime(2022, 3, 17) };
            VacationRequest request2 = new VacationRequest() { UserId = "2", VacationStatusId = 2, Id = 2, Title = "Christmas 4 cats", StartDate = new DateTime(2022, 12, 24), EndDate = new DateTime(2022, 12, 25) };
            VacationRequest request3 = new VacationRequest() { UserId = "3", VacationStatusId = 3, Id = 3, Title = "cat time (for cat)", StartDate = new DateTime(2022, 8, 2), EndDate = new DateTime(2023, 2, 15) };

            Comment comment1 = new Comment() { Id = 1, AuthorId = "1", VacationRequestId = 2, Message = "hey man ur a cool cat >:)", LastTimeEdited = null, CreationDate = new DateTime(2022, 3, 16)};
            
            modelBuilder.Entity<VacationRequest>().HasData(request1, request2, request3);
            modelBuilder.Entity<VacationStatus>().HasData(status1, status2, status3);
            modelBuilder.Entity<Comment>().HasData(comment1);
            modelBuilder.Entity<IneligiblePeriod>().HasData(ineligible1);
        }
    }
}
#nullable enable