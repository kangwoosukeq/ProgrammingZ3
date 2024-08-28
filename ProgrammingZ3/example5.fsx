#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let x = ctx.MkIntConst("x")
let y = ctx.MkIntConst("y")
let n = ctx.MkGe(ctx.MkAdd(x, y), ctx.MkInt(3))

printfn $"num args: {n.NumArgs}"
printfn $"1st child: {n.Args[0]}"
printfn $"2nd child: {n.Args[1]}"
printfn $"operator: {n.FuncDecl}"
printfn $"op name: {n.FuncDecl.Name}"
