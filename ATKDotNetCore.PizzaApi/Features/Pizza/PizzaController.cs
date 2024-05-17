using ATKDotNetCore.PizzaApi.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATKDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrder(string invoiceNo)
        {
            var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            var lst = await _appDbContext.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
            return Ok(new
            {
                Order = item,
                OrderDetail =lst
            });
        }

        [HttpPost("Order")]
        public async Task<IActionResult> CreateOrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;
            
            if(orderRequest.Extras.Length > 0)
            {
                //select * from Tbl_PizzaExtra where PizzaExtraId in {1,2,3,4}
                //foreach(var extra in orderRequest.Extras)
                //{
                //}
                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            string invoiceNo = DateTime.Now.ToString("yyyyMMHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> lst = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaOrderInvoiceNo = invoiceNo,
                PizzaExtraId = extraId
            }).ToList();

            await _appDbContext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbContext.PizzaOrderDetails.AddRangeAsync(lst);
            await _appDbContext.SaveChangesAsync();

            OrderResponse resposne = new OrderResponse()
            {
                Message = "Thank you for your Pizza! Enjoy your pizza!",
                InvoiceNo = invoiceNo,
                TotalAmount = total
            };

            return Ok(resposne);
        }
    }
}
