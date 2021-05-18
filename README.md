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