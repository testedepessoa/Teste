using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aplicacao;

namespace TestProject1
{
    [TestClass]
    public class TestTributacao
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestarCalculoICMSComReducaoBase()
        {
            TributacaoICMS objTributacao = new TributacaoICMS(100);
            decimal percreducaobaseicms = 20;
            decimal aliquotaIcms = 18;
            Assert.AreEqual(14.40m, objTributacao.CalculoComReducaoBase(percreducaobaseicms, aliquotaIcms), "Teste Falhou Calculo ICMS Com Reducao Base");
        }

        [TestMethod]
        public void TestarCalculoICMSSemReducaoBase()
        {
            TributacaoICMS tributacao = new TributacaoICMS(100);
            decimal aliquotaIcms = 18;
            Assert.AreEqual(18m, tributacao.CalculoSemReducaoBase(aliquotaIcms));
        }

        [TestMethod]
        public void TestarCalculoICMSReduzido()
        {
            TributacaoICMS tribucacao = new TributacaoICMS(100);
            Assert.AreEqual(6m, tribucacao.CalculoValorReduzido(12m,18m));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestarCalculoICMSReduzidoRetornoNaoNegativo()
        {
            TributacaoICMS tribucacao = new TributacaoICMS(100);
            tribucacao.CalculoValorReduzido(18,12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestarCalculoICMSComReducaoBaseMaiorQueTrinta()
        {
            TributacaoICMS tribucacao = new TributacaoICMS(100);
            tribucacao.CalculoComReducaoBase(20, 31m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestarCalculoICMSSemReducaoBaseMaiorQueTrinta()
        {
            TributacaoICMS tribucacao = new TributacaoICMS(100);
            tribucacao.CalculoSemReducaoBase(31m);
        }

        [TestMethod]
        public void TestarAplicarAliquotaValor()
        {
            Assert.AreEqual(18m, Utilitarios.AplicarAliquotaValor(100m, 18m));
        }
    }
}
