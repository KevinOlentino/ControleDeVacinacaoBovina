import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelarVendaComponent } from './cancelar-venda.component';

describe('CancelarVendaComponent', () => {
  let component: CancelarVendaComponent;
  let fixture: ComponentFixture<CancelarVendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancelarVendaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CancelarVendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
