using System;

namespace CashRegister
{
    class CashRegister
    {
        static void Main(string[] args)
        {
            (double purchase, double payment) = CurrencyOne();
            double result = payment - purchase;
            result = Math.Round(result, 2);
            Console.WriteLine($"           Changedue is: ${result}\n");
            DenominateOne(result);
        }

        private static (double, double) CurrencyOne()
        {
            // This prompts the user to enter a purchase and payment amount
            double purchase = Currency($"Enter a purchase amount: $");
            double payment = Currency("Enter a payment amount : $");

            // This iteration checks to ensure that the payment amount must always be greater than purchase amount
            while (payment < purchase)
            {
                Console.WriteLine($"Payment amount must be greater than purchase amount.\n");
                purchase = Currency("Enter a purchase amount: $");
                payment = Currency("Enter a payment amount : $");
            }
            return (purchase, payment);
        }
        private static void DenominateOne(double change)
        {
            change = Denominate(change, 20.0);
            change = Denominate(change, 10.0);
            change = Denominate(change, 5.0);
            change = Denominate(change, 1.0);
            change = Denominate(change, 0.25);
            change = Denominate(change, 0.10);
            change = Denominate(change, 0.05);
            change = Denominate(change, 0.01);
        }
        // This methods computes to determine how the different denomination could be allocated.
        // It has a check to distribute the required denomination(s)
        private static double Denominate(double changeDue, double currentDenomination)
        {
            int ans = (int)(changeDue / currentDenomination);
            double rem = changeDue % currentDenomination;
            if (ans >= 1)
            {
                Console.WriteLine($"Give {ans} {currentDenomination:C}");
            }
            return Math.Round(changeDue % currentDenomination, 2);
        }
        
        // This iteration in this method enforces that the user enters an amount greater than zero
        // and it checks to enforce the user to enter numbers. 
        private static double Currency(string prompt)
        {
            double amountOne = 0;
            bool amount = true;
            while (amount == true || amountOne <= 0)
            {
                try
                {
                    Console.Write(prompt);
                    amountOne = double.Parse(Console.ReadLine());
                    if (amountOne <= 0)
                    {
                        Console.WriteLine($"Please enter a number greater than zero.\n");
                    }
                    amount = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Please enter only numbers.\n");
                }
            }
            Console.WriteLine();
            return amountOne;
        }
    }
}
