module Tests

open BST

// Test tree examples from coding challenge pdf document.
let minimal_BST = NODE(3, NIL, NIL)
let insert_example = NODE(3, NODE(2, NIL, NIL), NIL)

// Tests to see if the TreeInsertion function works.
let insertion_test = minimal_BST |> TreeInsertionTail (NODE(2, NIL, NIL))
// --> NODE (3, NODE (2, NIL, NIL), NIL)

let insertion_test_2 = minimal_BST |> TreeInsertionTail (NODE(5, NIL, NIL))
// --> NODE (3, NIL, NODE (5, NIL, NIL))

let insertion_test_3 = insertion_test_2 |> TreeInsertionTail (NODE(10, NIL, NIL))
// --> NODE (3, NIL, NODE (5, NIL, NODE (10, NIL, NIL)))

let insertion_test_4 = insertion_test_3 |> TreeInsertionTail (NODE(1, NIL, NIL))
// --> NODE (3, NODE (1, NIL, NIL), NODE (5, NIL, NODE (10, NIL, NIL)))

printfn $"{insertion_test}"
printfn $"{insertion_test_2}"
printfn $"{insertion_test_3}"
printfn $"{insertion_test_4}"

let testJSONStringTree = """{"left": {"left": null, "value": 2, "right": null}, "value": 3, "right": null}"""