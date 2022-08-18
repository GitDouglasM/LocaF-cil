CREATE DATABASE LocadoraCarro;

CREATE TABLE Veiculos (
    id int identity(1,1) NOT NULL PRIMARY KEY,
    nome varchar(100) NOT NULL,
	cor varchar(50) NOT NULL,
	marca varchar(50) NOT NULL,
	anoFabricacao varchar(50) NOT NULL,
	numPortas int NOT NULL,
    tipoCombustivel varchar(50) NOT NULL,
	arCondicionado bit NULL,
	direcao bit NULL,
	freioAbs bit NULL,
	trava bit NULL,
	airbag bit NULL,	
	qtdLugar int NULL,
	vidro bit NULL,
	farolNeblina bit NULL,
	descricao varchar(1000) NULL,
    valor decimal(18,2) NOT NULL,
	situacao bit NOT NULL, 
	imagem varchar(1000) NOT NULL,
);
select * from Veiculos;
insert into Veiculos values('Uno', 'Preto', 'Fiat', '2019', 4, 'Gasolina', 1, 1, 1, 1, 1, 5, 1, 1, 'Semi-novo', 150.00, '', '');
insert into Veiculos values('Palio', 'Branco', 'Fiat', '2018', 4, 'Gasolina', 1, 1, 1, 1, 1, 5, 1, 1, 'Semi-novo', 150.00, '', '');


CREATE TABLE Clientes (
    id int identity(1,1) NOT NULL PRIMARY KEY,
    nome varchar(100) NOT NULL,
    cpf varchar(11) NOT NULL,
	rg varchar(7) NOT NULL,
	celular varchar(11) NOT NULL,
	logradouro varchar(200) NOT NULL,
    numero varchar(50) NOT NULL,
    complemento varchar(250) NULL,
    cep varchar(8) NOT NULL,
    bairro varchar(100) NOT NULL,
    cidade varchar(100) NOT NULL,
    estado varchar(50) NOT NULL,
);
select * from Clientes;
insert into Clientes values('Douglas', '70342025163', '6056203', '998026073', 'Rua Cariri', '12', 'Qd. 14', '76400000', 'Santana', 'Uruaçu', 'GO');
insert into Clientes values('Mariany', '06456801226', '5421489', '998026073', 'Av. B.', '778', 'Qd. 26', '77650000', 'Centro', 'Miracema', 'TO');



CREATE TABLE Reservas (
	id int identity(1,1) NOT NULL PRIMARY KEY,
	dataInicio DATETIME not null,
	dataFinal DATETIME not null,
	dinheiro bit NULL,
	cartao bit NULL,
	comentario varchar(1000) NULL,
	seguro bit NOT NULL,
	id_veiculo int NOT NULL,
	CONSTRAINT fk_veic_reserva FOREIGN KEY (id_veiculo) REFERENCES Veiculos(id),
	id_cliente int NOT NULL,
	CONSTRAINT fk_cli_reserva FOREIGN KEY (id_cliente) REFERENCES Clientes(id),
);

alter table Reservas
alter column cartao bit not null


insert into Reservas values ('01/06/2020', '06/06/2020', 1, 0, 'aaa', 1, 1, 1);
insert into Reservas values ('02/06/2020', '08/06/2020', 0, 1, 'bbb', 1, 2, 2);


select * from Reservas;



--tabela pra imagem
--tabela extra para veiculo
--adicionar campo para opinião do cliente após uso
--colocar binary