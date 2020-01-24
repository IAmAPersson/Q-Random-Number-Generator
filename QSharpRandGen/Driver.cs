using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Quantum.QSharpRandGen;


// ReSharper disable once CheckNamespace
class Driver
{
    static void Main(string[] args)
    {
        QuantumRandom r = new QuantumRandom();

        for (int i = 0; i < 5; i++)
            Console.WriteLine(r.NextInt());

        Console.ReadKey();
    }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
class QuantumRandom
{
    private readonly QuantumSimulator qsim;
    public QuantumRandom()
    {
        this.qsim = new QuantumSimulator();
    }

    public int NextInt()
    {
        IQArray<Result> results = Generate.Run(qsim).Result;
        int result = 0;

        for (int i = 0; i < 32; i++)
            if (results[i] == Result.One)
                result |= 1 << i;

        return result;
    }
}