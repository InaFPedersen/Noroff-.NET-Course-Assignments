import { Component, OnInit } from "@angular/core";
import { Pokemon, Trainer } from "src/app/models/trainer.model";
import { TrainerService } from "src/app/services/trainer.service";

@Component({
	selector: "app-trainer",
	templateUrl: "./trainer.page.html",
	styleUrls: ["./trainer.page.css"],
})
export class TrainerPage implements OnInit {
	constructor(private readonly trainerService: TrainerService) {}

	ngOnInit(): void {
		// eventlistener for checking if a pokemon is "released"
		this.trainerService.pokemonReleaseListner().subscribe((pokemon) => {
			this.updateTrainer();
		});
	}

	// Updates trainer with new pokemon list
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
}
