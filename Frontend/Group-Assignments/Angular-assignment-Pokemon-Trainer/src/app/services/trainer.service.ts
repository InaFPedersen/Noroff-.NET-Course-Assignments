import { Injectable } from "@angular/core";
import {
	HttpClient,
	HttpErrorResponse,
	HttpHeaders,
} from "@angular/common/http";
import { Trainer, Pokemon } from "../models/trainer.model";
import { environment } from "src/environments/environment";
import { BehaviorSubject, Observable } from "rxjs";
import { StorageUtil } from "../Utils/storage.util";
import { StorageKeys } from "../enum/storage-key.enum";

const { apiTrainer, apiKey } = environment;

@Injectable({
	providedIn: "root",
})
export class TrainerService {
	private _error: string = "";
	private _trainer?: Trainer;
	private _pokemonReleaseClicked = new BehaviorSubject<Pokemon | undefined>(
		undefined
	);
	private _pokemonCatchClicked = new BehaviorSubject<Pokemon | undefined>(
		undefined
	);

	// storing and reading trainer from localstorage
	constructor(private readonly http: HttpClient) {
		this._trainer = StorageUtil.readStorage<Trainer>(StorageKeys.Trainer);
	}

	public set trainer(trainer: Trainer | undefined) {
		StorageUtil.saveStorage<Trainer>(StorageKeys.Trainer, trainer!);
		this._trainer = trainer;
	}

	// http patch request to update trainer
	public updateTrainer(
		userId: number,
		pokemons: Pokemon[]
	): Observable<Trainer> {
		let headers = new HttpHeaders({
			"Content-Type": "application/json",
			"X-API-Key": apiKey,
		});

		let body = {
			pokemon: pokemons,
		};

		return this.http.patch<Trainer>(`${apiTrainer}/${userId}`, body, {
			headers: headers,
		});
	}

	public get trainer(): Trainer | undefined {
		return this._trainer;
	}

	public error(): string {
		return this._error;
	}

	emitPokemonReleaseEvent(pokemon: Pokemon) {
		this._pokemonReleaseClicked.next(pokemon);
	}

	emitPokemonCatchEvent(pokemon: Pokemon) {
		this._pokemonCatchClicked.next(pokemon);
	}

	pokemonReleaseListner() {
		return this._pokemonReleaseClicked.asObservable();
	}

	pokemonCatchListner() {
		return this._pokemonCatchClicked.asObservable();
	}
}
