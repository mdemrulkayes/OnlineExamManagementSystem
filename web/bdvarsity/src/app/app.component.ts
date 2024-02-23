import { Component, OnInit } from '@angular/core';
import { Router, Event as RouterEvent, NavigationStart, NavigationEnd,
   NavigationCancel, NavigationError } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _spinner: NgxSpinnerService, private _router: Router) {
    this._router.events.subscribe((event: RouterEvent) => {
      this.loaderOnNavigation(event);
    });
  }

  ngOnInit() {
  }

  loaderOnNavigation(event: RouterEvent) {
    if (event instanceof NavigationStart) {
      this._spinner.show();
    }

    if (event instanceof NavigationEnd || event instanceof NavigationCancel || event instanceof NavigationError) {
      this._spinner.hide();
    }
  }
}
