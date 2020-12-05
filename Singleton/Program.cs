using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Anlık kullanıcı sayısı herkes için bi tanedir, kişi girdiğinde bir arttırılır. Yeniden tek bir sayı tutar. 
            //Bi şeyi bir kere üretip her zaman sabit kalacaksa bu şey singleton ile üretilir.

            var customerManager = CustomerManager.CreateSingleton();
            customerManager.Save();
        }
    }

    public class CustomerManager
    {
        static CustomerManager _cusManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateSingleton()
        {
            lock (_lockObject)
            {
                _cusManager = _cusManager ?? new CustomerManager();
            }

            return _cusManager;
        } 
         
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
