using System;

namespace FundApps.Controllers
{
    public class FixedDeliveryCostCalculator
    {
        public double GetCost(Parcel parcel)
        {
            // dimensions are in cms
            // Weight is in Kg
            // return value is the cost in $

            if (parcel.Length < 0 || parcel.Width < 0 || parcel.Depth < 0 || parcel.Weight < 0)
                throw new ArgumentException("All dimensions must be positive");

            const double smallest = 10;
            const double medium = 50;
            const double large = 100;

            double overweightCharge = parcel.Weight * 2;
            bool applyWeightLimit = false ;
            double cost = 25;

            if (parcel.Length < smallest && parcel.Width < smallest && parcel.Depth < smallest)
            {
                cost = 3;
                if (parcel.Weight > 1)
                    applyWeightLimit = true;
            }
            else if (parcel.Length < medium && parcel.Width < medium && parcel.Depth < medium)
            {
                cost = 8;
                if (parcel.Weight > 3)
                    applyWeightLimit = true;
            }
            else if (parcel.Length < large && parcel.Width < large && parcel.Depth < large)
            {
                cost = 15;
                if (parcel.Weight > 6)
                    applyWeightLimit = true;
            }            
            else
            {
                if (parcel.Weight > 10)
                    applyWeightLimit = true;
            }

            if (parcel.Weight < 50 && applyWeightLimit)
                overweightCharge = parcel.Weight;

            if (applyWeightLimit)
                cost += overweightCharge;

            // otherwise
            return cost;
        }
    }
}
