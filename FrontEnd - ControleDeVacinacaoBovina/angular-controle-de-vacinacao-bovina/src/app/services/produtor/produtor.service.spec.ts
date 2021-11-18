/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProdutorService } from './produtor.service';

describe('Service: Produtor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProdutorService]
    });
  });

  it('should ...', inject([ProdutorService], (service: ProdutorService) => {
    expect(service).toBeTruthy();
  }));
});
