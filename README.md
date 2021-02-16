# Introdução comandos e funcionalidades Docker

Obs: Não abordaremos instação do Docker.


<br>

#### Informações sobre o docker instalado:
```
docker info
docker version
```


<br>

## Imagens Docker

Uma imagem é um pacote com todas as dependências e informações necessárias para criar um contêiner.

Geralmente, uma imagem deriva de várias imagens base que são camadas empilhadas umas sobre as outras para formar o sistema de arquivos do contêiner. Uma imagem é imutável depois de ser criada.

Podemos baixar imagens prontas do Docker Hub (repositório online do Docker) ou outro repositório. Existem centenas de milhares de imagens disponíveis.

Podemos, também, criar as nossas próprias imagens. Veremos isso mais a diante. 


<br>
Abaixo, alguns comandos básicos:


<br>

#### Consultar imagens existentes no host (máquina local):
```
docker images
```


<br>

#### Baixar uma nova imagem
O comando abaixo busca no Docker Hub uma imagem com o nome informado:
```
docker pull <image_name>
```


<br>

#### Excluir imagem:
```
docker rmi <image_id or image_name>
```
Se houver algum container usando a imagem, será necessário primeiro excluir o container.






<br>
<br>

## Containers Docker
Container é uma instância de uma determinada imagem. Ele fica em um ambiente isolado no Sistema Operacional, onde possui sua própria rede, host e portas.

Abaixo alguns comandos básicos:

<br>

#### Consultar containers em execução:
```
docker ps 
```


<br>

#### Consultar containers parados:
```
docker ps -a
```


<br>

#### Startar um container:
```
docker start <container_id or container_name>
```


<br>

#### Parar um container:
```
docker stop <container_id or container_name>
```


<br>

#### Excluir um container:
```
docker container rm <container_id or container_name>
```


<br>

#### Detalhes sobre container ou imagem:
```
docker inspect <container_id or container_name>
```





<br>
<br>

## Mão na massa

#### Utilizando imagem existente
Vamos utilizar imagens de bancos de dados conhecidos para instanciar containers.

Abordamos isso no diretório [Databases](https://github.com/vitormoschetta/Help-Docker/tree/main/Databases).


<br>

#### Criar a própria imagem
Para criar a própria imagem precisamos definir um arquivo chamado 'Dockerfile'.  

Abordamos isso no diretório [Apps](https://github.com/vitormoschetta/Help-Docker/tree/main/Apps).


<br>

#### Host e Container
Já aprendemos o que é uma imagem e um contêiner. Aprendemos a usar imagens prontas e a criar nossas próprias imagens a partir de imagens "base". Subimos um conteiner de aplicação e também subimos contêires de banco de dados. 

Podemos subir um banco de dados em contêiner e acessá-lo pela nossa aplicação em **_host_** usando os seguintes parâmetros do conteiner MySql, por exemplo:

```
Host: localhost
Port: 3306
User: root
Password: Pass123*
``` 
String de conexão: 
```
"Server=localhost;Port=3306;Database=database_name;Uid=root;Pwd=Pass123*;"
``` 

**Detalhe**: a nossa aplicação não rodará em contêiner, apenas o banco de dados. Uma vez que mapeamos a porta do conteiner e do _host_ isso fica fácil de fazer. 





<br>
<br>

## Comunicação entre Conteiners
Nosso desafio agora é subir aplicação e banco de dados, ambos em conteiner, e fazê-los se comunicarem.








<br>
<br>

## Volumes
Já aprendemos o que é uma imagem e um contêiner. Aprendemos a usar imagens prontas e a criar nossas próprias imagens a partir de imagens "base". Agora, vamos falar sobre Volumes.

Uma aplicação é basicamente dividida em interface/frontend, backend e base de dados. Queremos agora instanciar duas imagens em contêiners separados, e fazê-los se comunicarem. Podemos instanciar um contêiner de banco de dados, como vimos anteriormente, e um outro contêiner de aplicação. 




<br>
<br>

## Docker Compose
O docker-compose é um outro arquivo que nos auxilia na tarefa de execução do docker. 
Ele usa o formato de arquivo YAML com metadados para definir e executar aplicativos de vários contêineres.

Abordamos isso no diretório [Compose](https://github.com/vitormoschetta/Help-Docker/tree/main/Compose).


<br>
<br>




## Interface Docker no Linux
Executaremos aqui um container que gerencia a instancia do docker na máquina local. Ou seja, através dessa interface podemos identifiar as imagens, containers, volumes, etc.. que estamos trabalhando.

Executar o container:
```
docker run -d -p 9000:9000 -v /var/run/docker.sock:/var/run/docker.sock portainer/portainer
```
Depois de executado o comando acima, é só acessar a url abaixo e definir sua senha.      

<http://localhost:9000>  




<br>
<br>
<br>
<br>

### Referências:
<https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/container-docker-introduction/docker-terminology>
