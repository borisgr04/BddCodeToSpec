
using LightBDD.Framework;
using LightBDD.NUnit3;
using NUnit.Framework;
using LightBDD.Framework.Scenarios;
using System;
using TestBddToolKit.Domain;
using FluentAssertions;

namespace TestBddLight
{
    
    [TestFixture]
    [FeatureDescription(
    @"Para ahorrar mi dinero
    Como usuario
    Quiero consignar en cuenta bancaria")] //feature description
    [Label("Story-1")]
    public partial class ConsignacionConParametrosFeature: FeatureFixture //feature name
    {
        CuentBancaria sut;

        [Scenario]
        [Label("Caso-1")]
        [ScenarioCategory(Categories.Security)]
        public void Successful_consignacion() //scenario name
        {
            Runner.RunScenario(
                _=> Dado_que_tengo_cuenta_bancaria_con_saldo_inicial(1000),
                _=> Cuando_consigno(100),
                _=> Entonces_mi_nuevo_saldo_es(1100));
        }

        [Scenario]
        [Label("Caso-2")]
        [ScenarioCategory(Categories.Security)]
        public void Successful_consignacion_caso2() //scenario name
        {
            Runner.RunScenario(
                _ => Dado_que_tengo_cuenta_bancaria_con_saldo_inicial(1000),
                _ => Cuando_consigno(200),
                _ => Entonces_mi_nuevo_saldo_es(1200));
        }

        private void Dado_que_tengo_cuenta_bancaria_con_saldo_inicial(decimal saldoInicial)=>sut = new CuentBancaria(saldoInicial);

        private void Cuando_consigno(decimal valorConsignar)=> sut.Consignar(valorConsignar);

        private void Entonces_mi_nuevo_saldo_es(decimal saldoFinal)=> sut.Saldo.Should().Be(saldoFinal);
       
    }
}
