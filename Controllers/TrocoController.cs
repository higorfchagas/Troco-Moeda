using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testetobr.Data;
using TradebookApi.Models;

namespace testetobr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrocoController : ControllerBase
    {

        [Route("operacaoVenda")]
        [HttpGet]
        public string operacaoVenda([FromServices] DataContext context, decimal valorPago, decimal valorCompra)
        {
            if (valorPago > 0 && valorCompra > 0 && valorPago > valorCompra)
            {
                string resultadoFinal = definirTroco(context, valorPago, valorCompra);
                return resultadoFinal;
            }
            else
                return "Valores incorretos, corrija e tente novamente";
        }

        [Route("definirTroco")]
        [HttpGet]
        public string definirTroco([FromServices] DataContext context, decimal valorPago, decimal valorCompra)
        {
            int NotaDe200 = 0;
            int NotaDe100 = 0;
            int NotaDe50 = 0;
            int NotaDe20 = 0;
            int NotaDe10 = 0;
            int NotaDe5 = 0;
            int NotaDe2 = 0;
            int MoedaDe100 = 0;
            int MoedaDe50 = 0;
            int MoedaDe25 = 0;
            int MoedaDe10 = 0;
            int MoedaDe5 = 0;
            int SaldoParcial;
            bool PossuiNota = true;
            bool PossuiMoeda = true;
            decimal devolucaoTroco = 0;

            devolucaoTroco = valorPago - valorCompra;

            SaldoParcial = ((int)(devolucaoTroco));

            while (SaldoParcial != 0 && PossuiNota)
            {
                PossuiNota = false;
                while (SaldoParcial >= 200)
                {
                    SaldoParcial = SaldoParcial - 200;
                    NotaDe200++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 100)
                {
                    SaldoParcial = SaldoParcial - 100;
                    NotaDe100++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 50)
                {
                    SaldoParcial = SaldoParcial - 50;
                    NotaDe50++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 20)
                {
                    SaldoParcial = SaldoParcial - 20;
                    NotaDe20++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 10)
                {
                    SaldoParcial = SaldoParcial - 10;
                    NotaDe10++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 5)
                {
                    SaldoParcial = SaldoParcial - 5;
                    NotaDe5++;
                    PossuiNota = true;
                }
                while (SaldoParcial >= 2)
                {
                    SaldoParcial = SaldoParcial - 2;
                    NotaDe2++;
                    PossuiNota = true;
                }
            }

            SaldoParcial = ((int)(Math.Round(((SaldoParcial + (devolucaoTroco - ((int)(devolucaoTroco)))) * 100))));

            while (SaldoParcial != 0 && PossuiMoeda)
            {
                PossuiMoeda = false;

                while (SaldoParcial >= 100)
                {
                    SaldoParcial = SaldoParcial - 100;
                    MoedaDe100++;
                    PossuiMoeda = true;
                }

                while (SaldoParcial >= 50)
                {
                    SaldoParcial = SaldoParcial - 50;
                    MoedaDe50++;
                    PossuiMoeda = true;
                }

                while (SaldoParcial >= 25)
                {
                    SaldoParcial = SaldoParcial - 25;
                    MoedaDe25++;
                    PossuiMoeda = true;
                }

                while (SaldoParcial >= 10)
                {
                    SaldoParcial = SaldoParcial - 10;
                    MoedaDe10++;
                    PossuiMoeda = true;
                }

                while (SaldoParcial >= 5)
                {
                    SaldoParcial = SaldoParcial - 5;
                    MoedaDe5++;
                    PossuiMoeda = true;
                }
            }

            //Save da operação
            var operacaoSalva = criarOperacao(context, 
            valorPago, 
            valorCompra, 
            devolucaoTroco, 
            NotaDe200,
            NotaDe100,
            NotaDe50,
            NotaDe20,
            NotaDe10,
            NotaDe5,
            NotaDe2,
            MoedaDe100,
            MoedaDe50,
            MoedaDe25,
            MoedaDe10,
            MoedaDe5);

            if (operacaoSalva)
            {
                //Retornar string para usuário
                string ResultadoTroco = formatarTroco(
                NotaDe200,
                NotaDe100,
                NotaDe50,
                NotaDe20,
                NotaDe10,
                NotaDe5,
                NotaDe2,
                MoedaDe100,
                MoedaDe50,
                MoedaDe25,
                MoedaDe10,
                MoedaDe5,
                valorPago,
                valorCompra,
                devolucaoTroco);

                return ResultadoTroco;
            }
            else{
                return "Erro ao salvar a operação";
            }

        }


        [Route("criarOperacao")]
        [HttpGet]
        public bool criarOperacao([FromServices] DataContext context,
            decimal valorPago,
            decimal valorCompra,
            decimal devolucaoTroco,
            int NotaDe200,
            int NotaDe100,
            int NotaDe50,
            int NotaDe20,
            int NotaDe10,
            int NotaDe5,
            int NotaDe2,
            int MoedaDe100,
            int MoedaDe50,
            int MoedaDe25,
            int MoedaDe10,
            int MoedaDe5)
        {

            try
            {
                var operacao = new Operacao();

                operacao.Data = DateTime.Now;
                operacao.ValorPago = valorPago;
                operacao.ValorCompra = valorCompra;
                operacao.ValorTroco = devolucaoTroco;
                context.Operacao.Add(operacao);
                context.SaveChanges();

                //Saida de troco
                var saidaTroco = new SaidaTroco();
                saidaTroco.IdOperacao = operacao.Id;
                saidaTroco.NotaDe200 = NotaDe200;
                saidaTroco.NotaDe100 = NotaDe100;
                saidaTroco.NotaDe50 = NotaDe50;
                saidaTroco.NotaDe20 = NotaDe20;
                saidaTroco.NotaDe10 = NotaDe10;
                saidaTroco.NotaDe5 = NotaDe5;
                saidaTroco.NotaDe2 = NotaDe2;
                saidaTroco.MoedaDe100 = MoedaDe100;
                saidaTroco.MoedaDe50 = MoedaDe50;
                saidaTroco.MoedaDe25 = MoedaDe25;
                saidaTroco.MoedaDe10 = MoedaDe10;
                saidaTroco.MoedaDe5 = MoedaDe5;

                context.SaidaTroco.Add(saidaTroco);
                context.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }



        [Route("formatarTroco")]
        [HttpGet]
        public string formatarTroco(
            int NotaDe200,
            int NotaDe100,
            int NotaDe50,
            int NotaDe20,
            int NotaDe10,
            int NotaDe5,
            int NotaDe2,
            int MoedaDe100,
            int MoedaDe50,
            int MoedaDe25,
            int MoedaDe10,
            int MoedaDe5,
            decimal valorPago,
            decimal valorCompra,
            decimal devolucaoTroco)
        {

            string ResultadoTroco = "Valor da compra: R$" + valorCompra + ". \n";
            ResultadoTroco += "Valor pago: R$" + valorPago + ". \n";
            ResultadoTroco += "Valor do troco: R$" + devolucaoTroco + ". \n";
            ResultadoTroco += "O troco foi distruibido com as cédulas: \n \n";

            if (NotaDe200 > 0)
                ResultadoTroco += NotaDe200 + " nota(s) de R$ 200,00 reais. \n";

            if (NotaDe100 > 0)
                ResultadoTroco += NotaDe100 + " nota(s) de R$ 100,00 reais. \n";

            if (NotaDe50 > 0)
                ResultadoTroco += NotaDe50 + " nota(s) de R$ 50,00 reais. \n";

            if (NotaDe20 > 0)
                ResultadoTroco += NotaDe20 + " nota(s) de R$ 20,00 reais. \n";

            if (NotaDe10 > 0)
                ResultadoTroco += NotaDe10 + " nota(s) de R$ 10,00 reais. \n";

            if (NotaDe5 > 0)
                ResultadoTroco += NotaDe5 + " nota(s) de R$ 5,00 reais. \n";

            if (NotaDe2 > 0)
                ResultadoTroco += NotaDe2 + " nota(s) de R$ 2,00 reais. \n";

            if (MoedaDe100 > 0)
                ResultadoTroco += MoedaDe100 + " moeda(s) de R$ 1,00 reais. \n";

            if (MoedaDe50 > 0)
                ResultadoTroco += MoedaDe50 + " moeda(s) de R$ 0,50 centavos. \n";

            if (MoedaDe25 > 0)
                ResultadoTroco += MoedaDe25 + " moeda(s) de R$ 0,25 centavos. \n";

            if (MoedaDe10 > 0)
                ResultadoTroco += MoedaDe10 + "  moeda(s) de  R$ 0,10 centavos. \n";

            if (MoedaDe5 > 0)
                ResultadoTroco += MoedaDe5 + "  moeda(s) de R$ 0,05 centavos. \n";

            return ResultadoTroco;
        }
    }
}