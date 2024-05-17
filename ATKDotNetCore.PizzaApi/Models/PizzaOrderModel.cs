namespace ATKDotNetCore.PizzaApi.Models
{
    public class PizzaOrderModel
    {
        public int PizzaOrderId { get; set; }

        public string PizzaOrderInvoiceNo { get; set; }

        public int PizzaId { get; set; }

        public decimal TotalAmount { get; set; }    
    }
}
