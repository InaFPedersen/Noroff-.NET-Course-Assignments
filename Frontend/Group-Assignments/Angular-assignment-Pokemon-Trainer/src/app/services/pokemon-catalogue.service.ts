import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { finalize } from "rxjs";
import { environment } from "src/environments/environment";
import { StorageKeys } from "../enum/storage-key.enum";
import { Pokemon, PokemonAPI } from "../models/trainer.model";
import { StorageUtil } from "../Utils/storage.util";

const { apiPokemons, apiImage } = environment;

@Injectable({
	providedIn: "root",
})
export class PokemonCatalogueService {
	private _error: string = "";
	private _loading: boolean = false;

	private _pokemonAPIList?: PokemonAPI;
	private _listOfPokemons: Pokemon[] = [];

	// reading pokemonAPIList from localstorage
	constructor(private readonly http: HttpClient) {
		this._pokemonAPIList = StorageUtil.readStorage<PokemonAPI>(
			StorageKeys.PokeApi
		);
	}
	// storing pokemonAPIList from localstorage
	public set pokemonAPIList(pokemonAPIList: PokemonAPI | undefined) {
		StorageUtil.saveStorage<PokemonAPI>(
			StorageKeys.PokeApi,
			pokemonAPIList!
		);
		this._pokemonAPIList = pokemonAPIList;
		this.convertPokemonApiListToPokemonList();
	}

	// http request to get all pokemons
	public findAllPokemons(): void {
		this._loading = true;
		this.http
			.get<PokemonAPI>(apiPokemons)
			.pipe(
				finalize(() => {
					this._loading = false;
				})
			)
			.subscribe({
				next: (pokemonAPI: PokemonAPI) => {
					this._pokemonAPIList = pokemonAPI;
					this.convertPokemonApiListToPokemonList();
				},
				error: (error: HttpErrorResponse) => {
					this._error = error.message;
				},
			});
	}

	// converts pokemonApiList to a more useable pokemonList
	private convertPokemonApiListToPokemonList(): void {
		for (const pokemonItem of this._pokemonAPIList?.results ?? []) {
			const pokemonObject: Pokemon = {
				id: parseInt(pokemonItem.url.split("/").slice(-2, -1)[0]),
				name: pokemonItem.name,
				image: `${apiImage}${parseInt(
					pokemonItem.url.split("/").slice(-2, -1)[0]
				)}.png`,
				isCaught: false,
			};
			this._listOfPokemons.push(pokemonObject);
		}
	}

	get pokemonApiList(): PokemonAPI | undefined {
		return this._pokemonAPIList;
	}

	get listOfPokemons(): Pokemon[] {
		return this._listOfPokemons;
	}

	get error(): string {
		return this._error;
	}

	get loading(): boolean {
		return this._loading;
	}
}
