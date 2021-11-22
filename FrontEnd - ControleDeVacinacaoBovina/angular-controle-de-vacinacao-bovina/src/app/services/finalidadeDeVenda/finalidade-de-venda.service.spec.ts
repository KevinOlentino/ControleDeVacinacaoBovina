import { TestBed } from '@angular/core/testing';

import { FinalidadeDeVendaService } from './finalidade-de-venda.service';

describe('FinalidadeDeVendaService', () => {
  let service: FinalidadeDeVendaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FinalidadeDeVendaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
