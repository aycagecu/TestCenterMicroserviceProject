import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestCentersComponent } from './components/test-centers.component';
import { TestCenterService } from './services/test-center.service';


const routes: Routes = [
  {
    path: 'testcenters',
    component: TestCentersComponent
  },
  {
    path: 'testcentersservice',
    component: TestCenterService
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
