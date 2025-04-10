using Core.Repository;
using Core.Entity;

namespace StoreApi.Orders;

    public static class Endpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        var orderGroup = app.MapGroup("/orders");

        orderGroup.MapGet("/", GetAllOrders);
        orderGroup.MapGet("/{id}", GetOrderById);
        orderGroup.MapPost("/", CreateOrder);
        orderGroup.MapPut("/", UpdateOrder);
        orderGroup.MapDelete("/{id}", DeleteOrder);
    }

    private static async Task<IResult> GetAllOrders(IOrderRepository orderRepository)
    {
        var orders = await orderRepository.GetAllAsync();
        return TypedResults.Ok(orders);
    }

    private static async Task<IResult> GetOrderById(int id, IOrderRepository orderRepository)
    {
        var order = await orderRepository.GetByIdAsync(id);
        return order is not null ? TypedResults.Ok(order) : TypedResults.NotFound();
    }

    private static async Task<IResult> CreateOrder(OrderModel orderModel, IOrderRepository orderRepository)
    {
        try 
        {
            await orderRepository.AddAsync(new Order{
                BookId = orderModel.BookId,
                ClientId = orderModel.ClientId
            });
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> UpdateOrder(OrderModel orderModel, IOrderRepository orderRepository)
    {
        try 
        {
            var order = await orderRepository.GetByIdAsync(orderModel.Id);
            if (order is null)
            {
                return TypedResults.NotFound();
            }
            order.BookId = orderModel.BookId;
            order.ClientId = orderModel.ClientId;
            await orderRepository.UpdateAsync(order);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> DeleteOrder(int id, IOrderRepository orderRepository)
    {
        try 
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order is null)
            {
                return TypedResults.NotFound();
            }
            await orderRepository.DeleteAsync(order.Id);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}
