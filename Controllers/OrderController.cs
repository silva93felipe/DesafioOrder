using Microsoft.AspNetCore.Mvc;
using Order.Aplication.Contracts;
using Order.Aplication.Dto;
using Order.Domian.Entity;

namespace Order.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;
    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost]
    public void CreateOrder(OrderCreateDto orderCreateDto)
    {
        var order = new OrderEntity()
        {
            CodigoCliente = orderCreateDto.CodigoCliente,
            CodigoPedido = orderCreateDto.CodigoPedido,
        };
        foreach (var item in orderCreateDto.Itens)
        {
            var orderItem = new OrderItens()
            {
                Preco = item.Preco,
                Produto = item.Produto,
                Quantidade = item.Quantidade
            };

            order.Itens.Add(orderItem);
        }
        _orderService.CreateOrder(order);
    }
}
