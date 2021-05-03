using System;
namespace Autopal.ASML.Runner.SumOfMultiple
{
    public class SumOfMultipleSolver
    {
       
        public ulong Solve(int input)
        {
            if (input <= 0)
                throw new ArgumentOutOfRangeException(nameof(input), input, "Limit needs to be positive number!");
            var limit = (ulong) (input - 1);
            // Sum all numbers till limit/3 and then multiple it with 3 to get sum of numbers multiple of 3.
            var sumOf3 = SumOfAllNumbersMultipleOfXTillN(3, limit);
            // Sum all numbers till limit/5 and then multiple it with 5 to get sum of numbers multiple of 5.
            var sumOf5 = SumOfAllNumbersMultipleOfXTillN(5, limit);

            // Sum all numbers till limit/15 and then multiple it with 15 to get sum of numbers multiple of 15.
            var sumOf15 = SumOfAllNumbersMultipleOfXTillN(15, limit);

            // Add the amount you found for 3 and 5
            // then subtract result of 15 otherwise it would be duplicate.
            return sumOf3 + sumOf5 - sumOf15;
        }

        private static ulong SumOfAllNumbersMultipleOfXTillN(ulong multipleOf, ulong limit)
        {
            return SumOfAllNumbersTillN(limit / multipleOf) * multipleOf;
        }

        private static ulong SumOfAllNumbersTillN(ulong n)
        {
            return n * (n + 1) / 2;
        }
    }
}
