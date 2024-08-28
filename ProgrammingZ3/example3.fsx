#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let S = ctx.MkUninterpretedSort("S")
let s = ctx.MkConst("s", S)

let solver = ctx.MkSolver()
let status = solver.Check(ctx.MkForall([| s |], ctx.MkNot(ctx.MkEq(s, s))))
printfn $"{status}"
