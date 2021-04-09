import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchGiftsComponent } from './search-gifts/search-gifts.component';
import { GiftsTrendingComponent } from './gifts-trending/gifts-trending.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    GiftsTrendingComponent,
    SearchGiftsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: 'gifts-trending',
        component: GiftsTrendingComponent
      },
      {
        path: 'search-gifts',
        component: SearchGiftsComponent
      }, {
        path: '**',
        // redirectTo: 'gifts-trending',
        redirectTo: 'search-gifts',
        pathMatch: 'full'
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
