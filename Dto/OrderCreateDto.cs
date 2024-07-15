namespace Order.Aplication.Dto
{
    public record OrderCreateDto(string CodigoPedido, string CodigoCliente, ICollection<OrderItemDto> Itens );
    public record OrderItemDto(string Produto, double Quantidade, double Preco);
}