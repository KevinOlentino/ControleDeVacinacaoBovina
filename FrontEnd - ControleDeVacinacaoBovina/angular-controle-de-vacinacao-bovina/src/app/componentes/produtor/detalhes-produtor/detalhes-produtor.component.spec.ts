import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesProdutorComponent } from './detalhes-produtor.component';

describe('DetalhesProdutorComponent', () => {
  let component: DetalhesProdutorComponent;
  let fixture: ComponentFixture<DetalhesProdutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalhesProdutorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesProdutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
