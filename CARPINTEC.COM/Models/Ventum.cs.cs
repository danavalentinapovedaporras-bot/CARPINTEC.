namespace CARPINTEC.COM.Models
{
    public partial class Ventum
    {
        public int IdVenta { get; set; }

        public int IdPedido { get; set; }

        public int IdCliente { get; set; }

        public string? NumeroFactura { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public string? MetodoPago { get; set; }

        public string? Estado { get; set; }

        public string? Observaciones { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}