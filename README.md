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

Uma imagem pode ser baixada do Hub (repositório online do Docker). Existem centenas de milhares de imagens disponíveis.

Podemos, também, criar as nossas próprias imagens.  

Abaixo, alguns comandos básicos:

#### Consultar imagens existentes no host (máquina local):
```
docker images
```

#### Baixar uma nova imagem
O comando abaixo busca no Docker Hub uma imagem com o nome informado:
```
docker pull <image_name>
```

#### Excluir imagem:
```
docker rmi <image_id or image_name>
```
Se houver algum container usando a imagem, será necessário primeiro excluir esse container.


#### Criar a própria imagem:
Para criar uma imagem precisamos definir um arquivo chamado 'Dockerfile'.  

[Neste ]https://github.com/vitormoschetta/Help-Docker/NETCore/) diretório

<br>
<br>



#### Consultar containers em execução:
```
docker ps 
```

#### Consultar containers parados:
```
docker ps -a
```

#### Startar um container:
```
docker start <id container>
```

#### Parar um container:
```
docker stop <id container>
```

#### Excluir um container:
```
docker container rm <container ID>
```

#### Detalhes sobre container ou imagem:
```
docker inspect <id container/imagem>
```

<br>
<br>

### Instalar uma interface para o Docker no Linux
```
docker run -d -p 9000:9000 -v /var/run/docker.sock:/var/run/docker.sock portainer/portainer
```
Depois de executado o comando acima, é só acessar a url abaixo e definir sua senha.      
<http://localhost:9000>  

<br>
<br>


### Saiba como inicializar Containers do Docker nos demais repositórios.

<br>
<br>

#### Referências
<https://medium.com/xp-inc/principais-comandos-docker-f9b02e6944cd>
