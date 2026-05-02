using System;

namespace SolidPrinciplesProject
{
    // SRP: Order class handles only order data
    class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public Order(int id, double amount)
        {
            Id = id;
            Amount = amount;
        }
    }

    // ISP: Small interface for payment
    interface IPayment
    {
        void Pay(double amount);
    }

    // LSP + OCP: Different payment types can replace each other
    // New payment methods can be added without modifying existing code
    class CreditCardPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Paid Rs " + amount + " using Credit Card");
        }
    }

    class UpiPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Paid Rs " + amount + " using UPI");
        }
    }

    class CashPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Paid Rs " + amount + " using Cash");
        }
    }

    // ISP: Separate interface for invoice
    interface IInvoice
    {
        void GenerateInvoice(Order order);
    }

    // SRP: Only responsible for invoice generation
    class InvoiceGenerator : IInvoice
    {
        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("\n----- Invoice -----");
            Console.WriteLine("Order ID: " + order.Id);
            Console.WriteLine("Amount: Rs " + order.Amount);
            Console.WriteLine("-------------------");
        }
    }

    // DIP: High-level class depends on abstraction (IPayment)
    class OrderProcessor
    {
        private IPayment _payment;
        private IInvoice _invoice;

        public OrderProcessor(IPayment payment, IInvoice invoice)
        {
            _payment = payment;
            _invoice = invoice;
        }

        public void Process(Order order)
        {
            Console.WriteLine("\nProcessing Order...");

            _payment.Pay(order.Amount);
            _invoice.GenerateInvoice(order);
        }
    }

    // ==============================
    // Main Program with USER INPUT
    // ==============================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Welcome to Smart Order System =====");

            // Taking Order ID
            Console.Write("\nEnter Order ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            // Taking Amount
            Console.Write("Enter Order Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Order order = new Order(id, amount);

            // Payment choice
            Console.WriteLine("\nChoose Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. UPI");
            Console.WriteLine("3. Cash");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            IPayment payment;

            // Selecting payment type (OCP in action)
            switch (choice)
            {
                case 1:
                    payment = new CreditCardPayment();
                    break;
                case 2:
                    payment = new UpiPayment();
                    break;
                case 3:
                    payment = new CashPayment();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Defaulting to Cash.");
                    payment = new CashPayment();
                    break;
            }

            IInvoice invoice = new InvoiceGenerator();

            // Processing order (DIP)
            OrderProcessor processor = new OrderProcessor(payment, invoice);
            processor.Process(order);

            Console.WriteLine("\nThank you for using the system!");
            Console.ReadLine();
        }
    }
}