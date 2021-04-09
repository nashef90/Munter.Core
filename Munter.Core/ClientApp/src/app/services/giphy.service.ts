import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GiphyService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GiftsTrending() {
    return this.http.get<GiphyGiftsResponse>(this.baseUrl + 'api/Giphy/GiftsTrending');
  }
  SearchGifts(text: string) {
    return this.http.get<GiphyGiftsResponse>(this.baseUrl + `api/Giphy/SearchGifts/${encodeURIComponent(text)}`);
  }

}

export class GiphyGiftsResponse {
  data: Datum[];
}
export class Datum {
  type: string;
  id: string;
  url: string;
  slug: string;
  bitly_gif_url: string;
  bitly_url: string;
  embed_url: string;
  title: string;
  rating: string;
  is_sticker: number;
  import_datetime: string;
  trending_datetime: string;
  images: Images;
}
export class Images {
  original: Original;
  original_still: OriginalStill;
  original_mp4: OriginalMp4;
}
export abstract class ImageSize {
  height: string;
  width: string;
}
export class Original extends ImageSize {
  size: string;
  url: string;
  mp4_size: string;
  mp4: string;
  webp_size: string;
  webp: string;
  frames: string;
  hash: string;
}
export class OriginalStill extends ImageSize {
  size: string;
  url: string;
}
export class OriginalMp4 extends ImageSize {
  mp4_size: string;
  mp4: string;
}