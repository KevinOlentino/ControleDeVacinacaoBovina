import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelarRegistrovacinaComponent } from './cancelar-registrovacina.component';

describe('CancelarRegistrovacinaComponent', () => {
  let component: CancelarRegistrovacinaComponent;
  let fixture: ComponentFixture<CancelarRegistrovacinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancelarRegistrovacinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CancelarRegistrovacinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
