## Oracle Docker Hub

Imagem oficial do Oracle Db Enterprise para container Linux [aqui](https://hub.docker.com/u/vfariass/content/sub-4a8b6b44-85cf-4afc-9b72-6b9324d6d4a5) (necessário fazer login e aceitar os termos - uso gratuito apenas para desenvolvimento).


#### Executar o container
Necessário fazer login no docker CLI.

Em seguida executar o comando:

```
sudo docker run --name oracleDb -p 1521:1521 -p 5500:5500 store/oracle/database-enterprise:12.2.0.1
```

Obs: A imagem será baixada do docker hub caso ainda não tenha sido feito.


<br>

#### Configurações de acesso

![alt text](image.png?raw=true=250x250 "Title")