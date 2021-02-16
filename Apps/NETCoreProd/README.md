## Criar imagem App .NET Core para Produção

### Dockerfile

O arquivo "Dockerfile" contém o seguinte conteúdo:

```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY src/Api/bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "api.dll"]
``` 
Estas são as instruções que ficarão contidas na imagem ao ser criada, e que também serão repassadas ao contêiner quando a imagem for instanciada.

<br>

#### Explicando cada linha:

```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
``` 
Informa a "imagem base" ser utilizada/baixada.


<br>
```
COPY src/Api/bin/Release/netcoreapp3.1/publish/ App/
``` 
Copia os arquivos localizados no diretório "src/Api/bin/Release/netcoreapp3.1/publish/" do _host_ para dentro do diretório "App/" da imagem que será criada.


<br>
```
WORKDIR /App
``` 
Move o console para o diretório "/App" da imagagem


<br>
Aplica o comando "dotnet" sobre o arquivo "api.dll"
```
ENTRYPOINT ["dotnet", "api.dll"]
``` 

<br>
A imagem mantém os arquivos estáticos e as instruções necessárias para que ao ser instanciada em um contêiner, todo o ambiente esteja preparado para a execução do serviço/aplicação.


<br>
<br>

### Publicando primeiro
Em momento algum executamos um _build_ ou um _publish_, pois estamos pegando os arquivos já em formato de _.dll_ da pasta publish do projeto .NET Core. Ou seja, antes de rodar esta imagem precisamos executar o seguinte comando na raíz da aplicação:

```
dotnet publish -c Release
```

<br>
<br>


## Gerando a imagem
```
docker build -t netcoreapp .
```

Explicação dos parâmetros:
```
"-t netcoreapp" é o nome dado a imagem
```

<br>
<br>


## Registrando o container
```
docker run -d -p 8080:80 --name app -d netcoreapp
```

Explicação dos parâmetros:

```
"-d" Significa detached/separado. Isso quer dizer que ele executa independente do seu host.

"-p 5000:80" a porta 5000 (porta do app .NET Core) do container é mapeada para a porta 80 do host.

"--name app" o nome do container.

"-d netcoreapp" o nome da imagem que usaremos pra montar o container.
```

