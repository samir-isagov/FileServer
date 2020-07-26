import {Routes} from '@angular/router';
import {AppComponent} from './app.component';
import {AuthGuard} from './_guards/auth.guard';


export const appRoutes: Routes = [
  {path: '', component: AppComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
    ]
  },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];
