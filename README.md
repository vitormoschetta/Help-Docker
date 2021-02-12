# Help-Docker

#### Informações sobre o docker instalado:
```
docker info
docker version
```

#### Consultar imagens existentes:
```
docker ps -a
```

#### Consultar imagens existentes no host:
```
docker images
```

#### Consultar imagens existentes no host:
```
docker images
```

#### Baixar uma nova imagem:
```
docker pull <imagem>
```

#### Executar uma imagem:
```
docker run <imagem>
```
> O comando acima apenas executa a imagem e 'morre'. Seria como um _build_.


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

#### Detalhes sobre container ou imagem:
```
docker inspect <id container/imagem>
```

#### Deletar imagem:
```
docker rmi <id/nome imagem>
```
> Se houver algum container usando essa imagem, mesmo que parado, não será possível excluí-la.


#### Deletar imagem:
```
docker rmi <id/nome imagem>
```
> Se houver algum container usando essa imagem, mesmo que parado, não será possível excluí-la.




