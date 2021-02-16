## Rodar BD PostgreSQL local com Docker

#### Baixar imagem:

```
docker pull mysql
```

<br>

#### Consultar imagem baixada:

```
docker images
```

<br>

#### Criar um Container a partir da Imagem:
```
docker run --name mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=Pass123* -d mysql
```

Explicação dos parâmetros: 

```
"--name mysql" é o nome do container que definimos.

"-p 3306:3306" é usado para mapear a porta 3306 do container para 3306 do _host_(máquina local).  

"-e MYSQL_ROOT_PASSWORD=Pass123*" é a senha definida para o usuário root (admin).

"-d mysql" a imagem utilizada para criar o container.
```


<br>

Se tudo ocorreu como gostaríamos, você poderá acessar o Banco de Dados Sql Server através dos seguintes atributos:
```
Host: localhost
Port: 3306
User: root
Password: Pass123*
``` 

Sua string de conexão ficaria parecido com isso:
```
"Server=localhost;Port=3306;Database=database_name;Uid=root;Pwd=Pass123*;" 
```
Obs: "localhost" pode ser substituído pelo IP da máquina.



<br>
<br>



## Outros comandos úteis para esta seção:


#### Consultar Containers em execução:
```
docker ps 
```

<br>

#### Consultar Containers parados:
```
docker ps -a
```

<br>

#### Inicializar Container:
```
docker start <container_id or container_name>
```

<br>


#### Parar o Container:
```
docker stop <container_id or container_name>
```

