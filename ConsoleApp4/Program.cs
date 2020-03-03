using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(factorial_Recursion(4));
            var repo = new RepositoryBank();
            var cuenta = repo.Get(1);
            //cuenta. no contiene sus propiedades
            repo.Save(new BankAccount());
            var repo2 = new Repository<BankAccount>();
            var cuenta2 = repo2.Get(1);
            //cuenta2.NumeroDeCuenta si lo contiene
            var repo3 = new Repository<Customer>();
            var custom = repo3.Get(1);
        }
        class RepositoryBank
        {
            public virtual ISerializable Get(int id)
            {
                return new BankAccount();
            }
            public void Save(ISerializable obj)
            {
            }
            public void Delete(ISerializable obj)
            {
            }
        }
        class RepositoryCustomer : RepositoryBank
        {
            public override ISerializable Get(int id)
            {
                return new Customer();
            }
        }
        class Repository<T> where T : ISerializable
        {
            List<T> source = new List<T>();
            public T Get(int id)
            {
                return source.FirstOrDefault();
            }
            public void Save(T obj)
            {
            }
            public void Delete(T obj)
            {
            }
        }
        class BankAccount : ISerializable
        {
            public int NumeroDeCuenta { get; set; }
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
        }
        class Customer : ISerializable
        {
            public int NumeroDeCliente { get; set; }
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
        }
        public static double factorial_Recursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial_Recursion(number - 1);
        }
    }
}