using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calculos
{
    public class CalculosValores
    {
        public void EntradaDeValores()
        {
            Console.WriteLine("###########################################\n");
            Console.WriteLine("######## CALCULO LUCRO POR PRODUTO ########\n");
            Console.WriteLine("###########################################\n");
            Console.Write("\nQuantos tipos de produtos foram vendidos? ");
            var tiposProdutos = Convert.ToInt32(Console.ReadLine());

            var conferido = Conferencia(tiposProdutos);

            if (conferido == false)
            {
                Console.WriteLine("\nNão foi identificado uma quantidade válida de produtos!");
            }
            Tabela(tiposProdutos);
        }

        private bool Conferencia(int tiposProdutos)
        {
            if (tiposProdutos <= 0)
            {
                Console.WriteLine("\nA quantidade de produtos não pode ser igual ou menor a 0!");
                return false;
            }
            return true;

        }

        public void Tabela(int tiposProdutos)
        {
            var Produto = new string[tiposProdutos, 5];
            var vendasInformadaString = "";
            var quantInformada = 0;
            var nomeDoProduto = "";
            var precoCompraString = "";
            var valorVendaString = "";
            var somaCompra = 0.0;
            var valorTotalVenda = 0.0;

            for (int lin = 0; lin < tiposProdutos; lin++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Clear();
                    Console.Write($"\nDigite o nome do {lin + 1}º produto: ");
                    nomeDoProduto = Console.ReadLine();
                    Produto[lin, col] = nomeDoProduto;
                    col++;

                    Console.Write($"\nQuantidade de vendas realizadas do produto {nomeDoProduto}: ");
                    vendasInformadaString = Console.ReadLine();
                    Produto[lin, col] = vendasInformadaString;
                    col++;

                    Console.Write($"\nDigite o preço de compra do produto {nomeDoProduto}: R$ ");
                    precoCompraString = Console.ReadLine();
                    double valorDeCompra = Convert.ToDouble(precoCompraString);
                    quantInformada = Convert.ToInt32(vendasInformadaString);
                    somaCompra = somaCompra + (valorDeCompra * quantInformada);
                    Produto[lin, col] = precoCompraString;
                    col++;

                    Console.Write($"\nDigite o preço de venda do produto {nomeDoProduto}: R$");
                    valorVendaString = Console.ReadLine();
                    double valorVenda = Convert.ToDouble(valorVendaString);
                    quantInformada = Convert.ToInt32(vendasInformadaString);
                    valorTotalVenda = valorTotalVenda + (valorVenda * quantInformada);
                    Produto[lin, col] = valorVendaString;
                    col++;

                }
            }

            double imposto = valorTotalVenda * 0.18;
            double lucro = valorTotalVenda - somaCompra - imposto;

            Console.Clear();
            Console.WriteLine("###########################################\n");
            Console.WriteLine("######## CÁLCULO LUCRO POR PRODUTO ########\n");
            Console.WriteLine("###########################################\n");

            for (int lin = 0; lin < tiposProdutos; lin++)
            {
                var produto = Produto[lin, 0];
                var quantidade = Convert.ToInt32(Produto[lin, 1]);
                var valorDeCompra = Convert.ToDouble(Produto[lin, 2]);
                var valorVenda = Convert.ToDouble(Produto[lin, 3]);
                var imp = valorVenda * 0.18;
                Console.WriteLine($"Nome do produto vendido: {produto.ToUpper()}\n\nQuantidade vendida do produto: {quantidade} \nPreço de compra: {valorDeCompra.ToString("C2")}\nPreço de venda: {valorVenda.ToString("C2")}\nValor do imposto recolhido por unidade: {imp.ToString("C2")}\n");
            }

            SaidaValores(valorTotalVenda, somaCompra, imposto, lucro);
        }

        public void SaidaValores(double valorTotalVenda, double soma, double imposto, double lucro)
        {
            Console.WriteLine($"\nVALOR TOTAL DE COMPRA: {soma.ToString("C2")} \nVALOR TOTAL EM VENDAS: {valorTotalVenda.ToString("C2")} \nVALOR TOTAL DE IMPOSTO RECOLHIDO: {imposto.ToString("C2")} \nLUCRO LIQUIDO: {lucro.ToString("C2")}");
            Console.WriteLine("\n\nDESEJA CALCULAR NOVAMENTE?");
            string confirmacao = Console.ReadLine();
            if (confirmacao == "S" || confirmacao == "s")
            {
                Console.Clear() ;
                EntradaDeValores();
            }
        }
    }
}