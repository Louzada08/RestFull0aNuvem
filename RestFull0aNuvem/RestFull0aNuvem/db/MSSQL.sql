CREATE TABLE Portaria (
  idpk INTEGER  NOT NULL   IDENTITY ,
  titulo VARCHAR(100)  NOT NULL  ,
  descritivo LONGTEXT  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE origens (
  idpk INTEGER  NOT NULL   IDENTITY ,
  origens INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE ncmibpt (
  idpk INTEGER  NOT NULL   IDENTITY ,
  ncm INTEGER  NOT NULL  ,
  descricao VARCHAR(255)    ,
  extipi INTEGER    ,
  aliquotanacional DECIMAL(5,2)    ,
  aliquotaimportacao DECIMAL(5,2)    ,
  aliquotaestadual DECIMAL(5,2)    ,
  aliquotamunicipal DECIMAL(5,2)    ,
  uf CHAR(2)    ,
  iniciovigencia DATE    ,
  fimvigencia DATE    ,
  chave VARCHAR(100)    ,
  versao VARCHAR(100)      ,
PRIMARY KEY(idpk));
GO




CREATE TABLE usuario (
  idpk INTEGER  NOT NULL   IDENTITY ,
  Nome VARCHAR(100)  NOT NULL  ,
  login VARCHAR(100)  NOT NULL  ,
  senha VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE unidademedida (
  idpk INTEGER  NOT NULL   IDENTITY ,
  sigla CHAR(2)  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE uficms (
  idpk INTEGER  NOT NULL   IDENTITY ,
  sigla CHAR(2)    ,
  aliquotainter DECIMAL(5,2)    ,
  aliquotaintra DECIMAL(5,2)    ,
  aliquotafcp DECIMAL(5,2)      ,
PRIMARY KEY(idpk));
GO




CREATE TABLE cstpis (
  idpk INTEGER  NOT NULL   IDENTITY ,
  cst INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL  ,
  tipo INTEGER      ,
PRIMARY KEY(idpk));
GO





CREATE TABLE crt (
  idpk INTEGER  NOT NULL   IDENTITY ,
  crt INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE configuracao (
  idpk INTEGER  NOT NULL   IDENTITY ,
  tipoemissao VARCHAR(100)  NOT NULL  ,
  seriecertificado VARCHAR(100)  NOT NULL  ,
  ambiente INTEGER  NOT NULL  ,
  formaemissao INTEGER    ,
  modelo INTEGER  NOT NULL  ,
  serie CHAR(3)  NOT NULL  ,
  ultimanfe INTEGER  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE cfop (
  idpk INTEGER  NOT NULL   IDENTITY ,
  cfop INTEGER  NOT NULL  ,
  descricao VARCHAR(255)  NOT NULL  ,
  obs LONGTEXT    ,
  tipo INTEGER      ,
PRIMARY KEY(idpk));
GO





CREATE TABLE cstipi (
  idpk INTEGER  NOT NULL   IDENTITY ,
  cst INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL  ,
  tipo INTEGER      ,
PRIMARY KEY(idpk));
GO





CREATE TABLE csticms (
  idpk INTEGER  NOT NULL   IDENTITY ,
  cstcsosn INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(idpk));
GO




CREATE TABLE cstcofins (
  idpk INTEGER  NOT NULL   IDENTITY ,
  cst INTEGER  NOT NULL  ,
  descricao VARCHAR(100)  NOT NULL  ,
  tipo INTEGER      ,
PRIMARY KEY(idpk));
GO





