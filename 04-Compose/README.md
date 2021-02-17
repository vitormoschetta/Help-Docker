## Compose
Esta é uma ferramenta de linha de comando e formato de arquivo YAML com metadados para definir e executar aplicativos de vários contêineres. 

Você define um único aplicativo com base em várias imagens com um ou mais arquivos .yml que podem substituir valores dependendo do ambiente. 

Depois de criar as definições, você pode implantar todo o aplicativo de vários contêineres com um único comando (docker-compose up), que cria um contêiner por imagem no host do Docker.

<br>

## Missão
Queremos "subir" dois conteineres: de aplicação e de banco de dados, e fazẽ-los se comunicar. 

Vamos precisar dos seguintes serviços/itens:

1. Imagem do banco de dados (vamos usar o MS SQL Server)
2. Dockerfile para montar a imagem do site/app (vamos utilizar uma aplicação .NET Core)
3. Claro, o código fonte do App, pois é a partir dele que o Dockerfile será usado para montar a imagem do app.
4. O arquivo **docker-compose.yaml**

O docker-compose possui o seguinte conteúdo:

```
version: '3'

services:
  app:
    container_name: app
    image: netcoreapp
    build:
      context: .
    ports:
      - "5000:80"
    networks:
      - internal
    depends_on:
      - "db"

  db:
    container_name: sqlserver
    image: mcr.microsoft.com/mssql/server:2019-latest    
    ports:
      - "1433:1433"   
    environment:
      SA_PASSWORD: "Pass123*"
      ACCEPT_EULA: "Y"       
    networks:
      - internal

networks: 
    internal:
        driver: bridge
``` 

Perceba que o compose define dois serviços: app e db. 

Vamos explicar por partes:

#### Serviço app:

```
container_name: app
image: netcoreapp
```
Estamos informando que será criado um contêiner de nome "app" a partir da imagem "netcoreapp"


<br>

```
build:
    context: .
```
Informa que, se a imagem não existir, ela deve ser gerada a partir do arquivo Dockerfile que está localizado no mesmo diretório.


<br>

```
ports:
    - "2000:80"
```
Informa para o Docker mapear a porta 80 do conteiner para a porta 2000 do _host_.


<br>

```
networks:
    - internal
```
Informa que o serviço "db" estará na rede com o nome "internal" do Docker. 


<br>

```
depends_on:
      - "db"
```
Informa ao Docker que o serviço "app" depende do sucesso da implantação do serviço "db".



<br>

#### Serviço db:

```
container_name: sqlserver
image: mcr.microsoft.com/mssql/server:2019-latest  
```
Estamos informando que será criado um contêiner de nome "sqlserver" a partir da imagem "mcr.microsoft.com/mssql/server:2019-latest"

Obs: Sempre que tentamos criar um contêiner, o Docker verifica se a imagem existe localmente, caso contrário ela efetua o download da imagem no Doker Hub, se encontrada no repositório remoto.


<br>

```
ports:
    - "1433:1433"
```
Informa para o Docker mapear a porta 1433 do conteiner para a porta 1433 do _host_.



<br>

```
environment:
    SA_PASSWORD: "Pass123*"
    ACCEPT_EULA: "Y"  
```
Define a senha do usuário root do MS SQL Server ao instanciar o contêiner.


<br>

```
networks:
    - internal
```
Informa que o serviço "db", assim como o serviçoss "app", também estará na rede com o nome "internal" do Docker.



<br>

#### Network
Para que haja comunicação entre os conteiners (app e db/sqlserver) é preciso definir uma network/rede comum entre eles. Por isso ambos implementam a network "internal". 

No fim do arquivo docker-compose informamos a criação dessa rede:
```
networks: 
    internal:
        driver: bridge
```


<br>

### Executando o compose

Use o seguinte comando para startar o docker-compose:
``` 
docker-compose up -d
```
Obs: O console precisa estar no mesmo diretório do arquivo docker-compose.yaml.

<br>

O compose do Docker tratará de executar todos os processos que precisamos para subir ambos os containeres na mesma rede.

<br>

Se tudo ocorreu como esperávamos você poderá acessar a aplicação na seguinte url:

<http://localhost:5000/index.html>


