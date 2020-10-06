using System;
using System.Globalization;

namespace Aula07_CalculoSalarioVendedorComComissao
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Salario Base (Salario Bruto)
             * Calcular as comissoes de acordo com o produto
             * Calcular os descontos
             * Mostrar o Salário Final
             */
            double salario_base = 0.0;

            Console.WriteLine("Bem-vindo o Cálculo do seu Salário");
            Console.WriteLine("Informe o salário base: ");
            salario_base = Convert.ToDouble(Console.ReadLine());


            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;

            /***
             * Um vendendor trabalha com frios. Para cada produto há uma aliquota de comissão,
             * conforme a especificação abaixo:
             * Mussarela:     5.0%   Preço kg: 22,60
             * Mortadela:     6.5%   Preço kg:  8,98
             * Presunto:      4.5%   Preço kg: 31,03
             * Peito de Peru: 2.5%   Preço kg: 58,90 
             * Sabendo da aliquota da comissão: faça um programa que leia as quantidades vendidas
             * pelo vendedor e calcule a comissão.
             */
            double qnt_vendida_mussarela = 0.0; // kg
            double qnt_vendida_mortadela = 0.0;
            double qnt_vendida_presunto = 0.0;
            double qnt_vendida_peito_peru = 0.0;


            double valor_vendido_mussarela = 0.0; // R$
            double valor_vendido_mortadela = 0.0;
            double valor_vendido_presunto = 0.0;
            double valor_vendido_peito_peru = 0.0;

            double comissao_mussarela = 0.0; // R$
            double comissao_mortadela = 0.0;
            double comissao_presunto = 0.0;
            double comissao_peito_peru = 0.0;


            Console.WriteLine("Qual a quantidade de mussarela vendida em kilos:");
            qnt_vendida_mussarela = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Qual a quantidade de mortadela vendida em kilos:");
            qnt_vendida_mortadela = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Qual a quantidade de presunto vendida em kilos:");
            qnt_vendida_presunto = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Qual a quantidade de peito de peru vendida em kilos:");
            qnt_vendida_peito_peru = Convert.ToDouble(Console.ReadLine());

            /**
             * Calculando os valores vendidos.
             */
            valor_vendido_mussarela = qnt_vendida_mussarela * 22.6;
            valor_vendido_mortadela = qnt_vendida_mortadela * 8.98;
            valor_vendido_presunto = qnt_vendida_presunto * 31.03;
            valor_vendido_peito_peru = qnt_vendida_peito_peru * 58.90;


            /**
             * Calculando a comissão
             */
            comissao_mussarela = valor_vendido_mussarela * 0.05;
            comissao_mortadela = valor_vendido_mortadela * 0.065;
            comissao_presunto = valor_vendido_presunto * 0.045;
            comissao_peito_peru = valor_vendido_peito_peru * 0.025;

            double total_comissao = comissao_mussarela + comissao_mortadela + comissao_presunto + comissao_peito_peru;


            /**
             * Apresentando resultados
             */
            Console.WriteLine("Você vendeu {0} de MUSSARELA e comissão de {1}", valor_vendido_mussarela.ToString("C", nfi), comissao_mussarela.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de MORTADELA e comissão de {1}", valor_vendido_mortadela.ToString("C", nfi), comissao_mortadela.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de PRESUNTO e comissão de {1}", valor_vendido_presunto.ToString("C", nfi), comissao_presunto.ToString("C", nfi));
            Console.WriteLine("Você vendeu {0} de PEITO DE PERU e comissão de {1}", valor_vendido_peito_peru.ToString("C", nfi), comissao_peito_peru.ToString("C", nfi));

            Console.WriteLine("Você tem {0} de comissão.", total_comissao.ToString("C", nfi));

            Console.WriteLine("Agora o Sistema irá calcular os descontos do INSS e IPRF sobre salário base e comissões");

            double salario_bruto = salario_base + total_comissao;

            Console.WriteLine("_______________________________________________________");

            Console.WriteLine("Seu salário bruto é de {0}", salario_bruto.ToString("C", nfi));

            /**
            *  Exemplo de como fazer o cálculo em:
            *  https://www.contabeis.com.br/noticias/42234/calculo-da-nova-tabela-progressiva-do-inss-aliquotas-e-parcela-a-deduzir/
            *  
            *  Calculadora para testar:
            *  https://www.todacarreira.com/calculadora-de-salario-liquido/?value=3000&dependents=&otherdiscounts=#salary-simulator
            */


            string nome;
            int qnt_dependentes = 0;


            Console.WriteLine("Bem-vindo ao Sistema de Cálculo de Salário Liquido");

            Console.WriteLine("Olá, qual é o seu nome: ");
            nome = Console.ReadLine();

            //Console.WriteLine("Digite seu salário bruto:");
            //salario_bruto = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de dependentes:");
            qnt_dependentes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("_______________________________________________________");


            /* Entre cada parcela, o cálculo é feito considerando o máximo e o mínimo destas e a alíquota a 
             * ser aplicada. Enquanto o valor do salário não é atingido, é considerado o teto da faixa salarial.

                Veja como fica o cálculo para um salário de R$ 3.000,00 como exemplo, que se encontra na 2ª faixa:

                - 1ª faixa salarial: 1.045,00 x 0,075 = 78,38
                - 2ª faixa salarial: [2.089,60 - 1.045,00] x 0,09 = 1.044,60 x 0,09 = 94,01
                - Faixa que atinge o salário: [3.000,00 - 2.089,60] x 0,12 = 910,40 x 0,12 = 109,25
                - Total a recolher: 109,25 + 94,01 + 78,38 = 281,64

                Com este resultado é possível calcular a alíquota efetiva que se encontra em 
                cerca de 9,39% (281,64 ÷ 3.000,00).
             */

            double primeira_faixa = 0.0;
            double segunda_faixa = 0.0;
            double terceira_faixa = 0.0;
            double quarta_faixa = 0.0;


            if (salario_bruto <= 1045.00)    // 3000 -NO
            {
                primeira_faixa = salario_bruto * 0.075;
            }


            if (salario_bruto > 1045.00)
            {
                primeira_faixa = 1045.00 * 0.075;

                // Se menor q 2089.60 é a segunda faixa
                if (salario_bruto <= 2089.60)
                {
                    segunda_faixa = (salario_bruto - 1045.00) * 0.09;
                }

                // Se maior ou igual que 2086.61 calcular a segunda faixa sobre o valor devido
                if (salario_bruto >= 2086.61)
                {
                    segunda_faixa = (2086.60 - 1045) * 0.09;

                    // Se até 3134.40, calcular a terceira faixa do valor devido
                    if (salario_bruto <= 3134.40)
                    {
                        terceira_faixa = (salario_bruto - 2086.61) * 0.12;
                    }

                    if (salario_bruto >= 3134.41)
                    {
                        terceira_faixa = (3134.40 - 2086.61) * 0.12;

                        // Se até 6101.06
                        if (salario_bruto <= 6101.06)
                        {
                            quarta_faixa = (salario_bruto - 3134.41) * 0.14;
                        }

                        if (salario_bruto >= 6101.07)
                        {
                            quarta_faixa = (6101.06 - 3134.41) * 0.14;
                        }
                    }
                }
            }

            double total_inss = primeira_faixa + segunda_faixa + terceira_faixa + quarta_faixa;

            double salario_descontado_inss = salario_bruto - total_inss;

            /**
             * Começo do cálculo do imposto de renda
             * 
             * - Salário após desconto ao INSS: 3.000,00 - 281,64 = 2.718,36

                Consultando a tabela, vemos que a base de cálculo se enquadra na segunda linha. Com isso, multiplicamos a alíquota e subtraímos a dedução:

                - Alíquota: 2.718,36 x 0,075 = 203,87
                - Parcela a deduzir: 203,87- 142,80 = 61,07

                      Faixas                      Aliquota    Deduzir
                De R$ 1.903,99 até R$ 2.826,65    7,5%         142,80
                De R$ 2.826,66 até R$ 3.751,05    15%          354,80
                De R$ 3.751,06 até R$ 4.664,68    22,5%        636,13
                Acima de R$ 4.664,68              27,5%        869,36
             * 
             */
            double valor_ir = 0;

            double salario_descontado = salario_descontado_inss - (qnt_dependentes * 189.59);

            if (salario_descontado >= 1903.99 && salario_descontado <= 2826.65)
            {
                valor_ir = (salario_descontado * 0.075) - 142.8;
            }

            if (salario_descontado >= 2826.66 && salario_descontado <= 3751.05)
            {
                valor_ir = (salario_descontado * 0.15) - 354.8;
            }

            if (salario_descontado >= 3751.06 && salario_descontado <= 4664.68)
            {
                valor_ir = (salario_descontado * 0.225) - 636.13;
            }

            if (salario_descontado > 4664.68)
            {
                valor_ir = (salario_descontado * 0.275) - 869.36;
            }



            double total_descontos = total_inss + valor_ir;

            double salario_liquido = salario_bruto - total_descontos;


            Console.WriteLine("Valor da primeira faixa 7.5%  : " + primeira_faixa.ToString("C", nfi));
            Console.WriteLine("Valor da segunda faixa    9%  : " + segunda_faixa.ToString("C", nfi));
            Console.WriteLine("Valor da terceira faixa  12%  : " + terceira_faixa.ToString("C", nfi));
            Console.WriteLine("Valor da quarta faixa    14%  : " + quarta_faixa.ToString("C", nfi));
            Console.WriteLine("Total de INSS = " + total_inss.ToString("C", nfi));
            Console.WriteLine("_______________________________________________________");



            Console.WriteLine("Total IRPF = " + valor_ir.ToString("C", nfi));

            Console.WriteLine("_______________________________________________________");


            Console.WriteLine("Total Descontos = " + total_descontos.ToString("C", nfi));

            Console.WriteLine("_______________________________________________________");

            Console.WriteLine("Seu salário liquido é: " + salario_liquido.ToString("C", nfi));

        }
    }
}
