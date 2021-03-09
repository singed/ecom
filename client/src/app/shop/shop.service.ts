import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {IPagination} from "../shared/models/pagination";
import {IBrand} from "../shared/models/brand";
import {IType} from "../shared/models/productType";
import {map} from "rxjs/operators";
import {ShopParams} from "../shared/models/shopParams";
import {IProduct} from "../shared/models/product";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  shopParams = new ShopParams();
  constructor(private http: HttpClient) {
  }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId) {
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.sort) {
      params = params.append('sort', shopParams.sort);
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getProduct(id:number){
    return this.http.get<IProduct>(this.baseUrl + 'products/' +id);
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

  getShopParams(){
    return this.shopParams;
  }
  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }
}
