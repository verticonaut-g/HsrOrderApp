using HsrOrderApp.SharedLibraries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.BL.DomainModel
{
    public class OrderRebateCalculator
    {
        class Rebate
        {
            public decimal lowerBound;
            public decimal rebate;

            public Rebate(decimal lowerBound, decimal rebate)
            {
                this.lowerBound = lowerBound;
                this.rebate = rebate;
            }

            public decimal calculateRebate(decimal amount)
            {
                return this.rebate * amount;
            }
        }

        private List<Rebate> Rebates = new List<Rebate>
        {
            new Rebate(0.0M, 0.00M),
            new Rebate(100.0M, 0.01M),
            new Rebate(200.0M, 0.03M),
            new Rebate(500.0M, 0.10M)
        };

        private Rebate findRebate(decimal amount)
        {
            Rebate result = Rebates[0];

            foreach (Rebate rebate in Rebates)
            {
                if (amount < rebate.lowerBound)
                {
                    return result;
                }
                else
                {
                    result = rebate;
                }
            }
            return result;
        }
 
        public decimal calculateRebate(decimal amount)
        {
            return findRebate(amount).calculateRebate(amount);
        }

    
    }
}
