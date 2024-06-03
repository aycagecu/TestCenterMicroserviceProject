import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestCentersComponent } from '../components/test-centers.component';

describe('TestCentersComponent', () => {
  let component: TestCentersComponent;
  let fixture: ComponentFixture<TestCentersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TestCentersComponent]
    });
    fixture = TestBed.createComponent(TestCentersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
