# Motorola coding challenge - Binary Search Tree, REST API
## Implementations
* Binary search tree structure ✔
* Binary search tree insert operation ✔
* Implement a REST API for the insert operation ✔

## So what works?
Sending the following request:
```js
POST http://localhost:8080/insert
Content-Type: application/json

{
    "value": 174,
    "tree": {"left": {"left": null, "value": 20, "right": null}, "value": 30, "right": null}
}
```

Will yield the response:
```js
HTTP/1.1 200 OK
Connection: close
Content-Type: text/plain; charset=utf-8
Date: Tue, 22 Aug 2023 05:29:03 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "left": {
    "left": null,
    "value": 20,
    "right": null
  },
  "value": 30,
  "right": {
    "left": null,
    "value": 174,
    "right": null
  }
}
```

And sending the following request:
```js
POST http://localhost:8080/insert
Content-Type: application/json

{
    "value": 128,
    "tree": null
}
```

Will yield the response:

```js
HTTP/1.1 200 OK
Connection: close
Content-Type: text/plain; charset=utf-8
Date: Tue, 22 Aug 2023 05:31:31 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "left": null,
  "value": 128,
  "right": null
}
```

Finally, sending the following request:
```js
POST http://localhost:8080/insert
Content-Type: application/json

{
    "value": 17,
    "tree": {"left": {"left": null, "value": 20, "right": null}, "value": 30, "right": null},
    "TEST": 115
}
```

Will yield the response

```js
HTTP/1.1 200 OK
Connection: close
Content-Type: text/plain; charset=utf-8
Date: Tue, 22 Aug 2023 05:32:12 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "left": {
    "left": {
      "left": null,
      "value": 17,
      "right": null
    },
    "value": 20,
    "right": null
  },
  "value": 30,
  "right": null
}
```

## API Definition

### Insert tree operation

Request type
```js
POST /insert
Content-Type: application/json
```

Successful response
```js
200 Ok
```

Payload
```json
{
    "value": integer,
    "tree": tree
}
```

or

```json
{
    "value": integer,
    "tree": null
}
```

## Docker

Pull docker image from docker hub:

```
docker pull kleethesama/rest_api:latest
```

Running the following command in PowerShell:
```
docker run -p 127.0.0.1:8080:80 --rm kleethesama/rest_api
```

Should give the following results:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /App
```
