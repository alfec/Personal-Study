using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var variavel = "Beleza?";
            //Console.WriteLine(variavel);

            //Console.WriteLine("Fala doido");

            //int x = 33;
            //Console.WriteLine(x);

            //var d = 100.50; //VARIAVEL LOCAL
            //Console.WriteLine(d+x);

            //Int32 Y = 20;
            //Console.WriteLine(Y);

            //int i = 100;
            //uint u = (uint)i;
            //Console.Write(i);

            //int nulo;
            //Console.WriteLine(nulo);

            //CLASSES ANONIMAS SÃO READ-ONLY NAO DA PRA ALTERAR SEU VALOR
            int ini;
            ini = Convert.ToInt32(Console.ReadLine());
            int fim;
            fim = Convert.ToInt32(Console.ReadLine());


            DateTime dataUm = Convert.ToDateTime(ini);
            DateTime dataDois = Convert.ToDateTime(fim);

            TimeSpan ts = dataDois.Subtract(dataUm);

            Console.WriteLine("A duração foi de: ", ts.TotalHours);
        }
    }
}
