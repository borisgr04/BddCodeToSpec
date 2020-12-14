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
    public partial class ConsignacionSencillaFeature: FeatureFixture //feature name
    {
        CuentBancaria sut;

        [Scenario]
        [Label("Caso sin parametros")]
        [ScenarioCategory(Categories.Security)]
        public void Successful_consignacion() //scenario name
        {
            Runner.RunScenario(
                Dado_que_tengo_cuenta_bancaria_con_saldo_inicial, 
                Cuando_consigno,
                Entonces_mi_nuevo_saldo_es);
        }
        private void Dado_que_tengo_cuenta_bancaria_con_saldo_inicial()=> sut = new CuentBancaria(1000);
        private void Cuando_consigno()=> sut.Consignar(100);
        private void Entonces_mi_nuevo_saldo_es()=> sut.Saldo.Should().Be(1100);





    }
}
