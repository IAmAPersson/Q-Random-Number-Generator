namespace Quantum.QSharpRandGen
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    
    operation Set(bits : Qubit[], desired : Result) : Unit {
        for (i in bits) {
            if (desired != M(i)) {
                X(i);
            }
        }
    }

    operation Generate () : Result[] {
        mutable res = new Result[32];

        using (bits = Qubit[8]) {
            for (i in 0 .. 3) {
                for (j in 0 .. 7) {
                    H(bits[j]);
                }

                for (j in 0 .. 7) {
                    set res w/= i * 8 + j <-  M(bits[j]);
                }
                
                Set(bits, Zero);
            }

            return res;
        }
    }
}
