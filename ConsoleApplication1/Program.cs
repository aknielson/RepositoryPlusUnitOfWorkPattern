using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPlusUnitOfWorkPattern.EFData;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork())
            {
                var address = uow.Addresses.Get(1);
                var person = uow.People.Get(1);
                Console.ReadLine();
            }
        }
    }
}
