/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PropriedadeService } from './propriedade.service';

describe('Service: Propriedade', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PropriedadeService]
    });
  });

  it('should ...', inject([PropriedadeService], (service: PropriedadeService) => {
    expect(service).toBeTruthy();
  }));
});
