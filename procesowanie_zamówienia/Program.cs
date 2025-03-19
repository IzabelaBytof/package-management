class Program
{
    static List<Order> orders = new List<Order>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Utwórz zamówienie");
            Console.WriteLine("2. Przekaż do magazynu");
            Console.WriteLine("3. Przekaż do wysyłki");
            Console.WriteLine("4. Przegląd zamówień");
            Console.WriteLine("5. Wyjście");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    CreateOrder();
                    break;
                case "2":
                    MoveToWarehouse();
                    break;
                case "3":
                    MoveToShipping();
                    break;
                case "4":
                    ShowOrders();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Naciśnij Enter, aby kontynuować.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CreateOrder()
    {
        string product;
        do
        {
            Console.Write("Nazwa produktu: ");
            product = Console.ReadLine().Trim();
        } while (string.IsNullOrWhiteSpace(product));

        decimal amount;
        do
        {
            Console.Write("Kwota zamówienia: ");
        } while (!decimal.TryParse(Console.ReadLine(), out amount));

        string customerType;
        do
        {
            Console.Write("Typ klienta (Firma/Osoba Fizyczna): ");
            customerType = Console.ReadLine().Trim();
        } while (string.IsNullOrWhiteSpace(customerType));

        string address;
        do
        {
            Console.Write("Adres dostawy: ");
            address = Console.ReadLine().Trim();
        } while (string.IsNullOrWhiteSpace(address));

        string paymentMethod;
        do
        {
            Console.Write("Sposób płatności (Karta/Gotówka przy odbiorze): ");
            paymentMethod = Console.ReadLine().Trim().ToLower();
        } while (string.IsNullOrWhiteSpace(paymentMethod));

        if (paymentMethod.Contains("gotowka") || paymentMethod.Contains("gotówka"))
        {
            paymentMethod = "Gotówka przy odbiorze";
        }
        else
        {
            paymentMethod = "Karta";
        }

        Order order = new Order(product, amount, customerType, address, paymentMethod);
        orders.Add(order);
        Console.WriteLine("Zamówienie utworzone! Naciśnij Enter, aby kontynuować.");
        Console.ReadLine();
    }

    static void MoveToWarehouse()
    {
        Order order = GetOrder();
        if (order == null) return;

        if (order.Amount >= 2500 && order.PaymentMethod == "Gotówka przy odbiorze")
        {
            order.Status = OrderStatus.ReturnedToCustomer;
            Console.WriteLine("Kwota zamowienia powyżej 2500zł, sposób płatności: gotówka - niedostępny. Zamówienie zwrócone do klienta.");
        }
        else
        {
            order.Status = OrderStatus.InWarehouse;
            Console.WriteLine("Zamówienie przekazane do magazynu.");
        }
        Console.ReadLine();
    }

    static void MoveToShipping()
    {
        Order order = GetOrder();
        if (order == null) return;

        if (string.IsNullOrWhiteSpace(order.Address))
        {
            order.Status = OrderStatus.Error;
            Console.WriteLine("Błąd: Brak adresu dostawy.");
        }
        else
        {
            order.Status = OrderStatus.InShipping;
            Console.WriteLine("Zamówienie przekazane do wysyłki.");
            order.Status = OrderStatus.Sent;
            Console.WriteLine("Zamówienie zostało wysłane.");
        }
        Console.ReadLine();
    }

    static void ShowOrders()
    {
        Console.WriteLine("Lista zamówień:");
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }
        Console.WriteLine("Naciśnij Enter, aby kontynuować.");
        Console.ReadLine();
    }

    static Order GetOrder()
    {
        string product;
        do
        {
            Console.Write("Podaj nazwę produktu zamówienia: ");
            product = Console.ReadLine().Trim();
        } while (string.IsNullOrWhiteSpace(product));

        foreach (Order order in orders)
        {
            if (order.ProductName.ToLower() == product.ToLower())
            {
                return order;
            }
        }
        Console.WriteLine("Nie znaleziono zamówienia.");
        Console.ReadLine();
        return null;
    }
}