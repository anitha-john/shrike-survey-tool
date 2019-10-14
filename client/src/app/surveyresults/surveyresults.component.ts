import { Component, OnInit } from '@angular/core';
import { GridOptions } from 'ag-grid-community';
import { Router, ActivatedRoute } from '@angular/router';
import { SurveyService } from '../shared/service/survey-service';
import { resultsColumnDefs } from './surveyResultsColDef';

@Component({
  selector: 'app-surveyresults',
  templateUrl: './surveyresults.component.html',
  styleUrls: ['./surveyresults.component.scss']
})
export class SurveyresultsComponent implements OnInit {

  surveyName: any;
  gridOptions: GridOptions;
  surveyId: number;
  constructor( private router: Router,public surveyService:SurveyService,private route: ActivatedRoute)
  {
    this.gridOptions = new Object() as GridOptions;
    this.gridOptions.columnDefs = resultsColumnDefs;
    this.gridOptions.defaultColDef = {
      enableValue: true,
      enableRowGroup: true,
      enablePivot: true,
      sortable: true,
      filter: true,
      resizable:true
    };
    this.gridOptions.sideBar={
      toolPanels: [
        {
          id: "columns",
          labelDefault: "Columns",
          labelKey: "columns",
          iconKey: "columns",
          toolPanel: "agColumnsToolPanel"
        },
        {
          id: "filters",
          labelDefault: "Filters",
          labelKey: "filters",
          iconKey: "filter",
          toolPanel: "agFiltersToolPanel"
        }
      ]
    };
  }

 

  ngOnInit()
  {
    this.surveyId = this.route.snapshot.params['surveyId'];

    this.gridOptions.onGridReady = () => {
      this.gridOptions.api.showLoadingOverlay();
      this.getSurveyResults();
    }
  }

  getSurveyResults()
  {
    this.surveyService.GetSurveyResults(this.surveyId).subscribe((data:any)=>{
      this.surveyName=data.title;
      this.gridOptions.api.setRowData(data.surveyResults);    
              this.gridOptions.api.sizeColumnsToFit();
  
    },error=> this.gridOptions.api.showNoRowsOverlay());
  }

  



}
