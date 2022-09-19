import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./guard/auth.guard";
import { LoginPage } from "./pages/login/login.page";
import { PokemonCataloguePage } from "./pages/pokemon-catalogue/pokemon-catalogue.page";
import { TrainerPage } from "./pages/trainer/trainer.page";

const routes: Routes = [
	{
		path: "",
		pathMatch: "full",
		redirectTo: "/login",
	},
	{
		path: "login",
		component: LoginPage,
	},
	{
		path: "trainer",
		component: TrainerPage,
		canActivate: [AuthGuard],
	},
	{
		path: "catalogue",
		component: PokemonCataloguePage,
		canActivate: [AuthGuard],
	},
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
	providers: [],
})
export class AppRoutingModule {}
