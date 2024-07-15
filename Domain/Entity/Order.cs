namespace Order.Domian.Entity
{
    public class OrderEntity{
        public string CodigoPedido { get; set; } = string.Empty;
        public string CodigoCliente { get; set; } = string.Empty;
        public ICollection<OrderItens> Itens { get; set; } = new List<OrderItens>();
        public void AddItens(OrderItens item){
            Itens.Add(item);
        }
    }
}