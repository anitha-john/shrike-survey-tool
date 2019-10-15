import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { Injectable, Inject } from '@angular/core';
// key that is used to access the data in local storageconst 

const STORAGE_KEY = 'survey-connect';

@Injectable()
export class LocalStorageService {

     constructor(@Inject(LOCAL_STORAGE) private storage: StorageService) { }
     public storeOnLocalStorage(token: string): void {
          
          // get array of tasks from local storage
          const currentTodoList = this.storage.get(STORAGE_KEY) || [];
          
          // insert updated array to local storage
          this.storage.set(STORAGE_KEY, token);
          console.log(this.storage.get(STORAGE_KEY) || 'LocaL storage is empty');
     }

     public getToken()
     {
         return this.storage.get(STORAGE_KEY) || 'LocaL storage is empty';
     }
}