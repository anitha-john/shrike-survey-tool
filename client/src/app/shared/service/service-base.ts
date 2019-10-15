import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from "@angular/common/http";
import { LocalStorageService } from './localstorageService';


@Injectable()
export class ServiceBase {
    webApi:string="http://localhost:53293/api/v1"
    // webApi:string="http://srvcldgcrd003.fr.world.socgen:8100/API/api/v1"
    constructor(private http: HttpClient,private storage:LocalStorageService) {
    }

    get(query :string): any {
        const url=`${this.webApi}/${query}`
        return this
          .http
          .get(url,{ headers: this.getRequestHeaders()});
          //.map((res: Response) => res.json());
      }

    post(data:any,query:string):any
    {
        const url=`${this.webApi}/${query}`
        if(query === 'login')
        {
          return this
          .http
          .post(url,data);
        }
        else
        {
          return this
            .http
            .post(url,data,{ headers: this.getRequestHeaders()});
        }
    }  

    put(data:any,query:string):any
    {
        const url=`${this.webApi}/${query}`
        return this
          .http
          .put(url,data,{ headers: this.getRequestHeaders()});
    }  
    
    private getRequestHeaders(): HttpHeaders {
      debugger;
        let header = new HttpHeaders()
        header=header.append('Content-Type', 'application/json');
        header=header.append('Authorization', `Bearer ${this.storage.getToken()}`);
        return header;
    }
}
