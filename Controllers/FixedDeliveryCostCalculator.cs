using System;

namespace FundApps.Controllers
{
    public class FixedDeliveryCostCalculator
    {
        public double GetCost(double length, double width, double depth)
        {
            // dimensions are in cms
            // return value is the cost in $

            if (length < 0 || width < 0 || depth < 0)
                throw new ArgumentException("All dimensions must be positive");

            const double smallest = 10;
            const double medium = 50;
            const double large = 100;

            if (length < smallest && width < smallest && depth < smallest)
                return 3;
            else if (length < medium && width < medium && depth < medium)
                return 8;
            else if (length < large && width < large && depth < large)
                return 15;

            // otherwise
            return 25;
        }
    }
}
