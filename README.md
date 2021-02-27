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

#### Criar um container:
```
docker create --name <container_name> <image_name>
```


<br>

#### Startar um container:
```
docker start <container_id or container_name>
```


<br>

#### Criar e Startar um container em um só comando:
```
docker run --name <container_name> -d <image_name>
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

Abordamos isso no diretório [01-Base](https://github.com/vitormoschetta/Help-Docker/tree/main/01-Base).


<br>

#### Criar a própria imagem
Para criar a própria imagem precisamos definir um arquivo chamado 'Dockerfile'.  

Abordamos isso no diretório [02-Dockerfile](https://github.com/vitormoschetta/Help-Docker/tree/main/02-Dockerfile).


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

## Comunicação entre Conteineres
Nosso desafio agora é subir aplicação e banco de dados, ambos em conteiner, e fazê-los se comunicar.

Faremos isso no diretório [03-Network](https://github.com/vitormoschetta/Help-Docker/tree/main/03-Network).




<br>
<br>

## Docker Compose
O docker-compose é um outro arquivo que nos auxilia na tarefa de criação de containeres. 
Ele usa o formato de arquivo YAML com metadados para definir e executar aplicativos de vários contêineres.

Usaremos ele agora para executar de forma mais simples todo o processo que fizemos no tópico anterior (Comunicação entre conteineres).

Abordamos isso no diretório [04-Compose](https://github.com/vitormoschetta/Help-Docker/tree/main/04-Compose).







<br>
<br>

## Interface Docker no Linux
Até agora fizemos tudo utilizando o Docker CLI, a linha de comando do Docker. 

Existem porém algumas bibliotecas de UI para facilitar a visualização e o gerenciamento de containeres. Uma delas é o **portainer**. 

O portainer nada mais é do que uma imagem que instanciaremos em um conteiner, na porta 9000, que será responsável por gerar a parte visual e gerenciável do Docker.

Executar o container:
```
docker run -d -p 9000:9000 --name portainer --restart always --network=host -v /var/run/docker.sock:/var/run/docker.sock portainer/portainer
```
Onde:   
`--restart always`: informa que este container deve iniciar junto com o sistema.   
`--network=host`: informa que o container deve compartilhar a mesma rede do host. Isso quer dizer que de dentro do container é possível acessar o host.  

Acesse a url:    

<http://localhost:9000>  

Através desta UI podemos gerenciar imagens, conteiners, networks, volumes, etc..







<br>
<br>

## Outros comandos 

### Docker Prune 
Server para excluir recursos não utilizados. 

Segue alguns comandos:

#### Remove todos os recursos docker não utilizados (container, images, volumes, etc):
```
docker system prune 
```

<br>

#### Remove apenas volumes não utilizados:
```
docker volume prune
```

<br>

#### Remove apenas imagens não utilizadas:
```
docker image prune 
```

<br>

#### Remove apenas conteiners não utilizados:
```
docker conteiner prune 
```




<br>
<br>

## Volumes Docker
Implementar conteúdo...





<br>
<br>
<br>
<br>

### Referências:

<https://docs.docker.com/get-started/>  

<https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/container-docker-introduction/docker-terminology>
