import { UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

export class SeguridadGuard {
  constructor(){}

  canActivate(): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }

}
