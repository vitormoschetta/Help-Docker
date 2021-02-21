## Rodar BD MS Sql Server local com Docker


#### Baixar imagem:

```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```


<br>

#### Consultar imagem baixada:

```
docker images
```


<br>

####  Criar um Container a partir da Imagem:

```
docker create --name sqlserver -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass123*" mcr.microsoft.com/mssql/server:2019-latest
```


<br>

#### Criar e Executar Container a partir da Imagem:
```
docker run --name sqlserver  -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass123*" -d mcr.microsoft.com/mssql/server:2019-latest
```

Explicação dos parâmetros: 

```
"--name sqlserver" é o nome do container que definimos.

"-p 1433:1433" é usado para mapear a porta 1433 do container para 1433 do _host_(máquina local).  

"-e SA_PASSWORD=Pass123*" é a senha definida para o usuário SA (admin).

"-d mcr.microsoft.com/mssql/server:2019-latest" a imagem utilizada para criar o container.
```


<br>

Se tudo ocorreu como gostaríamos, você poderá acessar o Banco de Dados Sql Server através dos seguintes atributos:
```
Host: localhost
Port: 1433
User: sa
Password: Pass123*
``` 

Sua string de conexão ficaria parecido com isso:
```
"Server=localhost,1433;Database=database_name;user=sa;password=Pass123*"; 
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


<br>

Quando usamos o comando para Criar e Executar o container, ele já entra em execução. Quando usamos o comando apenas para criar o container, aí é necessário inicializá-lo com o comando "docker start ..."