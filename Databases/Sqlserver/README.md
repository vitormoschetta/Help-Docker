## Rodar BD SqlServer local com Docker

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

#### Criar um Container a partir da Imagem:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123*" -p 1433:1433 --name sqlserver -h sqlserver  -d mcr.microsoft.com/mssql/server:2019-latest
```

Explicação dos parâmetros: 

```
"--name sqlserver" é o nome do container que definimos.

"-p 1433:1433" é usado para mapear a porta 1433 do container para 1433 do _host_(máquina local).  

"SA_PASSWORD=Password123* é a senha definida para o usuário SA (admin).
```

<br>

Se tudo ocorreu como gostaríamos, você poderá acessar o Banco de Dados Sql Server através dos seguintes atributos:
```
Host: localhost
Port: 1433
User: sa
Password: Password123*
``` 


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

