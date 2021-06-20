using Microsoft.AspNetCore.Mvc;

namespace FundApps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourierKataController : ControllerBase
    {
        [HttpGet]
        public double Get(double length, double width, double depth)
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            return costCalculator.GetCost(length, width, depth);
        }
    }
}
