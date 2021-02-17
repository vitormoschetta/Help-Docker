## Rede de conteineres

Os contêineres, por padrão, são executados isoladamente e não sabem nada sobre outros processos ou contêineres na mesma máquina. Então, como permitimos que um contêiner converse com outro? A resposta é **networking**.


<br>

#### Criar a network / rede
```
docker network create internal

```
É através do network que faremos os conteineres se comunicar. Se ambos estiverem vinculados à mesma rede eles podem fazer referência ao outro usando o ip da rede "internal" ou simplesmente o nome do conteiner. 


<br>

Bom, agora precisamos fazer o que já sabemos: 

1. Ter o código fonte do App.
2. Criar um Dockerfile parar gerar a imagem do App.
3. Executar o comando que gera a imagem do App a partir do Dockerfile.
4. Instanciar um conteiner App a partir da imagem App.
5. Instanciar um conteiner de banco de dados a partir de uma "imagem base" oficial.

<br>

#### Gerar a imagem do App:
Já temos o Dockerfile na pasta do App e o código fonte no subdiretório "src".  
Só precisamos agora executar o comando para gerar a imagem:  
```
docker build -t netcoreapp .
```


<br>

#### Instanciar o container App
Vamos utilizar o seguinte comando para instanciar o conteiner a partir da imagem criada anteriormente:
``` 
docker run -d -p 5000:80 --name app --network internal -d netcoreapp 
```
Observe que entre os parâmetros a única coisa que não vimos até aqui é o "--network internal".   
Este é o nome da rede em que o conteiner estará vinculado.


<br>

#### Instanciar o container Db  
Vamos utilizar o comando abaixo para instanciar um banco de dados MS SQL Server a partir da "imagem base" oficial:
```
docker run -e "ACCEPT_EULA=Y" \
--name sqlserver \
-p 1433:1433 \
-e "SA_PASSWORD=Pass123*" \
--network internal \
-d mcr.microsoft.com/mssql/server:2019-latest 
```
Novamente, observer que a única coisa diferente é o "--network internal". Ambos os containeres precisam estar na mesma network/rede para poderem se comunicar.


<br>

Se tudo ocorreu conforme esperávamos você poderá acessar sua aplicação na url abaixo:

<http://localhost:5000/index.html>

<br>

Agora, não só irá acessar a documentação da API como poderá efetuar os _requests_, pois a comunicação entre o App e o BD está ocorrendo. 

Há ainda uma outra observação: nosso servidor MS SQL foi instanciado, porém, ainda não temos o banco de dados e a tabela necessária para efetuarmos o _request_ com sucesso.


#### Criar BD  e Tabela

Em um outro diretório iremos tratar de automatizar o script de criação do banco e da tabela. Por equanto, vamos criar na mão. 

Crie um novo banco de dados chamado "Backend".

Crie uma tabela chamada "Product", segue o _script_ para facilitar:

```
CREATE TABLE Product (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);

INSERT INTO Product VALUES('1', 'PRODUCT A', 9)
``` 

<br>

Nossa connectionString já está configurada na camada de dominio (Domain/Settings.cs):

```
"Server=sqlserver;Database=Backend;user=sa;password=Pass123*"
```

Observe que o "Server" não referenciar um IP ou mesmo o localhost, mas o nome do container do banco de dados, que no nosso caso é "sqlserver".

<br>

Agora sim, acesse a url e efetue os _requests_.

<http://localhost:5000/index.html>





<br>
<br>

#### Docker Compose 
Existe uma forma de executar todo o processo de criação dos containeres com um único comando. Sim, gerar uma imagem do App e instanciar ambos os conteineres com um só comando. 

Faremos isso utilizando **docker-compose**.

Podemos acompanhar esse tópico no diretório [Compose](https://github.com/vitormoschetta/Help-Docker/tree/main/Compose).

