namespace CARPINTEC_App.Models
{
    public partial class Venta
    {
        public int IdVenta { get; set; }

        public int IdPedido { get; set; }

        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }

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