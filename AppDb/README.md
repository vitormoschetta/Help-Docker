## Rede de conteineres

Os contêineres, por padrão, são executados isoladamente e não sabem nada sobre outros processos ou contêineres na mesma máquina. Então, como permitimos que um contêiner converse com outro? A resposta é **networking**.


<br>

#### Criar a rede
```
docker network create internal

```


#### Criar um conteiner MS SQL Server e conectá-lo à rede 'internal'
```
docker run -e "ACCEPT_EULA=Y" \
--name sqlserver \
-p 1433:1433 \
-e "SA_PASSWORD=Pass123*" \
-e MSSQL_DB=Backend \
--network internal --network-alias sqlserver \
-v sql-data:/var/lib/mssql \
-d mcr.microsoft.com/mssql/server:2019-latest 

```

<br>

Obs: Antes de criarmos o conteiner para o App, precisamos saber o IP do conteiner do MS SQL Server na rede (internal) que criamos. Faremos isso usando o serviço do container Nicolaka:

``` 
docker run -it --network internal nicolaka/netshoot
```

Agora vamos identificar o IP do sqlserver na rede internal:
``` 
dig sqlserver
``` 
Obs: 'sqlserver' foi o nome que colocamos de '--network-alias'

O IP será mostrado na tela na seção 'ANSWER SECTION'. É algo como 172.21.0.2

