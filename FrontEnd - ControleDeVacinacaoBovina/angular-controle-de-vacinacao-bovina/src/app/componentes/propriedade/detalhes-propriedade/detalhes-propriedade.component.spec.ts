import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesPropriedadeComponent } from './detalhes-propriedade.component';

describe('DetalhesPropriedadeComponent', () => {
  let component: DetalhesPropriedadeComponent;
  let fixture: ComponentFixture<DetalhesPropriedadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalhesPropriedadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesPropriedadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
