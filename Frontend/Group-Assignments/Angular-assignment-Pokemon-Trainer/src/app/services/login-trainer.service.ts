import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable, of, switchMap } from "rxjs";
import { environment } from "src/environments/environment";
import { Trainer } from "../models/trainer.model";

const { apiTrainer, apiKey } = environment;

@Injectable({
	providedIn: "root",
})
export class LoginTrainerService {
	constructor(private readonly http: HttpClient) {}

	public login(username: string): Observable<Trainer> {
		return this.checkTrainerName(username).pipe(
			switchMap((trainer: Trainer | undefined) => {
				if (trainer === undefined) {
					return this.createTrainer(username);
				}
				return of(trainer);
			})
		);
	}
	//This checks if trainer name allready exist
	private checkTrainerName(
		username: string
	): Observable<Trainer | undefined> {
		return this.http
			.get<Trainer[]>(`${apiTrainer}?username=${username}`)
			.pipe(
				map((response: Trainer[]) => {
					return response.pop();
				})
			);
	}
	//This creates a new trainer if user name do not exist
	private createTrainer(username: string): Observable<Trainer> {
		const trainer = {
			username,
			pokemon: [],
		};

		let headers = new HttpHeaders({
			"Content-Type": "application/json",
			"X-API-Key": apiKey,
		});

		return this.http.post<Trainer>(apiTrainer, trainer, {
			headers,
		});
	}
}
