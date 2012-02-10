using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacao
{
    public static class Utilitarios
    {
        public static decimal AplicarAliquotaValor(this decimal valor, decimal aliquota)
        {
            return valor * aliquota / 100;
        }
    }
}
