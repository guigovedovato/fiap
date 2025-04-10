using Core.Repository;
using Core.Entity;

namespace StoreApi.Clients;

public static class Endpoints
{
    public static void MapClientEndpoints(this WebApplication app)
    {
        var clientGroup = app.MapGroup("/clients");

        clientGroup.MapGet("/", GetAllClients);
        clientGroup.MapGet("/{id}", GetClientById);
        clientGroup.MapPost("/", CreateClient);
        clientGroup.MapPut("/", UpdateClient);
        clientGroup.MapDelete("/{id}", DeleteClient);
        clientGroup.MapGet("/order/{id}", GetOrdersById);
    }

    private static async Task<IResult> GetAllClients(IClientRepository clientRepository)
    {
        var clients = await clientRepository.GetAllAsync();
        return TypedResults.Ok(clients);
    }
    
    private static async Task<IResult> GetClientById(int id, IClientRepository clientRepository)
    {
        var client = await clientRepository.GetByIdAsync(id);
        return client is not null ? TypedResults.Ok(client) : TypedResults.NotFound();
    }

    private static async Task<IResult> CreateClient(ClientModel clientModel, IClientRepository clientRepository)
    {
        try 
        {
            await clientRepository.AddAsync(new Client{
                Name = clientModel.Name,
                Email = clientModel.Email,
                BirthDate = clientModel.BirthDate
            });
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> UpdateClient(ClientModel clientModel, IClientRepository clientRepository)
    {
        try 
        {
            var client = await clientRepository.GetByIdAsync(clientModel.Id);
            if (client is null)
            {
                return TypedResults.NotFound();
            }
            client.Name = clientModel.Name;
            client.Email = clientModel.Email;
            client.BirthDate = clientModel.BirthDate;
            await clientRepository.UpdateAsync(client);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> DeleteClient(int id, IClientRepository clientRepository)
    {
        try 
        {
            var client = await clientRepository.GetByIdAsync(id);
            if (client is null)
            {
                return TypedResults.NotFound();
            }
            await clientRepository.DeleteAsync(client.Id);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> GetOrdersById(int id, IClientRepository clientRepository)
    {
        var client = await clientRepository.GetOrdersByIdAsync(id);
        return client is not null ? TypedResults.Ok(client) : TypedResults.NotFound();
    }
}