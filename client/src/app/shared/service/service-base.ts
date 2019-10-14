import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from "@angular/common/http";


@Injectable()
export class ServiceBase {
    webApi:string="http://localhost:62339/api/v1"
    // webApi:string="http://srvcldgcrd003.fr.world.socgen:8100/API/api/v1"
    constructor(private http: HttpClient) {
    }

    get(query :string): any {
        const url=`${this.webApi}/${query}`
        return this
          .http
          .get(url);
          //.map((res: Response) => res.json());
      }

    post(data:any,query:string):any
    {
        const url=`${this.webApi}/${query}`
        return this
          .http
          .post(url,data,{ headers: this.getRequestHeaders()});
    }  

    put(data:any,query:string):any
    {
        const url=`${this.webApi}/${query}`
        return this
          .http
          .put(url,data,{ headers: this.getRequestHeaders()});
    }  
    
    private getRequestHeaders(): HttpHeaders {
      
        let header = new HttpHeaders()
        header.append('Content-Type', 'application/json');
        // header.append('Authorization', (document.querySelector('sgwt-connect') as any).sgwtConnect.getAuthorizationHeader());
        return header;
    }
}
