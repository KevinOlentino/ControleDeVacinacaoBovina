/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RegistrovacinaService } from './registrovacina.service';

describe('Service: Registrovacina', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RegistrovacinaService]
    });
  });

  it('should ...', inject([RegistrovacinaService], (service: RegistrovacinaService) => {
    expect(service).toBeTruthy();
  }));
});
