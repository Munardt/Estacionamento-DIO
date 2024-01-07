using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesafioFundamentos.Models
{

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo que irá estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa {placa} foi estacionado!");
            LimparConsole();
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover da vaga:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido da lista de estacionados e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

            LimparConsole();
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            LimparConsole();
        }

        private static void LimparConsole()
        {
            Console.WriteLine("Pressione ENTER para ir para a prróxima opção...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Digite o valor inicial do estacionamento:");
            decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o valor por hora do estacionamento:");
            decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            int opcao;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Remover veículo");
                Console.WriteLine("3. Listar veículos");
                Console.WriteLine("4. Encerrar");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        estacionamento.AdicionarVeiculo();
                        break;
                    case 2:
                        estacionamento.RemoverVeiculo();
                        break;
                    case 3:
                        estacionamento.ListarVeiculos();
                        break;
                    case 4:
                        Console.WriteLine("Encerrando o programa em 5 segundos...");
                        Thread.Sleep(5000); 
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 4);
        }
    }
}
