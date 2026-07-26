using Kyrsova_2_sem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BigInt
{
    private const int BASE = 1000000000;
    private const int ChunkSize = 9;

    private List<int> myBigInt = new List<int>();
    private bool sign = true;

    private int MyBigIntLength => myBigInt.Count;


    private BigInt()
    {
    }

    public BigInt(string input)
    {
        if (input.StartsWith("-"))
        {
            this.sign = false;
            input = input.Substring(1);
        }
        else
        {
            this.sign = true;
        }
        if (!StringValidation(input, out myBigInt))
        {
            throw new ArgumentException("Некоректний формат вводу числа.");
        }
    }

    public BigInt(long value)
    {
        this.myBigInt = new List<int>();
        if (value == 0)
        {
            this.myBigInt.Add(0);
            return;
        }

        long temp = Math.Abs(value);
        while (temp > 0)
        {
            this.myBigInt.Add((int)(temp % BASE));
            temp /= BASE;
        }

        this.sign = value >= 0;
    }

    private bool StringValidation(string input, out List<int> myBigInt)
    {
        myBigInt = new List<int>();
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        for (int i = input.Length; i > 0; i -= ChunkSize)
        {
            int length = Math.Min(ChunkSize, i);
            string chunk = input.Substring(i - length, length);

            if (int.TryParse(chunk, out int parsedChunk))
            {
                myBigInt.Add(parsedChunk);
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private void Trim()
    {
        while (this.MyBigIntLength > 1 && this.myBigInt[this.MyBigIntLength - 1] == 0)
        {
            this.myBigInt.RemoveAt(this.MyBigIntLength - 1);
        }
        if(this.MyBigIntLength==1 && this.myBigInt[0] == 0)
        {
            this.sign = true;
        }
    }

    public int this[int i] => (i >= 0 && i < myBigInt.Count) ? myBigInt[i] : 0;

    public static bool operator <(BigInt a, BigInt b)
    {
        if (a.sign != b.sign)
        {
            if (a.sign)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        if (!a.sign)
        {
            if (a.MyBigIntLength != b.MyBigIntLength)
            {
                return a.MyBigIntLength > b.MyBigIntLength;
            }

            for (int i = a.MyBigIntLength - 1; i >= 0; i--)
            {
                if (a[i] != b[i])
                {
                    return a[i] > b[i];
                }
            }
        }
        else
        {
            if (a.MyBigIntLength != b.MyBigIntLength)
            {
                return a.MyBigIntLength < b.MyBigIntLength;
            }

            for (int i = a.MyBigIntLength - 1; i >= 0; i--)
            {
                if (a[i] != b[i])
                {
                    return a[i] < b[i];
                }
            }
        }

        return false;
    }

    public static bool operator >(BigInt a, BigInt b)
    {
        return b < a;
    }

    public static bool operator <=(BigInt a, BigInt b)
    {
        return !(a > b);
    }

    public static bool operator >=(BigInt a, BigInt b)
    {
        return !(a < b);
    }

    public static bool operator ==(BigInt a, BigInt b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        if (a.sign != b.sign || a.MyBigIntLength != b.MyBigIntLength)
        {
            return false;
        }

        for (int i = 0; i < a.MyBigIntLength; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true; ;
    }

    public static bool operator !=(BigInt a, BigInt b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is null || this.GetType() != obj.GetType())
        {
            return false;
        }

        BigInt other = (BigInt)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + sign.GetHashCode();

            foreach (int part in myBigInt)
            {
                hash = hash * 31 + part.GetHashCode();
            }
            return hash;
        }
    }

    public static BigInt operator +(BigInt a, BigInt b)
    {
        if (a.sign == b.sign)
        {
            BigInt result = AddArrays(a.Abs(), b.Abs());
            result.sign = a.sign;
            return result;
        }

        else
        {
            if (a.Abs() > b.Abs())
            {
                BigInt result = SubtractArrays(a.Abs(), b.Abs());
                result.sign = a.sign;
                return result;
            }
            else if (a.Abs() < b.Abs())
            {
                BigInt result = SubtractArrays(b.Abs(), a.Abs());
                result.sign = b.sign;
                return result;
            }
            else
            {

                return new BigInt(0);
            }
        }
    }

    public static BigInt operator -(BigInt a, BigInt b)
    {
        BigInt negativeB = b.Abs();
        negativeB.sign = !b.sign;

        return a + negativeB;
    }

    public BigInt Abs()
    {
        BigInt result = new BigInt();
        result.myBigInt = new List<int>(this.myBigInt);
        result.sign = true;
        return result;
    }

    private static BigInt AddArrays(BigInt a, BigInt b)
    {
        BigInt result = new BigInt();
        result.myBigInt.Clear();

        int maxSize = Math.Max(a.MyBigIntLength, b.MyBigIntLength);
        int carry = 0;
        int i = 0;

        while (i < maxSize || carry != 0)
        {
            int temp = a[i] + b[i] + carry;
            if (temp >= BASE)
            {
                result.myBigInt.Add(temp - BASE);
                carry = 1;
            }
            else
            {
                result.myBigInt.Add(temp);
                carry = 0;
            }
            i += 1;
            OpCounter.Add();
        }

        result.Trim();
        return result;
    }

    private static BigInt SubtractArrays(BigInt a, BigInt b)
    {
        BigInt result = new BigInt();
        result.myBigInt.Clear();

        int maxSize = Math.Max(a.MyBigIntLength, b.MyBigIntLength);
        int carry = 0;
        int i = 0;

        while (i < maxSize || carry != 0)
        {
            int temp = b[i] + carry;
            if (a[i] < temp)
            {
                result.myBigInt.Add(BASE + a[i] - temp);
                carry = 1;
            }
            else
            {
                result.myBigInt.Add(a[i] - temp);
                carry = 0;
            }
            i += 1;
            OpCounter.Add();
        }

        result.Trim();
        return result;
    }

    public static BigInt operator *(BigInt a, BigInt b)
    {
        OpCounter.Add();

        if (a.MyBigIntLength < 10 || b.MyBigIntLength < 10)
        {
            return MultiplyStandard(a,b);
        }

        int n = Math.Max(a.MyBigIntLength, b.MyBigIntLength);
        int m = n / 2;

        BigInt a1 = a.GetPart(m, a.MyBigIntLength);
        BigInt a0 = a.GetPart(0, m);
        BigInt b1 = b.GetPart(m, b.MyBigIntLength);
        BigInt b0 = b.GetPart(0, m);

        BigInt p1 = a1 * b1;
        BigInt p2 = a0 * b0;
        BigInt p3 = (a1 + a0) * (b1 + b0) - p1 - p2;


        BigInt result = p1.ShiftLeft(2 * m) + p3.ShiftLeft(m) + p2;

        BigInt zero = new BigInt(0);
        if (result != zero)
        {
            result.sign = (a.sign == b.sign);
        }

        return result;
    }

    public static BigInt operator /(BigInt a, BigInt b)
    {
        return Divide(a, b, out _);
    }

    public static BigInt operator %(BigInt a, BigInt b)
    {
        Divide(a, b, out BigInt remainder);

        return remainder;
    }

    private BigInt GetPart(int start, int end)
    {
        BigInt result = new BigInt();
        int actualEnd = Math.Min(end, this.MyBigIntLength);

        for (int i = start; i < actualEnd; i++)
        {
            result.myBigInt.Add(this.myBigInt[i]);
        }

        if (result.myBigInt.Count == 0)
        {
            result.myBigInt.Add(0);
        }

        result.Trim();
        return result;
    }

    private static BigInt MultiplyStandard(BigInt a, BigInt b)
    {
        BigInt result = new BigInt(0);

        result.myBigInt = new List<int>(new int[a.MyBigIntLength + b.MyBigIntLength]);

        for (int i = 0; i < a.MyBigIntLength; i++)
        {
            long carry = 0;
            for (int j = 0; j < b.MyBigIntLength; j++)
            {
                long temp = result.myBigInt[i + j] + (long)a[i] * b[j] + carry;
                result.myBigInt[i + j] = (int)(temp % BASE);
                carry = temp / BASE;
                OpCounter.Add();
            }
            if (carry > 0)
            {
                result.myBigInt[i + b.MyBigIntLength] += (int)carry;
            }
        }

        result.Trim();
        result.sign = (a.sign == b.sign);
        return result;
    }

    public static BigInt Divide(BigInt a, BigInt b, out BigInt remainder)
    {
        if (a == null)
        {
            throw new ArgumentNullException(nameof(a));
        }
        if (b == null)
        {
            throw new ArgumentNullException(nameof(b));
        }

        if (b == new BigInt(0))
        {
            throw new ArgumentException("Ділення на нуль неможливе.");
        }

        BigInt absA = a.Abs();
        BigInt absB = b.Abs();

        BigInt q = absA;
        int shift = absA.MyBigIntLength - absB.MyBigIntLength;
        BigInt p = new BigInt(0);
        int aLength = q.MyBigIntLength;

        while (absB <= q)
        {
            OpCounter.Add();
            int o = 1;
            BigInt temp = q.ShiftRight(shift);

            if (temp < absB)
            {
                shift--;
                temp = q.ShiftRight(shift);
                o = 0;
            }

            int d = FindMultiplier(absB, temp);
            BigInt m = absB * new BigInt(d);

            q = q - m.ShiftLeft(shift);
            p = p.ShiftLeft(1) + new BigInt(d);

            if (q < absB)
            {
                p = p.ShiftLeft(shift);
            }
            else
            {
                p = p.ShiftLeft(aLength - q.MyBigIntLength - o - 1);
            }

            aLength = q.MyBigIntLength;
        }

        remainder = q;
        BigInt zero = new BigInt(0);

        if (remainder != zero)
        {
            remainder.sign = a.sign;
        }

        if (p != zero)
        {
            p.sign = (a.sign == b.sign);
        }

        return p;
    }

    private static int FindMultiplier(BigInt b, BigInt temp)
    {
        long left = 0;
        long right = BASE -1;
        long bestMultiplier = 0;

        while (left <= right)
        {
            OpCounter.Add();
            long mid = (left + right) / 2;

            BigInt currentM = b * new BigInt(mid);

            if (currentM <= temp)
            {
                bestMultiplier = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return (int)bestMultiplier;
    }

    public BigInt ShiftLeft(int k)
    {
        if (k <= 0 || (this.MyBigIntLength == 1 && this.myBigInt[0] == 0))
        {
            return this;
        }

        BigInt result = new BigInt();
        result.myBigInt.AddRange(Enumerable.Repeat(0, k));
        result.myBigInt.AddRange(this.myBigInt);

        return result;
    }

    public BigInt ShiftRight(int k)
    {
        if (k <= 0)
        {
            return this;
        }

        BigInt result = new BigInt();

        if (k >= this.MyBigIntLength)
        {
            result.myBigInt.Add(0);
            return result;
        }

        for (int i = k; i < this.MyBigIntLength; i++)
        {
            result.myBigInt.Add(this.myBigInt[i]);
        }

        return result;
    }

    public override string ToString()
    {
        if (MyBigIntLength == 0)
        {
            return "0";
        }

        StringBuilder sb = new StringBuilder();

        if (!sign)
        {
            sb.Append("-");
        }

        sb.Append(myBigInt[MyBigIntLength - 1]);

        for (int i = MyBigIntLength - 2; i >= 0; i--)
        {
            sb.Append(myBigInt[i].ToString("D9"));
        }

        return sb.ToString();
    }
}

