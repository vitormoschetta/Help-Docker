## Volumes

Os volumes fornecem a capacidade de conectar caminhos específicos do sistema de arquivos do contêiner de volta à máquina host. 

Se um diretório no contêiner for montado, as alterações nesse diretório também serão vistas na máquina host. Se montarmos esse mesmo diretório nas reinicializações do contêiner, veremos os mesmos arquivos.


<br>

### Consultar volumes existentes:
```
docker volume ls
```


<br>

#### Criar um volume
```
docker volume create sqlserver-db
``` 


<br>

#### Instanciar DB MS SQL Server
```
docker run -e "ACCEPT_EULA=Y" --name sqlserver  -p 1433:1433 -e "SA_PASSWORD=Pass123*" -v sqlserver-db:/etc/data -d mcr.microsoft.com/mssql/server:2019-latest
``` 


Puts: descobri que dados de banco de dados não ficam salvos, apenas arquivos (txt, images, pdf, etc..)





