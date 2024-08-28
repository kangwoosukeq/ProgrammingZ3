#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let B = ctx.MkBoolSort()
let Z = ctx.MkIntSort()
let f = ctx.MkFuncDecl("f", B, Z)
let g = ctx.MkFuncDecl("g", Z, B)
let a = ctx.MkBoolConst("a")

let solver = ctx.MkSolver()

let status =
    solver.Check(ctx.MkApp(g, ctx.MkAdd(ctx.MkInt(1), ctx.MkApp(f, a) :?> ArithExpr)))

printfn $"{status}"
printfn $"{solver.Model}"
