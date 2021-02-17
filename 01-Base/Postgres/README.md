## Rodar BD PostgreSQL local com Docker

#### Baixar imagem:

```
docker pull postgres
```

<br>

#### Consultar imagem baixada:

```
docker images
```

<br>

#### Criar um Container a partir da Imagem:
```
docker run --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=Pass123* -d postgres
```

Explicação dos parâmetros: 

```
"--name postgres" é o nome do container que definimos.

"-p 5432:5432" é usado para mapear a porta 5432 do container para 5432 do _host_(máquina local).  

"-e POSTGRES_PASSWORD=Pass123*" é a senha definida para o usuário postgres (admin).

"-d postgres" a imagem utilizada para criar o container.
```


<br>

Se tudo ocorreu como gostaríamos, você poderá acessar o Banco de Dados Sql Server através dos seguintes atributos:
```
Host: localhost
Port: 5432
User: postgres
Password: Pass123*
``` 

Sua string de conexão ficaria parecido com isso:
```
"Host=localhost;Port=5432;Database=database_name;User ID=postgres;Password=Pass123*;" 
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

