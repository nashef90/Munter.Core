import { Component, OnInit } from '@angular/core';
import { GiphyService } from '../services/giphy.service';


@Component({
  selector: 'app-gifts-trending',
  templateUrl: './gifts-trending.component.html',
  styleUrls: ['./gifts-trending.component.css']
})
export class GiftsTrendingComponent implements OnInit {
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

  ngOnInit() {
  }
}
interface Image {
  url: string;
  name: string;
}
