import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarPropriedadeComponent } from './editar-propriedade.component';

describe('EditarPropriedadeComponent', () => {
  let component: EditarPropriedadeComponent;
  let fixture: ComponentFixture<EditarPropriedadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarPropriedadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarPropriedadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
