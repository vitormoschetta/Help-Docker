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
Se houver algum container usando a imagem, será necessário primeiro excluir esse container.



<br>
<br>



## Mão na massa

#### Utilizando imagem existente
Vamos utilizar imagens de bancos de dados conhecidos para instanciar containers.

Abordamos isso no diretório [Databases](https://github.com/vitormoschetta/Help-Docker/tree/main/Databases).

<br>

#### Criar a própria imagem
Para criar uma imagem precisamos definir um arquivo chamado 'Dockerfile'.  

Abordamos isso no diretório [Apps](https://github.com/vitormoschetta/Help-Docker/tree/main/Apps).



<br>
<br>




## Containers Docker
O Container é um ambiente isolado que simula uma máquina virtual. Ele possui sua própria rede, host e portas.

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




## Docker Compose
O docker-compose é um outro arquivo que nos auxilia na tarefa de execução do docker. Através e scripts específicos podemos facilitar o download de imagens, definir configurações e inicializar containers.

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



