/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PropriedadeComponent } from './propriedade.component';

describe('PropriedadeComponent', () => {
  let component: PropriedadeComponent;
  let fixture: ComponentFixture<PropriedadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropriedadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropriedadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
