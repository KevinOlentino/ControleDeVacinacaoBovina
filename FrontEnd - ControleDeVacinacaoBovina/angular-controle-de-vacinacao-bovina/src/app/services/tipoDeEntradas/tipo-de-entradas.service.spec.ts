import { TestBed } from '@angular/core/testing';

import { TipoDeEntradasService } from './tipo-de-entradas.service';

describe('TipoDeEntradasService', () => {
  let service: TipoDeEntradasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoDeEntradasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
