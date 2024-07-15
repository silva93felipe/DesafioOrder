namespace Order.Domian.Entity
{
    public class OrderItens{
        public string Produto { get; set; } = string.Empty;
        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}