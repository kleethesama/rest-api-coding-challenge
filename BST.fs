module BST

(*
    The binary search tree is defined as made up of leafs (NIL) and nodes using a discriminated union.
    Leafs are empty while nodes contain a value of a type 'a and two other nodes or leafs.
*)

type 'a tree = NIL | NODE of 'a * 'a tree * 'a tree

(*
    Inserts a node with a value and leafs. The function is recursive using pattern matching.
    If the given value is less than its child node's value then the node is added to the left,
    otherwise it's added to the right.

    Note that this function-implementation is not tail-recursive and can therefore lead to a stack overflow.
*)

// TreeInsertion : tree<'a> -> tree<'a> -> tree<'a>
let rec TreeInsertion argNode = function
    | NIL -> argNode
    | NODE(value, left, right) ->
        match argNode with
        | NIL -> failwith "The node argument is empty."
        | NODE(arg_value, l, r) ->
            if arg_value < value then
                NODE(value, TreeInsertion argNode left, right)
            else
                NODE(value, left, TreeInsertion argNode right)

// This is the equivalent function from above, but with tail-recursion.
let TreeInsertionTail argNode targetTree =
    let rec loop argNode = function
        | NIL -> argNode
        | NODE(value, left, right) ->
            match argNode with
            | NIL -> failwith "The node argument is empty."
            | NODE(arg_value, l, r) ->
                if arg_value < value then
                    NODE(value, loop argNode left, right)
                else
                    NODE(value, left, loop argNode right)
    loop argNode targetTree

// Converts a tree structure into a string that represents the JSON-format.
let ConvertTreeToStringJson (tree : tree<int>) =
    let rec loop = function
        | NIL -> "null"
        | NODE(value, left, right) ->
            "{" + $""""left": {loop left}, "value": {value}, "right": {loop right}""" + "}"
    loop tree
