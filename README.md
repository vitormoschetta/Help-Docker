# Help-Docker

#### Informações sobre o docker instalado:
```
docker info
docker version
```

#### Consultar imagens existentes no host:
```
docker images
```

#### Baixar uma nova imagem:
```
docker pull <imagem>
```

#### Iniciar uma instância do container através de uma imagem:
```
docker run <imagem>
```
> O comando acima apenas executa a imagem e 'morre'. Seria como um _build_.
> Detalhe: Se a imagem não for encontrada o Docker tentará baixar do _Hub_.


#### Excluir imagem:
```
docker rmi <id/nome imagem>
```
> Se houver algum container usando essa imagem, mesmo que parado, não será possível excluí-la.




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

#### Referências
<https://medium.com/xp-inc/principais-comandos-docker-f9b02e6944cd>
