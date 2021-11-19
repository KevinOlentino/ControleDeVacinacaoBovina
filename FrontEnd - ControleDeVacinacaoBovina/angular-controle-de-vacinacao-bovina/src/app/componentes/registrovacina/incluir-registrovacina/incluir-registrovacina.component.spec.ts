import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncluirRegistrovacinaComponent } from './incluir-registrovacina.component';

describe('IncluirRegistrovacinaComponent', () => {
  let component: IncluirRegistrovacinaComponent;
  let fixture: ComponentFixture<IncluirRegistrovacinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IncluirRegistrovacinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IncluirRegistrovacinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
