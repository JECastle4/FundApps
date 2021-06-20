using System.Collections.Generic;

namespace FundApps.Controllers
{
    public class Order
    {
        public IList<Parcel> Parcels { get; set; }
        public double Cost 
        {
            get
            {
                double orderCost = 0;
                foreach(Parcel parcel in Parcels)
                {
                    orderCost += parcel.Cost;
                }
                return orderCost;
            }
        }
    }
}
