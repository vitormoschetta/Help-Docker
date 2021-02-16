# Rodar BD SqlServer local com Docker

#### Baixar imagem:

```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```

<br>
<br>

#### Consultar imagem baixada:

```
docker images
```

<br>
<br>

#### Criar um Container a partir da Imagem:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Brasil2021*" -p 1433:1433 --name sqlserver -h sqlserver  -d mcr.microsoft.com/mssql/server:2019-latest
```
> -p 1433:1433 --> é usado para mapear a porta do docker para o _host_(externo ao docker)  

> SA_PASSWORD=Brasil2021* --> definir a senha 

<br>
<br>

#### Consultar Container:
```
docker ps -a
```
> Perceba que o container está parado, status = 'Exited'

<br>
<br>


#### Inicializar o Container:
```
docker start <container id>
```
> O ID do container é identificado no passo anterior. 

<br>
<br>


#### Parar o Container:
```
docker stop <container id>
```

<br>
<br>