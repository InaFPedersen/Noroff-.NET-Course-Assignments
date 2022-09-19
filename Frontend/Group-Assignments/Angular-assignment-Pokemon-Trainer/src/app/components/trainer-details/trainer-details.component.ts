import { Component, Input } from "@angular/core";
import { Trainer } from "../../models/trainer.model";

@Component({
	selector: "app-trainer-details",
	templateUrl: "./trainer-details.component.html",
	styleUrls: ["./trainer-details.component.css"],
})
export class TrainerDetailsComponent {
	@Input() trainer?: Trainer;

	constructor() {}

	page = "trainer";
}
