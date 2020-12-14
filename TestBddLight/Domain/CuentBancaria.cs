using System;
using System.Collections.Generic;
using System.Text;

namespace TestBddToolKit.Domain
{
    public class CuentBancaria
    {
        public decimal Saldo { get; private set; }
        public CuentBancaria(decimal saldo)
        {
            Saldo = saldo;
        }

        public void Consignar(decimal valor) => Saldo += valor;
    }
}
