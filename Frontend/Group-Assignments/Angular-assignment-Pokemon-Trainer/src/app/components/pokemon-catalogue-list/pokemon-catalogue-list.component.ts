import { Component, Input } from "@angular/core";
import { Pokemon } from "../../models/trainer.model";

@Component({
	selector: "app-pokemon-catalogue-list",
	templateUrl: "./pokemon-catalogue-list.component.html",
	styleUrls: ["./pokemon-catalogue-list.component.css"],
})
export class PokemonCatalogueListComponent {
	constructor() {}

	@Input() pokemons: Pokemon[] = [];

	page = "catalogue";
}
