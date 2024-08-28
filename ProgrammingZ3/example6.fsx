#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let Z = ctx.MkIntSort()
let m = ctx.MkArrayConst("m", Z, Z)
let m1 = ctx.MkArrayConst("m1", Z, Z)

let memset lo hi y m =
    let x = ctx.MkIntConst("x")
    ctx.MkLambda([| x |], ctx.MkITE(ctx.MkAnd(ctx.MkLe(lo, x), ctx.MkLe(x, hi)), y, ctx.MkSelect(m, x)))

let z = ctx.MkIntConst("z")

let solver = ctx.MkSolver()

let status =
    solver.Check(
        ctx.MkEq(m1, memset (ctx.MkInt(1)) (ctx.MkInt(700)) z m),
        ctx.MkNot(ctx.MkEq(ctx.MkSelect(m1, ctx.MkInt(6)), z))
    )

printfn $"{status}"
