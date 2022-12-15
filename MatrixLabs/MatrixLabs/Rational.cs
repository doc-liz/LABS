using System.Globalization;
using System.Numerics;

namespace MatrixLabs;

public struct Rational : INumber<Rational>
{
    public static Rational One => new Rational(1, 1);
    public static Rational Zero => new Rational(1, 1);

    public int C { get; }
    public int Z { get; }

    public Rational(int c, int z)
    {
        var commonDivisor = GetCommonDivisor(c, z);
        C = c / commonDivisor;
        Z = z / commonDivisor;
    }

    public static implicit operator Rational(int a) => new Rational(a, 1);

    private static int GetCommonDivisor(int i, int j) //Алгоритм Евклида НОД
    {
        i = Math.Abs(i);
        j = Math.Abs(j);
        while (i != j)
            if (i > j) i -= j;
            else j -= i;
        return i;
    }

    public override string ToString() => Z != 1 ? $"{C}/{Z}" : $"{C}";

    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

    public static Rational Parse(string s, IFormatProvider? provider)
    {
        var num = s.Split('/');
        if (num.Length == 2)
        {
            return new Rational(int.Parse(num[0]), int.Parse(num[1]));
        }
        return new Rational(int.Parse(num[0]), 1);
    }

    public static Rational Parse(ReadOnlySpan<char> s, IFormatProvider? provider) 
    {
        var num = s.ToString().Split('/');
        if (num.Length == 2)
        {
            return new Rational(int.Parse(num[0]), int.Parse(num[1]));
        }
        return new Rational(int.Parse(num[0]), 1);
    } 

    #region Операторы математических операций

    public static Rational operator +(Rational left, Rational right)
        => new Rational(left.C * right.Z + left.Z * right.C, left.Z * right.Z);

    public static Rational operator -(Rational left, Rational right)
        => new Rational(left.C * right.Z - left.Z * right.C, left.Z * right.Z);

    public static Rational operator /(Rational left, Rational right)
        => new Rational(left.C * right.Z, left.Z * right.C);

    public static Rational operator *(Rational left, Rational right)
        => new Rational(left.C * right.C, left.Z * right.Z);

    public static Rational operator --(Rational value)
        => value - One;

    public static Rational operator ++(Rational value)
        => value + One;

    #endregion

    #region Операторы сравнения

    public static bool operator ==(Rational left, Rational right)
        => left.C * right.Z == left.Z * right.C;

    public static bool operator !=(Rational left, Rational right)
        => left.C * right.Z != left.Z * right.C;

    public static bool operator >(Rational left, Rational right)
        => left.C * right.Z > left.Z * right.C;

    public static bool operator >=(Rational left, Rational right)
        => left.C * right.Z >= left.Z * right.C;

    public static bool operator <(Rational left, Rational right)
        => left.C * right.Z < left.Z * right.C;

    public static bool operator <=(Rational left, Rational right)
        => left.C * right.Z <= left.Z * right.C;

    #endregion

    #region NotImplementedException

    public static int Radix { get; }
    public static Rational MultiplicativeIdentity { get; }

    public static Rational AdditiveIdentity { get; }

    public static Rational operator -(Rational value)
    {
        throw new NotImplementedException();
    }

    public static Rational operator %(Rational left, Rational right)
    {
        throw new NotImplementedException();
    }

    public static Rational operator +(Rational value)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Rational other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Rational other)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format,
        IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Rational result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational result)
    {
        throw new NotImplementedException();
    }

    public static Rational Abs(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Rational value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Rational value)
    {
        throw new NotImplementedException();
    }

    public static Rational MaxMagnitude(Rational x, Rational y)
    {
        throw new NotImplementedException();
    }

    public static Rational MaxMagnitudeNumber(Rational x, Rational y)
    {
        throw new NotImplementedException();
    }

    public static Rational MinMagnitude(Rational x, Rational y)
    {
        throw new NotImplementedException();
    }

    public static Rational MinMagnitudeNumber(Rational x, Rational y)
    {
        throw new NotImplementedException();
    }

    public static Rational Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Rational Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertFromChecked<TOther>(TOther value, out Rational result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertFromSaturating<TOther>(TOther value, out Rational result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertFromTruncating<TOther>(TOther value, out Rational result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertToChecked<TOther>(Rational value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertToSaturating<TOther>(Rational value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Rational>.TryConvertToTruncating<TOther>(Rational value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider,
        out Rational result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Rational result)
    {
        throw new NotImplementedException();
    }

    #endregion
}