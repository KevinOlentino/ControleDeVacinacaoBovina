import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncluirPropriedadeComponent } from './incluir-propriedade.component';

describe('IncluirPropriedadeComponent', () => {
  let component: IncluirPropriedadeComponent;
  let fixture: ComponentFixture<IncluirPropriedadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IncluirPropriedadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IncluirPropriedadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
