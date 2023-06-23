Documentação da API
===================

Microserviço 1
--------------

### Descrição

Este serviço aceita um objeto JSON via HTTP POST, armazena esse objeto na "base de dados" e "envia" as informações do objeto para uma "fila".

### API

#### POST /api/books

Cria um novo livro.

##### Requisição

Headers:

* `Authorization`: `Bearer your_token`

Body:

jsonCopy code

`{     "id": 1,     "title": "Book Title" }`

##### Resposta

Status 201: Livro criado com sucesso.

jsonCopy code

`{     "id": 1,     "title": "Book Title" }`

Status 401: Não autorizado. Ocorre quando o token de autenticação é inválido ou não é enviado.

jsonCopy code

`{     "type": "https://tools.ietf.org/html/rfc7235#section-3.1",     "title": "Unauthorized",     "status": 401,     "traceId": "<traceId>" }`

Microserviço 2
--------------

### Descrição

Este serviço "consome" a fila e processa os objetos do banco de dados a partir dos dados que foram "recebidos".

### API

#### GET /api/books/{id}

Recupera um livro existente pelo seu ID.

##### Requisição

Headers:

* `Authorization`: `Bearer your_token`

##### Resposta

Status 200: Livro recuperado com sucesso.

jsonCopy code

`{     "id": 1,     "title": "Book Title" }`

Status 401: Não autorizado. Ocorre quando o token de autenticação é inválido ou não é enviado.

jsonCopy code

`{     "type": "https://tools.ietf.org/html/rfc7235#section-3.1",     "title": "Unauthorized",     "status": 401,     "traceId": "<traceId>" }`

Status 404: Livro não encontrado.

jsonCopy code

`{     "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",     "title": "Not Found",     "status": 404,     "traceId": "<traceId>" }`

### Como testar as APIs

Para testar essas APIs, você pode usar uma ferramenta como Postman ou curl. Aqui estão alguns exemplos de como você pode fazer isso com curl:

* POST /api/books:
  jsonCopy code
  `curl -X POST -H "Authorization: Bearer your_token" -H "Content-Type: application/json" -d '{"id":1,"title":"Book Title"}' https://localhost:<port>/api/books`

* GET /api/books/{id}:
  bashCopy code
  `curl -X GET -H "Authorization: Bearer your_token" https://localhost:<port>/api/books/1`

Lembre-se de substituir `<port>` pelo número da porta onde o serviço está sendo executado, e substituir `your_token` pelo token que você está usando para autenticação.

### Notas

Essa documentação pressupõe um ambiente de desenvolvimento simplificado e não inclui detalhes sobre a configuração do Azure Service Bus, Azure Cosmos DB, gRPC, etc. Para um ambiente de produção real, você precisará ajustar esta documentação de acordo.
