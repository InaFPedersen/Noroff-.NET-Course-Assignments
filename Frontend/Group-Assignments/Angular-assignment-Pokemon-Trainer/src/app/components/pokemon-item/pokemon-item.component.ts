import { Component, Input } from "@angular/core";
import { TrainerService } from "src/app/services/trainer.service";
import { Pokemon, Trainer } from "../../models/trainer.model";

@Component({
	selector: "app-pokemon-item",
	templateUrl: "./pokemon-item.component.html",
	styleUrls: ["./pokemon-item.component.css"],
})
export class PokemonItemComponent {
	@Input() pokemon?: Pokemon;
	@Input() page: string = "";

	constructor(private readonly trainerService: TrainerService) {}

	// Checks if pokemon is already caught
	public ifCaught(): boolean {
		return !this.trainerService.trainer!.pokemon.some(
			(storedPokemon) =>
				storedPokemon.name === this.pokemon!.name &&
				storedPokemon.isCaught
		);
	}

	// Removes pokemon from trainers list of pokemons
	public onRelease(): void {
		this.pokemon!.isCaught! = false;
		this.trainerService.emitPokemonReleaseEvent(this.pokemon!);
	}

	// Add pokemon to trainers list of pokemons
	public onCatch(): void {
		if (this.ifCaught()) {
			this.pokemon!.isCaught = true;
			this.trainerService.trainer?.pokemon.push(this.pokemon!);
			this.trainerService.emitPokemonCatchEvent(this.pokemon!);
		}
	}

	// Changes picture to a different sprite if there is no official artwork
	public setDefaultPic(): void {
		this.pokemon!.image = `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/${
			this.pokemon!.id
		}.png`;
	}
}
