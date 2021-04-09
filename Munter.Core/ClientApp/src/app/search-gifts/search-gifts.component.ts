import { Component, OnInit } from '@angular/core';
import { GiphyService } from '../services/giphy.service';

@Component({
  selector: 'app-search-gifts',
  templateUrl: './search-gifts.component.html',
  styleUrls: ['./search-gifts.component.css']
})
export class SearchGiftsComponent implements OnInit {
  images: Image[] = [];

  constructor(private giphyService: GiphyService) {
    giphyService.GiftsTrending()
      .subscribe(result => {
        this.images = [];
        result.data.forEach(item => {
          this.images.push({
            url: item.images.original.url,
            name: item.title
          });
        });
      },
        error => {
          console.error(error);
          alert(error.message);
        });
  }
  onSearch(val: string) {
    if (val === "") {
      this.giphyService.GiftsTrending()
        .subscribe(result => {
          console.log("Result: ", result);
          this.images = [];
          result.data.forEach(item => {
            this.images.push({
              url: item.images.original.url,
              name: item.title
            });
          });
        },
          error => {
            console.error(error);
            alert(error.message);
          });
    } else {
      this.giphyService.SearchGifts(val)
        .subscribe(result => {
          console.log("Result: ", result);
          this.images = [];
          result.data.forEach(item => {
            this.images.push({
              url: item.images.original.url,
              name: item.title
            });
          });
        },
          error => {
            console.error(error);
            alert(error.message);
          });
    }
  }

  ngOnInit() {
  }

}
interface Image {
  url: string;
  name: string;
}
