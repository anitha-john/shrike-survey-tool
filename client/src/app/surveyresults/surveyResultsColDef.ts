import { ColDef, GridOptions } from 'ag-grid-community';

import { DecimalPipe } from '@angular/common';
const defaultLocale = 'en-US';
const numberFilter = new DecimalPipe(defaultLocale);

export const resultsColumnDefs = [
    {
        field: 'questionDesc',
        headerName: 'Question',
        filter: 'agTextColumnFilter',
        width:160
    },
    {
        field: 'questionResponse',
        headerName: 'Response',
        filter: 'agTextColumnFilter',
        width:130
    },
    {
        field: 'givenBy',
        headerName: 'Given By User',
        filter: 'agTextColumnFilter',
        width:130
    }
    

] as ColDef[];

