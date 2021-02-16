# Criar própria imagem

Temos dois exemplos nos subdiretórios (NETCoreDev e NETCoreProd).

NETCoreDev cria uma imagem de uma aplicação .NET Core para desenvolvimento e NETCoreProd uma imagem para produção.


### Imagens da Microsoft .NET Core

É importante observar que nossas imagens dependerão de outras imagens: as imagens do .NET Core.

Nosso app de produção fará uso da imagem **mcr.microsoft.com/dotnet/core/aspnet:3.1**.

E nosso app de desenvolvimento fará uso da imagem **mcr.microsoft.com/dotnet/core/sdk:3.1**

A diferença básica é que o app de produção precisa apenas do tempo de execução, ou seja, uma biblioteca para rodar as libs .dll. Já o app de desenvolvimento precisa de todo o SDK, ou seja, o pacote que contém as ferramentas de desenvolvimento e linha de comandos.

