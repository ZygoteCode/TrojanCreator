﻿using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Numerics;

public class ProtoRandom
{
    private int complexity;

    public ProtoRandom(int complexity = 100)
    {
        this.complexity = complexity;
    }

    public int GetComplexity()
    {
        return this.complexity;
    }

    public void SetComplexity(int complexity)
    {
        this.complexity = complexity;
    }

    private BigInteger Modulus(BigInteger a, BigInteger b)
    {
        return (BigInteger.Abs(a * b) + a) % b;
    }

    private int GetBasicRandomInt32()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[4];
        rng.GetBytes(randomNumber);
        int value = BitConverter.ToInt32(randomNumber, 0);

        if (value < 0)
        {
            value *= -1;
        }

        return value;
    }

    private uint GetBasicRandomUInt32()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[4];
        rng.GetBytes(randomNumber);
        uint value = BitConverter.ToUInt32(randomNumber, 0);
        return value;
    }

    private long GetBasicRandomInt64()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[8];
        rng.GetBytes(randomNumber);
        long value = BitConverter.ToInt64(randomNumber, 0);

        if (value < 0)
        {
            value *= -1;
        }

        return value;
    }

    private ulong GetBasicRandomUInt64()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[8];
        rng.GetBytes(randomNumber);
        ulong value = BitConverter.ToUInt64(randomNumber, 0);
        return value;
    }

    private short GetBasicRandomInt16()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[2];
        rng.GetBytes(randomNumber);
        short value = BitConverter.ToInt16(randomNumber, 0);

        if (value < 0)
        {
            value *= -1;
        }

        return value;
    }

    private ushort GetBasicRandomUInt16()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[2];
        rng.GetBytes(randomNumber);
        ushort value = BitConverter.ToUInt16(randomNumber, 0);
        return value;
    }

    private double GetBasicRandomDouble()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[8];
        rng.GetBytes(randomNumber);
        double value = BitConverter.ToDouble(randomNumber, 0);

        if (value < 0)
        {
            value *= -1;
        }

        if (value.ToString().Contains("E"))
        {
            value = double.Parse(value.ToString().Split('E')[0]);
        }

        return value;
    }

    public byte[] GetRandomByteArray(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] random = new byte[size];
        rng.GetBytes(random);
        return random;
    }

    public byte[] GetRandomBytes(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] random = new byte[size];
        rng.GetBytes(random);
        return random;
    }

    public byte[] GetRandomByteArray(int min, int max)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] random = new byte[GetRandomInt32(min, max)];
        rng.GetBytes(random);
        return random;
    }

    public byte[] GetRandomBytes(int min, int max)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] random = new byte[GetRandomInt32(min, max)];
        rng.GetBytes(random);
        return random;
    }

    public int GetRandomInt32()
    {
        List<int[]> arrays = new List<int[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            int[] values = new int[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomInt32();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public int GetRandomInt32(int max)
    {
        return GetRandomInt32() % (max + 1);
    }

    public int GetRandomInt32(int min, int max)
    {
        return GetRandomInt32() % (max - min + 1) + min;
    }

    public bool GetRandomBoolean()
    {
        if (GetRandomInt32(1) == 0)
        {
            return false;
        }

        return true;
    }

    public string GetRandomString(char[] chars, int length)
    {
        string value = "";

        for (int i = 0; i < length; i++)
        {
            value += chars[GetRandomInt32(0, chars.Length - 1)];
        }

        return value;
    }

    public string GetRandomString(string chars, int length)
    {
        string value = "";

        for (int i = 0; i < length; i++)
        {
            value += chars[GetRandomInt32(0, chars.Length - 1)];
        }

        return value;
    }

    public string GetRandomString(char[] chars, int min, int max)
    {
        return GetRandomString(chars, GetRandomInt32(min, max));
    }

    public string GetRandomString(string chars, int min, int max)
    {
        return GetRandomString(chars, GetRandomInt32(min, max));
    }

    public uint GetRandomUInt32()
    {
        List<uint[]> arrays = new List<uint[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            uint[] values = new uint[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomUInt32();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public uint GetRandomUInt32(uint max)
    {
        return uint.Parse(Modulus(BigInteger.Parse(GetRandomUInt32().ToString()), BigInteger.Parse((max + 1).ToString())).ToString());
    }

    public uint GetRandomUInt32(uint min, uint max)
    {
        return uint.Parse(Modulus(BigInteger.Parse(GetRandomUInt32().ToString()), BigInteger.Parse((max - min + 1).ToString())).ToString()) + min;
    }

    public short GetRandomInt16()
    {
        List<short[]> arrays = new List<short[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            short[] values = new short[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomInt16();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public short GetRandomInt16(short max)
    {
        return short.Parse(Modulus(BigInteger.Parse(GetRandomInt16().ToString()), BigInteger.Parse((max + 1).ToString())).ToString());
    }

    public ushort GetRandomUInt16()
    {
        List<ushort[]> arrays = new List<ushort[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            ushort[] values = new ushort[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomUInt16();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public ushort GetRandomUInt16(ushort max)
    {
        return ushort.Parse(Modulus(BigInteger.Parse(GetRandomInt16().ToString()), BigInteger.Parse((max + 1).ToString())).ToString());
    }

    public long GetRandomInt64()
    {
        List<long[]> arrays = new List<long[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            long[] values = new long[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomInt64();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public long GetRandomInt64(long max)
    {
        return GetRandomInt64() % (max + 1);
    }

    public long GetRandomInt64(long min, long max)
    {
        return GetRandomInt64() % (max - min + 1) + min;
    }

    public ulong GetRandomUInt64()
    {
        List<ulong[]> arrays = new List<ulong[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            ulong[] values = new ulong[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomUInt64();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public ulong GetRandomUInt64(ulong max)
    {
        return ulong.Parse(Modulus(BigInteger.Parse(GetRandomUInt64().ToString()), BigInteger.Parse((max + 1).ToString())).ToString());
    }

    public ulong GetRandomUInt64(ulong min, ulong max)
    {
        return ulong.Parse(Modulus(BigInteger.Parse(GetRandomUInt64().ToString()), BigInteger.Parse((max - min + 1).ToString())).ToString()) + min;
    }

    public double GetRandomDouble()
    {
        List<double[]> arrays = new List<double[]>();

        for (int i = 0; i < this.complexity; i++)
        {
            double[] values = new double[this.complexity];

            for (int j = 0; j < this.complexity; j++)
            {
                values[j] = GetBasicRandomDouble();
            }

            arrays.Add(values);
        }

        return arrays[GetBasicRandomInt32() % this.complexity][GetBasicRandomInt32() % this.complexity];
    }

    public double GetRandomDouble(double max)
    {
        return modulo(GetRandomDouble(), max + 1);
    }

    public double GetRandomDouble(double min, double max)
    {
        return modulo(GetRandomDouble(), max - min + 1) + min;
    }

    private double modulo(double a, double b, double num_sig_digits = 14)
    {
        double int_closest_to_ratio, abs_val_of_residue;

        if (b == Math.Floor(b))
        {
            return (a % b);
        }
        else
        {
            int_closest_to_ratio = Math.Round(a / b);
            abs_val_of_residue = Math.Abs(a - int_closest_to_ratio * b);

            if (abs_val_of_residue < Math.Pow(10.0, -num_sig_digits))
            {
                return 0.0;
            }
            else
            {
                return abs_val_of_residue * Math.Sign(a);
            }
        }
    }
}