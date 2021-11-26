use DbVacinacaoBovina

insert into Municipio(Nome, Estado) values('Campo Grande','MS')
insert into Municipio(Nome, Estado) values('�gua Clara','MS')
insert into Municipio(Nome, Estado) values('Alcin�polis','MS')
insert into Municipio(Nome, Estado) values('Coxim','MS')
insert into Municipio(Nome, Estado) values('Amambai','MS')
insert into Municipio(Nome, Estado) values('Anast�cio','MS')
insert into Municipio(Nome, Estado) values('Aquidauana','MS')
insert into Municipio(Nome, Estado) values('Nova Andradina','MS')
insert into Municipio(Nome, Estado) values('Ang�lica','MS')
insert into Municipio(Nome, Estado) values('Ant�nio Jo�o','MS')
insert into Municipio(Nome, Estado) values('Aparecida do Taboado','MS')
insert into Municipio(Nome, Estado) values('Aral Moreira','MS')
insert into Municipio(Nome, Estado) values('Bandeirantes','MS')
insert into Municipio(Nome, Estado) values('Bataguassu','MS')
insert into Municipio(Nome, Estado) values('Bataypor�','MS')
insert into Municipio(Nome, Estado) values('Bela Vista','MS')
insert into Municipio(Nome, Estado) values('Bodoquena','MS')
insert into Municipio(Nome, Estado) values('Bonito','MS')
insert into Municipio(Nome, Estado) values('Brasil�ndia','MS')
insert into Municipio(Nome, Estado) values('Caarap�','MS')
insert into Municipio(Nome, Estado) values('Camapu�','MS')
insert into Municipio(Nome, Estado) values('Caracol','MS')
insert into Municipio(Nome, Estado) values('Cassil�ndia','MS')
insert into Municipio(Nome, Estado) values('Corguinho','MS')
insert into Municipio(Nome, Estado) values('Coronel Sapucaia','MS')
insert into Municipio(Nome, Estado) values('Corumb�','MS')
insert into Municipio(Nome, Estado) values('Costa Rica','MS')
insert into Municipio(Nome, Estado) values('Coxim','MS')
insert into Municipio(Nome, Estado) values('Deod�polis','MS')
insert into Municipio(Nome, Estado) values('Dois Irm�os do Buriti','MS')
insert into Municipio(Nome, Estado) values('Douradina','MS')
insert into Municipio(Nome, Estado) values('Dourados','MS')
insert into Municipio(Nome, Estado) values('Eldorado','MS')
insert into Municipio(Nome, Estado) values('F�tima do Sul"','MS')
insert into Municipio(Nome, Estado) values('Figueir�o','MS')
insert into Municipio(Nome, Estado) values('Gl�ria de Dourados"','MS')
insert into Municipio(Nome, Estado) values('Guia Lopes da Laguna','MS')
insert into Municipio(Nome, Estado) values('Iguatemi','MS')
insert into Municipio(Nome, Estado) values('Inoc�ncia','MS')

insert into FinalidadeDeVenda(Nome) values ('Reprodu��o')
insert into FinalidadeDeVenda(Nome) values ('Engorda')
insert into FinalidadeDeVenda(Nome) values ('Trabalho')

insert into Especie(Nome) values('Bovino')
insert into Especie(Nome) values('Babulino')

insert into TipoDeEntrada(Nome) values('Compra')
insert into TipoDeEntrada(Nome) values('Doa��o')
insert into TipoDeEntrada(Nome) values('Nascimento')

insert into Vacina(Nome,Doenca,Tipo,Marca) values ('Brucelina','Brucelose','B19 - RB51','VALLE')
insert into Vacina(Nome,Doenca,Tipo,Marca) values ('Ourovac','Aftose','','Intervet')

insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Professor Arnaldo Jo�o Semeraro','538',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Jo�o Gapski','1593',2)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Magdalena Garcia Fonseca','1491',3)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Edit Piaf','1765',4)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua do Jubarte','566',5)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Travessa Di�gues J�nior','1094',6)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Jos� Garcia Cespedes','1893',7)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Passagem Dom Gel�sio','1282',7)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Paulo Soares de Ara�jo','355',7)

insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua do Feij�o','1988',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Ana Rita Ludick','534',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Travessa Maria da Concei��o','280',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Ceara','288',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rodovia Anel Rodovi�rio','s/n',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('BR 060 Km 401 Zona Rural Mais 6,5 Km Estrada Rural Zona Rural','2',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Silva Andrade','1988',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Passagem Isabel','813',1)
insert into Endereco(Rua,Numero,IdMunicipio) values ('Rua Jo�o de Macedo Ribeiro','999',1)

insert into Produtor(Nome,CPF,IdEndereco) values ('Joao Leite','70825267099',1)
insert into Produtor(Nome,CPF,IdEndereco) values ('Vit�ria Oliveira','57390333812',2)
insert into Produtor(Nome,CPF,IdEndereco) values ('Thiago Araujo Rocha','56697145714',3)
insert into Produtor(Nome,CPF,IdEndereco) values ('Alvaro Borba Junior','04042224040',4)
insert into Produtor(Nome,CPF,IdEndereco) values ('Laura Melo','10556192249',5)
insert into Produtor(Nome,CPF,IdEndereco) values ('Vinicius Cavalcanti Ribeiro','87071308055',6)
insert into Produtor(Nome,CPF,IdEndereco) values ('Matheus Neto','23456789010',7)
insert into Produtor(Nome,CPF,IdEndereco) values ('Kevin Ferreira ','08323292078',8)
insert into Produtor(Nome,CPF,IdEndereco) values ('Andrey Vaz de Caminha','53724102569',9)

insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('908085865','Fazenda Concei��o',10,1)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('948718725','Fazenda Fonseca',11,2)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('850737920','Fazenda Aparecida',12,3)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('425473856','Fazenda Melo',13,4)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('791794382','Fazenda Macedo',14,5)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('548530499','Fazenda Vitoria',15,6)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('962000785','Fazenda Gel�sio',16,7)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('553042921','Fazenda Cavalcanti',17,8)
insert into Propriedade(InscricaoEstadual,Nome,IdEndereco,IdProdutor) values ('763248084','Fazenda Feij�o',18,9)

insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (100,100,1,1)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (100,50,2,2)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (200,200,2,3)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (300,0,2,4)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (100,10,2,5)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (50,10,1,6)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (400,200,1,7)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (500,200,1,8)
insert into Rebanho(QuantidadeTotal,QuantidadeVacinada,idEspecie,idPropriedade) values (250,250,1,9)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,1,100,'2021-11-22','20211122 15:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,1,100,'2021-11-22','20211122 15:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,2,50,'2021-11-21','20211121 18:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,2,50,'2021-11-21','20211121 18:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,3,200,'2021-11-24','20211124 17:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,3,200,'2021-11-24','20211124 17:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,5,10,'2021-11-11','20211111 10:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,5,10,'2021-11-11','20211111 10:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,6,10,'2021-10-10','20211010 22:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,6,10,'2021-10-10','20211010 22:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,7,200,'2021-09-14','20210914 5:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,7,200,'2021-09-14','20210914 5:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,8,200,'2021-05-07','20210507 9:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,8,200,'2021-05-07','20210507 9:10:00.000',1)

insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (1,9,250,'2021-08-13','20210813 13:10:00.000',1)
insert into RegistroVacinacao(IdVacina,IdRebanho,Quantidade,DataDaVacina,DataDeCadastro,Ativo) values (2,9,250,'2021-08-13','20210813 13:10:00.000',1)

insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (100,100,1,1,2,1,'20211122 15:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (100,50, 2,1,2,2,'20211121 18:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (200,200,2,1,2,3,'20211124 17:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (300,0,  2,1,3,4,'20211125 7:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (100,10, 2,1,2,5,'20211111 10:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (50, 10, 1,1,3,6,'20211010 22:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (400,200,1,1,2,7,'20210914 5:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (500,200,1,1,3,8,'20210507 9:00:00.000')
insert into Animal(QuantidadeTotal, QuantidadeVacinada,IdEspecie, Ativo, IdTipoDeEntrada, IdPropriedade, DataDeEntrada) values (250,250,1,1,2,9,'20210813 13:00:00.000')

