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

Estas são as instruções que ficarão contidas na imagem ao ser criada, e que também serão repassadas ao contêiner quando a imagem for instanciada.


<br>

#### Explicando cada linha:
```
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
``` 
Informa a "imagem base" ser utilizada/baixada.

Veja que aqui informamos que queremos usar o SDK, ou seja, toda a ferramenta de desenvolvimento e linha de comandos.


<br>

```
COPY src/*.sln App/
COPY src/Domain/*.csproj App/Domain/
COPY src/Infra/*.csproj App/Infra/
COPY src/Tests/*.csproj App/Tests/
COPY src/Api/*.csproj App/Api/
``` 

Copia os arquivos .sln e .csproj localizados no diretório "src/..." do _host_ para dentro do diretório "App/..." da imagem que será criada.

Observe que copiamos apenas os arquivos necessários para restaurar o projeto na imagem.


<br>

```
WORKDIR /App
RUN dotnet restore
``` 
Restaura as dependências do projeto. Ou seja, baixa os pacotes necessários para executar a aplicação no container.


<br>

```
COPY src/Api/. ./Api/
COPY src/Domain/. ./Domain/
COPY src/Infra/. ./Infra/
COPY src/Tests/. ./Tests/
``` 
Copia todos os arquivos do _host_ para as pastas correspondentes na imagem.


<br>

```
WORKDIR /App/Api
RUN dotnet publish -c Release -o out
``` 
Publica arquivos _.dll_ no diretorio "/App/Api/out" da imagem.


<br>

```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
```
Informa a imagem "base" responsável pelo tempo de execução do .NET Core. Ela é responsável por processar as _.dll_ e manter o app em execução.


<br>

```
WORKDIR /App
COPY --from=build /App/Api/out ./
```
Move o console para a pasta "App" da imagem


<br>

```
ENTRYPOINT ["dotnet", "api.dll"]
```
Especifica o comando padrão a ser executado ao iniciar um contêiner a partir desta imagem.




<br>
<br>

## Gerando a imagem
```
docker build -t netcoreapp -f Dockerfile.dev .
```

Explicação dos parâmetros:
```
"-t netcoreapp" é o nome dado a imagem

"-f Dockerfile.dev ." informa ao Docker o nome do arquivo Dockerfile a ser procurado
```




<br>
<br>

## Registrando o container
```
docker run -d -p 5000:80 --name app -d netcoreapp
```

Explicação dos parâmetros:

```
"-d" Significa detached/separado. Isso quer dizer que ele executa independente do seu host.

"-p 5000:80" a porta 80 do container(porta padrão para aplicações web) é mapeada para a porta 5000 do host.

"--name app" o nome do container.

"-d netcoreapp" o nome da imagem que usaremos para instanciar o container.
```


<br>

Se tudo ocorreu como esperávamos você poderá acessar o app pela url abaixo:

<http://localhost:5000/index.html>