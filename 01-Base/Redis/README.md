## Rodar Redis Server local com Docker


#### Criar e Executar Container:
```
sudo docker run -p 6379:6379 --name redis -d redis
```

<br>

Se tudo ocorreu como gostaríamos, você poderá acessar o serviço no seguinte endereço
```
localhost, 6379
``` 

Uma ferramenta de gerenciamento indicada é o Redis Desktop Manager (RDM).