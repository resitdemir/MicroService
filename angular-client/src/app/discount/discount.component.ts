import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-discount',
  templateUrl: './discount.component.html',
  styleUrls: ['./discount.component.scss']
})
export class DiscountComponent implements OnInit {

  discount : any[] = [];
  private url: string = "http://localhost:5000/api/Discount";

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<string[]>(this.url).subscribe(data =>{
      this.discount = data["data"];
    })
  }

}
