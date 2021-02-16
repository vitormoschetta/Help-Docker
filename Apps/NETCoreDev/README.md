## Criar imagem App .NET Core para Desenvolvimento

### Dockerfile

O arquivo "Dockerfile" contém o seguinte conteúdo:

```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY src/Api/bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "api.dll"]
``` 

#### Explicando cada linha:

Informa a lib/biblioteca a ser utilizada:
```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
``` 

<br>

Copia os arquivos localizados no diretório "src/Api/bin/Release/netcoreapp3.1/publish/" do host para dentro do diretório "App/" da imagem que está sendo criada:
```
COPY src/Api/bin/Release/netcoreapp3.1/publish/ App/
``` 

<br>

Move o console para o diretório "/App" da imagagem
```
WORKDIR /App
``` 

<br>

Aplica o comando "dotnet" sobre o arquivo "api.dll"
```
ENTRYPOINT ["dotnet", "api.dll"]
``` 

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

