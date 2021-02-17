# Criar própria imagem

Temos dois exemplos nos subdiretórios NETCoreDev e NETCoreProd.

NETCoreDev cria uma imagem de uma aplicação .NET Core para desenvolvimento e NETCoreProd uma imagem para produção.

<br>


### Imagens da Microsoft .NET Core

É importante observar que nossas imagens dependem de outras imagens, chamadas de **imagem base**:

- Nosso app de produção fará uso da imagem **mcr.microsoft.com/dotnet/core/aspnet:3.1**.

- E nosso app de desenvolvimento fará uso da imagem **mcr.microsoft.com/dotnet/core/sdk:3.1**

<br>

A diferença básica é que o app de produção precisa apenas do tempo de execução, ou seja, uma biblioteca para rodar as libs .dll.  
Já o app de desenvolvimento precisa de todo o SDK, ou seja, o pacote que contém as ferramentas de desenvolvimento e linha de comandos.


<br>

#### Mais detalhes nos subdiretórios:

[NETCoreProd](https://github.com/vitormoschetta/Help-Docker/tree/main/02-Dockerfile/NETCoreProd)

[NETCoreDev](https://github.com/vitormoschetta/Help-Docker/tree/main/02-Dockerfile/NETCoreDev)

