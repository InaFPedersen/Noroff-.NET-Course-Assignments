import { Component, OnInit } from "@angular/core";
import { TrainerService } from "src/app/services/trainer.service";
import { Pokemon, PokemonAPI, Trainer } from "../../models/trainer.model";
import { PokemonCatalogueService } from "../../services/pokemon-catalogue.service";

@Component({
	selector: "app-pokemon-page",
	templateUrl: "./pokemon-catalogue.page.html",
	styleUrls: ["./pokemon-catalogue.page.css"],
})
export class PokemonCataloguePage implements OnInit {
	constructor(
		private readonly pokemonCatalogeService: PokemonCatalogueService,
		private readonly trainerService: TrainerService
	) {}

	page = "catalogue";

	ngOnInit(): void {
		this.pokemonCatalogeService.findAllPokemons();
		// Eventlistener for checking if a pokemone is "caught"
		this.trainerService.pokemonCatchListner().subscribe(() => {
			this.updateTrainer();
		});
	}

	// Updates trainer with new list of pokemons
	public updateTrainer(): void {
		this.trainerService
			.updateTrainer(this.trainer?.id!, this.trainer?.pokemon!)
			.subscribe({
				next: (trainer: Trainer) => {
					this.trainerService.trainer = trainer;
				},
				error: () => {},
			});
	}

	get trainer(): Trainer | undefined {
		return this.trainerService.trainer;
	}

	get pokemonApiList(): PokemonAPI | undefined {
		return this.pokemonCatalogeService.pokemonApiList;
	}

	get listOfPokemons(): Pokemon[] {
		return this.pokemonCatalogeService.listOfPokemons;
	}

	get loading(): boolean {
		return this.pokemonCatalogeService.loading;
	}

	get error(): string {
		return this.pokemonCatalogeService.error;
	}
}
