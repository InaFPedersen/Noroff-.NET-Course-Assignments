import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatIconModule } from "@angular/material/icon";

import { AppComponent } from "./app.component";
import { LoginTrainerComponent } from "./components/login-trainer/login-trainer.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { LoginPage } from "./pages/login/login.page";
import { TrainerPage } from "./pages/trainer/trainer.page";
import { TrainerDetailsComponent } from "./components/trainer-details/trainer-details.component";
import { PokemonItemComponent } from "./components/pokemon-item/pokemon-item.component";
import { PokemonCataloguePage } from "./pages/pokemon-catalogue/pokemon-catalogue.page";
import { PokemonCatalogueListComponent } from "./components/pokemon-catalogue-list/pokemon-catalogue-list.component";
import { NavbarComponent } from "./components/navbar/navbar.component";

@NgModule({
	declarations: [
		AppComponent,
		LoginPage,
		LoginTrainerComponent,
		TrainerPage,
		TrainerDetailsComponent,
		PokemonItemComponent,
		PokemonCataloguePage,
		PokemonCatalogueListComponent,
		NavbarComponent,
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		FormsModule,
		MatPaginatorModule,
		BrowserAnimationsModule,
		MatIconModule,
	],
	providers: [],
	bootstrap: [AppComponent],
})
export class AppModule {}
