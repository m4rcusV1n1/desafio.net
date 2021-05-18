# Documentação da API

Api do desafio - Desenvolvida em .core versão 3.1
essa API conta com o método de autenticação via bearer token "JWT security"
todos os metodos adicionados possuem roles, ou seja somente usuário com aquela permissão pode acessar aquele determinado metodo.
A api possuem 3 metodos(GenerateToken - geração do token para acesso aos metodos, GetItems - lista todos os metodos de importação do txt, insertItems - importação dos dados do CNAB
Além disso a API conta com Swagger, fiz questão de adicionar pq fica bem documentada.
Usuário e senha para geração do token - "admin", "admin"

# Documentação Front End

Todo front end foi desenvolvido utilizando o html5, bootstrap e chamada via ajax.
Toda normalização de dados está sendo feito do lado do front end.
a inserção de dados é feita somente do lado da api. 

# Documentação Banco de dados

Aplicação foi desenvolvida com o maria Db mysql
Segue script de banco de dados

1- Tabela de importação do excel

CREATE TABLE `datadesafio` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`Tipo` INT(1) NOT NULL DEFAULT '0',
	`Data` DATETIME NOT NULL,
	`Valor` DECIMAL(20,6) NOT NULL DEFAULT '0.000000',
	`CPF` VARCHAR(11) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Cartao` VARCHAR(12) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Hora` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`DonoLoja` VARCHAR(14) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`NomeLoja` VARCHAR(19) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=716
;
2- tabela de usuário para geração do token.

CREATE TABLE `user` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Nome` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Login` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Password` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`Role` VARCHAR(50) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=2
;


INSERT INTO `desafionet`.`user` (`Nome`, `Login`, `Password`, `Role`) VALUES ('admin', 'admin', 'admin', 'administrador');
