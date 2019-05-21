namespace AL_9_Unit_Tests
{
    public class DepCalculator
    {
        public int Sum(int a, int b)
        {
            return a + b;  
        }

        public int Multiple(params int[] numbers)
        {
            var result = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                result += numbers[i];
            }

            return result;
        }
    }
}
