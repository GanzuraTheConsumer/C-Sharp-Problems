using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public class Program
    {
        public static void Main()
        {
            var customer1 = new Customer("Steve");
            customer1.AddOrder(new Order(123));
            customer1.AddOrder(new Order(234));
            customer1.AddOrder(new Order(345));

            var customer2 = new Customer("Eric");
            customer2.AddOrder(new Order(100));
            customer2.AddOrder(new Order(200));
            customer2.AddOrder(new Order(300, DateTime.Parse("7/1/2014")));

            var customers = new List<Customer>() { customer1, customer2 };

            // print customers
            var orders = new List<Order>();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine("Orders:");

                for (int i = 0; i < customer.ViewOrders.Count(); i++)
                {
                    Console.WriteLine($"{customer.ViewOrders[i].OrderNumber}, placed at {customer.ViewOrders[i].OrderDate}");
                }
            }
            Console.WriteLine($"Customer 1 Order Count: {customer1.ViewOrders.Count()}");
            Console.WriteLine($"Customer 2 Order Count: {customer2.ViewOrders.Count()}");
        }
    }

    public class Customer
    {
        public string Name { get; private set; }
        private List<Order> Orders { get; set; } = new List<Order>();
        public List<Order> ViewOrders { get { return Orders; } }

        public Customer(string _name)
        {
            Name = _name;
        }

        public void AddOrder(Order order)
        {
            if (order == null || order.OrderNumber == -404) return;
            for (var i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderNumber == order.OrderNumber) Orders.Remove(Orders[i]);
            }
            Orders.Add(order);
        }
    }

    public class Order
    {
        public Order(int _orderNumber, DateTime _orderDate = default(DateTime))
        {
            if (_orderDate == default(DateTime))
            {
                _orderDate = DateTime.Now;
            }

            OrderDate = _orderDate;

            if (! IsTimeFuture(_orderDate))
            {
                OrderNumber = _orderNumber;
            }
        }

        private Boolean IsTimeFuture(DateTime _dateTime)
        {
            TimeSpan TimeDifference = DateTime.Now - _dateTime;

            if(TimeDifference.TotalSeconds < 0)
            {
                return true;
            } else { return false; }
        }

        public int OrderNumber { get; private set; } = -404;
        public DateTime OrderDate = new DateTime();
    }
}
