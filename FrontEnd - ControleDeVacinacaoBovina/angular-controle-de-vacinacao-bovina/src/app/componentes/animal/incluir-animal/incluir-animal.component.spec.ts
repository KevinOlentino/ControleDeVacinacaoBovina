import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncluirAnimalComponent } from './incluir-animal.component';

describe('IncluirAnimalComponent', () => {
  let component: IncluirAnimalComponent;
  let fixture: ComponentFixture<IncluirAnimalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IncluirAnimalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IncluirAnimalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
