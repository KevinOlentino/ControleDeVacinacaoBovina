import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelarAnimalComponent } from './cancelar-animal.component';

describe('CancelarAnimalComponent', () => {
  let component: CancelarAnimalComponent;
  let fixture: ComponentFixture<CancelarAnimalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancelarAnimalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CancelarAnimalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
