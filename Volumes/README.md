## Volumes

Os volumes fornecem a capacidade de conectar caminhos específicos do sistema de arquivos do contêiner de volta à máquina host. 

Se um diretório no contêiner for montado, as alterações nesse diretório também serão vistas na máquina host. Se montarmos esse mesmo diretório nas reinicializações do contêiner, veremos os mesmos arquivos.


<br>

#### Criar um volume
```
docker volume create todo-db
``` 





