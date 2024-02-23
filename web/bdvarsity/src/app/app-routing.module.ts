import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './portal/layouts/full/full.component';
import { BlankComponent } from './portal/layouts/blank/blank.component';
import { NotfoundComponent } from './404/not-found.component';

export const Approutes: Routes = [
  {
    path: '',
    component: BlankComponent,
    children: [
      {
        path: '',
        redirectTo: 'authentication',
        pathMatch: 'full'
      },
      {
        path: 'authentication',
        loadChildren:
          './authentication/authentication.module#AuthenticationModule'
      }
    ]
  },
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: 'portal',
        loadChildren: './portal/portal.module#PortalModule'
      },
      { path: '', redirectTo: '', pathMatch: 'full' }
    ]
  },
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: 'admin',
        loadChildren: './admin/admin.module#AdminModule'
      }
    ]
  },
  {
    path: '**',
    component: NotfoundComponent
  }
];
