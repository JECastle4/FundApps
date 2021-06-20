namespace FundApps.Controllers
{
    public class Parcel
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Cost 
        { 
            get
            {
                FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
                return costCalculator.GetCost(this);
            } 
        }
    }
}
