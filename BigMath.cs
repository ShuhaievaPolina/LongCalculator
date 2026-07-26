using System;

namespace Kyrsova_2_sem
{
    public static class BigMath
    {
        public static BigInt Factorial(BigInt number)
        {
            BigInt zero = new BigInt(0);
            BigInt one = new BigInt(1);

            if (number < zero)
            {
                throw new ArgumentException("Неможливо обчислити факторіал від'ємного числа.");
            }

            if (number == zero || number == one)
            {
                return one;
            }

            BigInt result = one;
            BigInt temp = number;
            while (temp > one)
            {
                result = result * temp;
                temp = temp - one;
                OpCounter.Add();
            }

            return result;
        }

        public static BigInt BigPov(BigInt number, int x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Степінь не може бути від'ємним.");
            }

            BigInt zero = new BigInt(0);
            BigInt one = new BigInt(1);

            if (x == 0)
            {
                return one;
            }

            if (number == zero)
            {
                return zero;
            }

            if (number == one)
            {
                return one;
            }

            BigInt result = one;
            BigInt currentBase = number;

            while (x > 0)
            {
                if (x % 2 != 0)
                {
                    result = result * currentBase;
                }

                currentBase = currentBase * currentBase;
                x /= 2;
                OpCounter.Add();
            }

            return result;
        }
    }
}
