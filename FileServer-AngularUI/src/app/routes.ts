import {Routes} from '@angular/router';
import {AuthGuard} from './_guards/auth.guard';
import {HomeComponent} from './home/home.component';
import {FileServerComponent} from './file-server/file-server.component';


export const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'file-server', component: FileServerComponent},
    ]
  },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];
