using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Ruslan", "zamaliev.07@gmail.com", 1000);
            customer.DisplayInfo();
            List<Product> products = new List<Product>()
            {
                new Product("Товар 1", 200)
            };
            customer.PlaceOrder(products);
            customer.DisplayInfo();
            Admin admin = new Admin("Admin User", "admin@gmail.com");
            admin.DisplayInfo(); 
            admin.ManageUsers(); 
        }
    }

    class Product
    {
        public string Name;
        public decimal Price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class User
    {
        public string Name;
        public string Email;

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public virtual void DisplayInfo() 
        {
            Console.WriteLine($"Имя: {Name}, Почта: {Email}");
        }
    }

    class Customer : User
    {
        public decimal Balance;

        public Customer(string name, string email, decimal balance) : base(name, email)
        {
            Balance = balance;
        }

        public void PlaceOrder(List<Product> products)
        {
            decimal totalCost = 0;
            foreach (var product in products)
            {
                totalCost += product.Price;
            }

            if (Balance >= totalCost)
            {
                Balance -= totalCost;
                Console.WriteLine("Заказ успешно оформлен!");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для оформления заказа.");
            }
        }

        public override void DisplayInfo() 
        {
            base.DisplayInfo();
            Console.WriteLine($"Баланс: {Balance}");
        }
    }

    class Admin : User
    {
        public Admin(string name, string email) : base(name, email) 
        {
        }

        public void ManageUsers()  
        {
            Console.WriteLine("Администратор управляет пользователями.");
        }

        public override void DisplayInfo()  
        {
            base.DisplayInfo();
            Console.WriteLine("Это администратор.");
        }
    }

}