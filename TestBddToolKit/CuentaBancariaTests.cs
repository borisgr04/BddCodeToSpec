using ITLIBRIUM.BddToolkit;
using NUnit.Framework;
using System;
using System.Threading;
using FluentAssertions;
using ITLIBRIUM.BddToolkit.Docs;
using TestBddToolKit.Domain;
using ITLIBRIUM.BddToolkit.Syntax.Features;
using Humanizer;
using ITLIBRIUM.BddToolkit.Syntax.Rules;

namespace TestBddToolKit
{
    public class CuentaBancariaTests
    {
        [OneTimeSetUp]
        public void Setup() => Bdd.Configure(configuration => configuration
            .Use(DocPublishers.GherkinFiles()));

        [OneTimeTearDown]
        public void PublishDocs() => Bdd.PublishDocs(CancellationToken.None);

        private static readonly Feature ConsignarEnCuentaBancaria= Bdd
        .Feature(nameof(ConsignarEnCuentaBancaria).Humanize())
        .Description("Optional description")
        .Tags("tag1", "tag2");

        private static readonly Rule ConsignacionCorrecta = Bdd
            .Rule(nameof(ConsignacionCorrecta).Humanize())
            .Feature(ConsignarEnCuentaBancaria)
            .Description("Optional description");

        [Test]
        public void PuedeConsignar150ConSaldo1000()
        {
            Bdd.Scenario<Context>()
                .Rule(ConsignacionCorrecta)
                .Tags("tag3", "tag4")
                .Given(c => c.TengoUnCuentaBancariaConSaldoInicialDe(1000))
                .When(c => c.Consigno(150))
                .Then(c => c.MiNuevoSaldoEs(1150))
                .Test();
        }

        [TestCase(1000,200,1200, TestName ="ConsignacionDe200Correcta")]
        [TestCase(1000, 100, 1200, TestName = "ConsignacionDe100Incorrecta")]
        [Test]
        public void PuedeConsignar200ConSaldo1000(decimal saldoInicial, decimal valorConsigacion, decimal saldoEsperado)
        {
            Bdd.Scenario<Context>()
                .Rule(ConsignacionCorrecta)
                .Tags("tag3", "tag4")
                .Given(c => c.TengoUnCuentaBancariaConSaldoInicialDe(saldoInicial))
                .When(c => c.Consigno(valorConsigacion))
                .Then(c => c.MiNuevoSaldoEs(saldoEsperado))
                .Test();
        }

        public class Context
        {
            CuentBancaria sut;
            internal void TengoUnCuentaBancariaConSaldoInicialDe(decimal saldoInicial) => sut = new CuentBancaria(saldoInicial);

            internal void Consigno(decimal valor) => sut.Consignar(valor);
            
            internal void MiNuevoSaldoEs(decimal valor) => sut.Saldo.Should().Be(valor);
            
        }

    
    }
}
