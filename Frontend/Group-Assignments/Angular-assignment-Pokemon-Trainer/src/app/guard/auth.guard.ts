import { Injectable } from "@angular/core";
import {
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
	UrlTree,
	Router,
} from "@angular/router";
import { Observable } from "rxjs";
import { TrainerService } from "../services/trainer.service";
@Injectable({
	providedIn: "root",
})
export class AuthGuard implements CanActivate {
	constructor(
		private readonly router: Router,
		private readonly trainerService: TrainerService
	) {}

	canActivate(
		route: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	):
		| boolean
		| UrlTree
		| Observable<boolean | UrlTree>
		| Promise<boolean | UrlTree> {
		if (this.trainerService.trainer) {
			return true;
		} else {
			this.router.navigateByUrl("/login");
			return false;
		}
	}
}
