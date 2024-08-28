#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let Z = ctx.MkIntSort()
let f = ctx.MkFuncDecl("f", Z, Z)
let x = ctx.MkIntConst("x")
let y = ctx.MkIntConst("y")
let z = ctx.MkIntConst("z")
let a = ctx.MkArrayConst("A", Z, Z)

let fml =
    ctx.MkImplies(
        ctx.MkEq(ctx.MkAdd(x, ctx.MkInt(2)), y),
        ctx.MkEq(
            ctx.MkApp(f, ctx.MkSelect(ctx.MkStore(a, x, ctx.MkInt(3)), ctx.MkSub(y, ctx.MkInt(2)))),
            ctx.MkApp(f, ctx.MkAdd(ctx.MkSub(y, x), ctx.MkInt(1)))
        )
    )

let s = ctx.MkSolver()
let status = s.Check(ctx.MkNot(fml))
printfn $"{status}"

match status with
| Status.SATISFIABLE -> printfn $"{s.Model}"
| _ -> ()
