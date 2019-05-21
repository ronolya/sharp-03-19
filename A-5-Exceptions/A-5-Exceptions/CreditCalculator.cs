namespace Advance.Lesson_5
{
    public static class CreditCalculator
    {
        public static double GetPaymentPerMonth(double amount, double percent, int monthes)
        {
            if (monthes == 0)
            {
                throw new InvalidCreditCalculatorParameterException<int>
                    (monthes, "monthes", "Credit cannot be issued for 0 monthes.");                
            }

            if (percent < 0)
            {
                throw new InvalidCreditCalculatorParameterException<double>
                    (percent, "percent", "Precent cannot be negative.");
            }

            if (amount < 0)
            {
                throw new InvalidCreditCalculatorParameterException<double>
                    (amount, "amount", "Amount cannot be negative.");
            }

            double paymentPerMonth = (amount + (amount * percent / 100)) / monthes;

            return paymentPerMonth;
        }
    }
}
