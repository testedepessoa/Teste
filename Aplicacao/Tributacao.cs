using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacao
{
    public class TributacaoICMS
    {
        private decimal baseIcms;

        public TributacaoICMS(decimal _baseicms)
        {
            baseIcms = _baseicms;
        }

        private void validarAliquota(decimal aliquota)
        {
            if (aliquota > 30 || aliquota < 0)
            {
                throw new Exception("Aliquota deve estar entre zero e trinta.");
            }
        }

        public decimal CalculoComReducaoBase(decimal percreducaobaseicms, decimal aliquotaIcms)
        {
            validarAliquota(aliquotaIcms);

            decimal valoricms, basereduzida;

            basereduzida = baseIcms - baseIcms.AplicarAliquotaValor(percreducaobaseicms);
            valoricms = basereduzida.AplicarAliquotaValor(aliquotaIcms);

            return valoricms;
        }

        public decimal CalculoSemReducaoBase(decimal aliquotaIcms)
        {
            validarAliquota(aliquotaIcms);

            return baseIcms.AplicarAliquotaValor(aliquotaIcms);
        }

        public decimal CalculoValorReduzido(decimal aliquotaReduzida, decimal aliquotaNormal)
        {
            if (aliquotaNormal < aliquotaReduzida)
            {
                throw new Exception("A Aliquota Reduzida é maior que a Aliquota Normal");
            }

            decimal ValorDeICMSReduzido = CalculoSemReducaoBase(aliquotaReduzida); 
            decimal ValorDeICMSNormal = CalculoSemReducaoBase(aliquotaNormal);

            return (ValorDeICMSNormal - ValorDeICMSReduzido);
        }
    }
}
