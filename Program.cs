namespace Design_Patterns_Facade_CSHARP
{
    // Примитивная работа маркетплейсов

    class ProviderCommunication
    {
        public void Recive()
        {
            Console.WriteLine("Получение продукции от производителя");
        }

        public void Payment()
        {
            Console.WriteLine("Оплата поставщику с удержанием комиссии за продажу продукции");
        }
    }

    class Site
    {
        public void Placement()
        {
            Console.WriteLine("Размещение на сайте");
        }

        public void Del()
        {
            Console.WriteLine("Удаление с сайта");
        }
    }

    class Database
    {
        public void Insert()
        {
            Console.WriteLine("Запись в базу данных");
        }

        public void Del() => Console.WriteLine("Удаление");
    }

    // Основной класс
    class MarketPlace
    {
        private ProviderCommunication providerCommunication;
        private Site site;
        private Database database;

        // Инкапсулируем все в одном классе(разные классы теперь хранятся в 1 классе)
        public MarketPlace()
        {
            providerCommunication = new ProviderCommunication();
            site = new Site();
            database = new Database();
        }
        // Метод при поступлении товара на Торговую площадку
        public void ProductReceipt()
        {
            providerCommunication.Recive();
            site.Placement();
            database.Insert();
        }

        public void ProductRealease()
        {
            providerCommunication.Payment();
            site.Del();
            database.Del();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MarketPlace marketPlace = new MarketPlace();

            marketPlace.ProductReceipt();

            Console.WriteLine(new string('-', 20));

            marketPlace.ProductRealease();
        }
    }
}