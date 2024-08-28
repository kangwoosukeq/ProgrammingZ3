#r "nuget: Microsoft.Z3"
open Microsoft.Z3

let ctx = new Context()

let tie = ctx.MkBoolConst("Tie")
let shirt = ctx.MkBoolConst("Shirt")

let s = ctx.MkSolver()
s.Add(ctx.MkOr(tie, shirt), ctx.MkOr(ctx.MkNot(tie), shirt), ctx.MkOr(ctx.MkNot(tie), ctx.MkNot(shirt)))

printfn $"{s.Check()}"
printfn $"{s.Model}"
