using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Polinom3List("2 3 4 5 1 2 3 4 0 3 2 4"); 
            var p2 = new Polinom3List("3 4 5 3 4 1 4 2 0 3 2 1");

            Console.WriteLine(p1.ToString() + " " + "это просто п1");
            Console.WriteLine(p2.ToString() + " " + "это просто п2");


            p2.Value(1, 1, 2);
            Console.WriteLine(p2.Value(1, 1, 2) + " " + "значение п2 после подстановки (1,1,2)");

            p2.Delete(4, 5, 1);
            Console.WriteLine(p2 + " " + "п2 после удаления элемента с (4, 5, 1)");

            p1.Add(p2);
            Console.WriteLine(p1 + " " + "после прибавления п2");

            p2.Derivate(2);
            Console.WriteLine(p2.ToString() + " " + "п2 после взятия производной от 2 члена");

            Console.ReadKey();
        }
    }
}
