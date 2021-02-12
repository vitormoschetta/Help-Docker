# Rodar BD Postgres local com Docker

#### Baixar imagem:

```
docker pull postgres
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
docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres
```
> -p 5432:5432 --> é usado para mapear a porta do docker para o _host_(externo ao docker)  
> POSTGRES_PASSWORD=1234  --> definir a senha 

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