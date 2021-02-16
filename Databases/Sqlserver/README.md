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
    "--name sqlserver" é o nome do container que definimos.

    "-p 1433:1433" é usado para mapear a porta 1433 do container para 1433 do _host_(máquina local).  

    "SA_PASSWORD=Password123* é a senha definida para o usuário SA (admin).

<br>


#### Consultar Container:
```
docker ps -a
```
Perceba que o container está parado, status = 'Exited'

<br>


#### Inicializar o Container:
```
docker start <container id>
```
O ID do container é identificado no passo anterior. 

<br>


#### Parar o Container:
```
docker stop <container id>
```

<br>
