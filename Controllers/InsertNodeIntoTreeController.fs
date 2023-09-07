namespace Motorola_coding_challenge.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.IO
open System.Text.Json
open System.Text.Json.Nodes
open BST

(*
    This module is where all of the functions for parsing and converting the body of JSON payload are.
*)

type PostRequestData =
    {
        value : int
        tree : JsonNode
    }

module ProcessRequestData =

    // The payload is received as a stream
    // and needs to be processed to a string.
    let ReadRequest (request : Stream) =
        let reader = new StreamReader(request)
        let readResult = reader.ReadToEndAsync()
        readResult.Result
    
(*
    Casts the payload to a tree structure
    which can then be turned into a JSON string again
    by a call to the ConvertTreeToStringJson function.
*)

    let JsonNodeToTree nodeArg =
        let rec loop = function
            | null -> NIL
            | (node : JsonNode) ->
                NODE(node.Item("value") |> int,
                node.Item("left") |> loop,
                node.Item("right") |> loop)
        loop nodeArg

open ProcessRequestData

[<ApiController>]
[<Route("[controller]")>]
type InsertOperationController (logger : ILogger<InsertOperationController>) =
    inherit ControllerBase()

    (*
        This method is where the POST is actually processed.
        The payload is recieved and pipelined into a tree structre
        and then piplined into a string once the value has been added
        and finally returned with along with a OK 200.
        If the request fails to be processed by the server,
        the server will return a bad request code.
    *)

    [<HttpPost("/insert")>]
    member this.Post() : IActionResult =
        let data =
            this.Request.Body
            |> JsonSerializer.DeserializeAsync<PostRequestData>
        try
            match data.Result.tree with
            | null ->
                NODE(data.Result.value |> int, NIL, NIL)
                |> ConvertTreeToStringJson
                |> this.Ok
                :> IActionResult
            | node ->
                data.Result.tree
                |> JsonNodeToTree
                |> TreeInsertionTail ((NODE(data.Result.value |> int, NIL, NIL)))
                |> ConvertTreeToStringJson
                |> this.Ok
                :> IActionResult
        with
            | :? JsonException as e ->
                e.Message
                |> this.BadRequest
                :> IActionResult