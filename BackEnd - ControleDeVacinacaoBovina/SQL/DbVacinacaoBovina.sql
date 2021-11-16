create database VacinacaoBovina

go

use VacinacaoBovina

go 

create table Especie(
	IdEspecie int not null primary key identity(1,1),
	Nome varchar(30) not null
)

go

create table FinalidadeDeVenda(
	IdFinalidadeDeVenda int not null primary key identity(1,1),
	Nome varchar(30) not null
)

go

create table Vacina(
	IdVacina int not null primary key identity(1,1),
	Nome varchar(50) not null,
	Doenca varchar(50) not null,
	Tipo varchar(10) not null,
	Marca varchar(30) not null
)

go

create table Municipio(
	IdMunicipio int primary key identity(1,1) not null,
	Nome varchar(50) not null,
	Estado varchar(2) not null,
)

go

create table Endereco(
	IdEndereco int primary key identity(1,1) not null,
	Rua varchar(150) not null,
	Numero varchar(20) not null,
	Municipio int not null references Municipio(IdMunicipio)
)

go

create table Produtor(
	IdProdutor int primary key identity(1,1) not null,
	Nome varchar(50) not null,
	CPF varchar(11) not null,
	Endereco int not null references Endereco(IdEndereco)
)

go

create table Propriedade(
	IdPropriedade int primary key identity(1,1) not null,
	IncricaoEstadual varchar(10) not null,
	Nome varchar(50) not null,
	Endereco int not null references Endereco(IdEndereco),
	Produtor int not null references Produtor(IdProdutor)
)

go

create table Animal(
	IdAnimal int primary key identity(1,1),
	QuantidadeTotal int not null default(0),
	QuantidadeVacinada int not null default(0),
	IdEspecie int not null references Especie(IdEspecie),
	IdPropriedade int not null references Propriedade(IdPropriedade)
)

go

create table Venda(
	IdVenda int not null primary key identity(1,1),
	Quantidade int not null,
	IdOrigem int not null references Propriedade(IdPropriedade),
	IdDestino int not null references Propriedade(IdPropriedade),
	Especie int not null references Especie(IdEspecie),
	FinalidadeDeVenda int not null references FinalidadeDeVenda(IdFinalidadeDeVenda)
)

go

create table RegistroVacinacao(
	IdRegistroVacinacao int not null primary key identity(1,1),
	IdAnimal int not null references Animal(IdAnimal),
	IdVacina int not null references Vacina(IdVacina),
	Quantidade int not null,
	DataDaVacina date not null
)