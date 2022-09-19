import { Component, Output, EventEmitter } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Trainer } from "src/app/models/trainer.model";
import { LoginTrainerService } from "src/app/services/login-trainer.service";
import { TrainerService } from "src/app/services/trainer.service";

@Component({
	selector: "app-login-trainer",
	templateUrl: "./login-trainer.component.html",
	styleUrls: ["./login-trainer.component.css"],
})
export class LoginTrainerComponent {
	@Output() login: EventEmitter<void> = new EventEmitter();

	constructor(
		private readonly logintrainerService: LoginTrainerService,
		private readonly trainerService: TrainerService
	) {}

	//This runs when the user clicks login in the login form
	public onSubmit(createLoginForm: NgForm): void {
		const { username } = createLoginForm.value;

		this.logintrainerService.login(username).subscribe({
			next: (trainer: Trainer) => {
				this.trainerService.trainer = trainer;
				this.login.emit();
			},
			error: () => {},
		});
	}
}
