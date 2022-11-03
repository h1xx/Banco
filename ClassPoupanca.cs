using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ClassPoupanca
    {
        public double SaldoPoupanca { get; set; }
        public double Saldo { get; set; }
        public DateTime dataDeposito { get; set; }

        public void DepositoPoupanca()
        {
            SaldoPoupanca = 0;
            Saldo = 15000;
            double SaldoTransfPoupanca = 0;
            Console.WriteLine($"Saldo {Saldo}");
            Console.WriteLine("Valor para depósito: ");
            SaldoTransfPoupanca = Convert.ToDouble(Console.ReadLine());
            var menuOption = true;
            while (menuOption)
            {
                if (SaldoTransfPoupanca > Saldo)
                {
                    Console.WriteLine("Saldo insuficiente, tente novamente!");
                    break;
                }
                else if (SaldoTransfPoupanca <= Saldo)
                {
                    Saldo = Saldo - SaldoTransfPoupanca;
                    SaldoPoupanca = SaldoTransfPoupanca;
                    dataDeposito = DateTime.Now;
                    Console.WriteLine($"Valor depositado com sucesso! Seu novo saldo de poupança é de R${SaldoPoupanca}\nSaldo conta: R${Saldo}");
                    menuOption = false;
                }
            }
        }
        public void ResgatePoupanca()
        {
            double juros = 0;
            double taxajuros = 0.0216666666666667;
            double ResgatePoupanca = 0;
            var menuOption = true;
            Console.WriteLine(SaldoPoupanca);
            Console.WriteLine("Valor que deseja resgatar: ");
            ResgatePoupanca = Convert.ToDouble(Console.ReadLine());
            if (ResgatePoupanca > SaldoPoupanca)
            {
                Console.WriteLine("Saldo insuficiente, tente novamente!");

            }
            else
            {
                SaldoPoupanca = SaldoPoupanca - ResgatePoupanca;
                Saldo = ResgatePoupanca + Saldo;
                DateTime dataResgate = DateTime.Now;
                int dataJuros = 0;
                dataJuros = (dataResgate.Subtract(dataDeposito).Days);
                juros = taxajuros * (dataJuros < 0 ? dataJuros * (-1) : dataJuros);
                Saldo = Saldo + juros;
                Console.WriteLine($"Seu saldo é de R${Saldo} e você recebeu um juros de R${juros}");
                Thread.Sleep(1000);
            }
        }
    }
}
