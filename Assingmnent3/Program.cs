namespace Assingmnent3
{
    internal class RateCalc :  CustomClassification, IShippingRules
    {
        Random rnd = new Random();
        public RateCalc()
        {
            ExchangeRate = rnd.NextDouble()*500;
        }

        public bool IsExport { get ; set ; }
        public string? Country { get; set ; }

        public double ExchangeRate { get ; private set; }

        

        public double CustomDuty( double weight, uint classification, double price, int quantity)
        {
            double tax = CalculateTax(classification, weight);
            
            if( IsExport == true)
            {
                tax = 0.09 * tax;
                return (tax + price) * quantity;

            }
            else
            {
                return ((price * ExchangeRate) + tax) * quantity;
            }
        }
        public double CustomDuty(double weight, uint classification, double price, int quantity, double discount)
        {
            double tax = CalculateTax(classification, weight);
            if (IsExport == true)
            {
                double discountVal = (0.09 * tax) * (discount / 100);
                tax = (0.09 * tax) - discountVal; 
                return ((tax + price) * quantity);

            }
            else
            {
                double discountVal = (0.09 * tax) * (discount / 100);
                tax = (0.09 * tax) - discountVal;
                return ((price * ExchangeRate) + tax) * quantity;
            }
        }
             

    }

    internal class Program : RateCalc
    {
        static void Main(string[] args)
        {
            var customDuty = new RateCalc();
            Console.WriteLine("What Operation would you like to perform? I - import,  E - Export");
            string? impEx = Console.ReadLine();
            if (impEx == null || impEx.ToLower() == "e")
            {
                customDuty.IsExport = true;
            } else if (impEx.ToLower() == "i")
            {
                customDuty.IsExport = false;
                Console.WriteLine("What Country are you Importing from? ");
                string? country = Console.ReadLine();
                customDuty.Country = country;
                double exchangeRate = customDuty.ExchangeRate;
                Console.WriteLine("Current Exchange Rate is " + exchangeRate);
            }

            Console.WriteLine("What is the classification of Package? ");
            Console.WriteLine("Consumer Goods - 0");
            Console.WriteLine("Equipment or Machinery - 1");
            Console.WriteLine("Farm Product - 2");
            uint packageClassification = (uint)Convert.ToInt16(Console.ReadLine());


            Console.WriteLine("What is the total weight of Package in kg? ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("How many Packages? ");
            int quantity = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("What is the price of each package in the Exporting Nation's Currency? ");
            double price = Convert.ToDouble(Console.ReadLine());

                      
            Console.WriteLine("Is there a Discount? [y/n]");
            string? isDiscount = Console.ReadLine();

            if (isDiscount != null && isDiscount.ToLower() == "y")
            {
                Console.WriteLine("How many percent is the discount?");
                double discount = Convert.ToDouble(Console.ReadLine());
                double duty = customDuty.CustomDuty(weight, packageClassification, price,quantity, discount);
                Console.WriteLine("Amount Needed to Clear Goods is " + duty);
            }
            else
            {
                double duty = customDuty.CustomDuty(weight, packageClassification, price, quantity);
                Console.WriteLine("Amount Needed to Clear Goods is " + duty);
            }

            

        }



        
    }
}

