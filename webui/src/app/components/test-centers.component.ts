// src/app/components/test-centers/test-centers.component.ts

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestCenterService } from '../services/test-center.service';
import { BaseDevice, BaseProcess, Register, TestCenter } from '../models/test-center.model';

@Component({
  selector: 'app-test-centers',
  templateUrl: './test-centers.component.html',
  styleUrls: ['./test-centers.component.css']
})
export class TestCentersComponent implements OnInit {
  testCenters: TestCenter[] = []
  baseProcesses: BaseProcess[] = []


  constructor(private testCenterService: TestCenterService,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.testCenterService.getTestCenters().subscribe({
      next: (testCenters) => {
        this.testCenters = testCenters;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }
}
