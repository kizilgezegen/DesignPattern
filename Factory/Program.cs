using System;
using static Factory.LoggerFactory;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var cusManager = new CustomerManager(new MailFactory());

            cusManager.Save();

            Console.ReadLine();
        }
    }

    public interface IFactory<T>
    {
        T Create();
    }

    public class LoggerFactory : IFactory<ILogger>
    {
        public ILogger Create()
        {
            return new HbLogger();
        }
    }

    public class MailFactory : IFactory<IMail>
    {
        public IMail Create()
        {
            return new SkypeMail();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface IMail
    {
        void SendMail();
    }

    public class HbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Hblogger!");
        }
    }

    public class SkypeMail : IMail
    {
        public void SendMail()
        {
            Console.WriteLine("Mail sended with Skype!");
        }
    }

    public class MbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Mblogger!");
        }
    }

    public class CustomerManager
    {
        private readonly IFactory<IMail> _factory;

        public CustomerManager(IFactory<IMail> factory)
        {
            _factory = factory;
        }

        public void Save()
        {
            Console.WriteLine(_factory.Create());
        }
    }
}
