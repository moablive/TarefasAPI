using Dapper.Contrib.Extensions;
using TarefasAPI.Data;
using static TarefasAPI.Data.TarefaContext;

namespace TarefasAPI.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Bem-Vindo a API Tarefas " + DateTime.Now);

            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con =  await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();
                if(tarefas is null) 
                {
                    return Results.NotFound();
                }
                return Results.Ok(tarefas);
            });

            app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var tarefa = con.Get<Tarefa>(id);

                if (tarefa != null)
                {
                    return Results.Ok(tarefa);
                }
                else
                {
                    return Results.NotFound();
                }
            });

            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(tarefa);
                
                if (id > 0)
                {
                    return Results.Created($"/tarefas/{id}", "Tarefa criada com sucesso");
                }
                else
                {
                    return Results.BadRequest("Falha ao criar a tarefa");
                }
            });

            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var success = con.Update(tarefa);
                
                if (success)
                {
                    return Results.Ok("Tarefa atualizada com sucesso");
                }
                else
                {
                    return Results.BadRequest("Falha ao atualizar a tarefa");
                }
            });

            app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var tarefa = con.Get<Tarefa>(id);

                if (tarefa != null)
                {
                    con.Delete(tarefa);
                    return Results.Ok("Tarefa deletada com sucesso");
                }
                else
                {
                    return Results.NotFound();
                }
            });
        }
    }
}
