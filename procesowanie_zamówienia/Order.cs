class Order
{
    public string ProductName { get; }
    public decimal Amount { get; }
    public string CustomerType { get; }
    public string Address { get; }
    public string PaymentMethod { get; }
    public OrderStatus Status { get; set; }

    public Order(string productName, decimal amount, string customerType, string address, string paymentMethod)
    {
        ProductName = productName;
        Amount = amount;
        CustomerType = customerType;
        Address = address;
        PaymentMethod = paymentMethod;
        Status = OrderStatus.New;
    }

    public override string ToString()
    {
        return $"Produkt: {ProductName}, Kwota: {Amount}, Klient: {CustomerType}, Adres: {Address}, Płatność: {PaymentMethod}, Status: {Status}";
    }
}