export interface Trainer {
	id: number;
	username: string;
	pokemon: Pokemon[];
}

export interface Pokemon {
	id: number;
	name: string;
	image: string;
	isCaught: boolean;
}

export interface PokemonAPI {
	count: number;
	next: string;
	previous: null;
	results: CataloguePokemon[];
}

export interface CataloguePokemon {
	name: string;
	url: string;
}
