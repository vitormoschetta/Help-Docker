## Criar imagem App .NET Core para Desenvolvimento

### Dockerfile

O arquivo "Dockerfile" contém o seguinte conteúdo:

```
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY src/*.sln App/
COPY src/Domain/*.csproj App/Domain/
COPY src/Infra/*.csproj App/Infra/
COPY src/Tests/*.csproj App/Tests/
COPY src/Api/*.csproj App/Api/

WORKDIR /App
RUN dotnet restore

COPY src/Api/. ./Api/
COPY src/Domain/. ./Domain/
COPY src/Infra/. ./Infra/
COPY src/Tests/. ./Tests/

WORKDIR /App/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /App
COPY --from=build /App/Api/out ./

ENTRYPOINT ["dotnet", "api.dll"]
``` 

#### Explicando cada linha:

Informa a lib/biblioteca a ser utilizada:
```
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
``` 
Veja que aqui informamos que queremos usar o SDK, ou seja, toda a ferramenta de desenvolvimento e linha de comandos.

<br>

Copia os arquivos .sln e .csproj localizados no diretório "src/..." do host para dentro do diretório "App/..." da imagem que está sendo criada:
```
COPY src/*.sln App/
COPY src/Domain/*.csproj App/Domain/
COPY src/Infra/*.csproj App/Infra/
COPY src/Tests/*.csproj App/Tests/
COPY src/Api/*.csproj App/Api/
``` 
Observe que copiamos apenas os arquivos necessários para restaurar o projeto na imagem.

<br>

Restaurar as dependências do projeto. Ou seja, baixar os pacotes necessários para executar a aplicação no container posteriormente através desta imagem.
```
WORKDIR /App
RUN dotnet restore
``` 

<br>

Copiar todos os arquivos do host para as pastas correspondentes na imagem:
```
COPY src/Api/. ./Api/
COPY src/Domain/. ./Domain/
COPY src/Infra/. ./Infra/
COPY src/Tests/. ./Tests/
``` 

<br>

Publicar arquivos .dll:
```
WORKDIR /App/Api
RUN dotnet publish -c Release -o out
``` 

<br>

Publicar arquivos .dll no diretorio "/App/Api/out" da imagem:
```
WORKDIR /App/Api
RUN dotnet publish -c Release -o out
``` 

<br>

Baixa a lib/bibliotca de tempo de execução do .NET Core. Ela é responsável por processar as .dll e manter o app em execução:
```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
```

<br>

Move o console para a pasta "App" da imagem:
```
WORKDIR /App
COPY --from=build /App/Api/out ./
```

<br>

O comando que define o que será executado e será mantido vivo:
```
ENTRYPOINT ["dotnet", "api.dll"]
```


<br>
<br>



## Gerando a imagem
```
docker build -t netcoreapp -f Dockerfile.dev .
```

Explicação dos parâmetros:
```
"-t netcoreapp" é o nome dado a imagem

"-f Dockerfile.dev ." define o Dockerfile a ser executado
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



<br>
<br>


###### Nesta abordagem podemos incluir muitos outros comandos no Dockerfile. Podemos inclusive rodar testes.