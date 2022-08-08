using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingmnent3
{
    
    internal class CustomClassification
    {
          
        public enum Classifications 
        { 
            Consumer,
            Equipment,
            FarmProduct

        }


        public double CalculateTax(uint classification, double weight)
        {   
            if(classification == (uint)Classifications.Equipment)
            {
                double tax = 0.15 * weight;
                
                return tax;
            } else if(classification == (uint)Classifications.FarmProduct)
            {
                double tax = 0.05 * weight;
                return tax;
            } else if(classification == (uint)Classifications.Consumer)
            {
                double tax = 0.08 * weight;
                return tax;
            }
            else
            {
                return 0;
            }

        }
    }


}
