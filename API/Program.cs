using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Revisao da prova");

app.MapPost("/api/tarefas/cadastrar", ([FromBody] Tarefa tarefa, [FromServices] AppDataContext ctx) =>
{
    ctx.Tarefas.Add(tarefa);
    ctx.SaveChanges();
    return Results.Created("", tarefa);
}

);

app.Run();
