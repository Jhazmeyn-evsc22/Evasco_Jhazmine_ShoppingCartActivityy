using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
    public string Category;
}

class CartItem
{
    public Product Product;
    public int Quantity;
}

class Order
{
    public int ReceiptNumber;
    public DateTime Date;
    public List<CartItem> Items;
    public double Total;
    public double Payment;
    public double Change;
}

class Program
{
    static List<Product> products = new List<Product>();
    static List<CartItem> cart = new List<CartItem>();
    static List<Order> orderHistory = new List<Order>();

    static int receiptCounter = 1;

    static void Main()
    {
        SeedProducts();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SHOPPING SYSTEM ===");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.WriteLine("4. Cart Menu");
            Console.WriteLine("5. View Order History");
            Console.WriteLine("6. Exit");

            int choice = GetIntInput("Choose: ");

            switch (choice)
            {
                case 1: ShowProducts(); break;
                case 2: SearchProduct(); break;
                case 3: FilterCategory(); break;
                case 4: CartMenu(); break;
                case 5: ShowHistory(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); Pause(); break;
            }
        }
    }

    // ================= PRODUCTS =================

    static void SeedProducts()
    {
        products.Add(new Product { Id = 1, Name = "Rice", Price = 50, Stock = 20, Category = "Food" });
        products.Add(new Product { Id = 2, Name = "Mouse", Price = 500, Stock = 10, Category = "Electronics" });
        products.Add(new Product { Id = 3, Name = "Keyboard", Price = 800, Stock = 5, Category = "Electronics" });
        products.Add(new Product { Id = 4, Name = "Shirt", Price = 300, Stock = 15, Category = "Clothing" });
    }

    static void ShowProducts()
    {
        Console.Clear();
        Console.WriteLine("=== PRODUCTS ===");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}. {p.Name} - PHP {p.Price} - Stock: {p.Stock} - {p.Category}");
        }

        AddToCartPrompt();
    }

    static void SearchProduct()
    {
        Console.Write("Search: ");
        string input = Console.ReadLine().ToLower();

        var results = products.Where(p => p.Name.ToLower().Contains(input));

        foreach (var p in results)
        {
            Console.WriteLine($"{p.Id}. {p.Name} - PHP {p.Price} - Stock: {p.Stock}");
        }

        AddToCartPrompt();
    }

    static void FilterCategory()
    {
        Console.WriteLine("1. Food\n2. Electronics\n3. Clothing");
        string cat = Console.ReadLine();

        string selected = cat == "1" ? "Food" :
                          cat == "2" ? "Electronics" : "Clothing";

        var results = products.Where(p => p.Category == selected);

        foreach (var p in results)
        {
            Console.WriteLine($"{p.Id}. {p.Name} - PHP {p.Price}");
        }

        AddToCartPrompt();
    }

    // ================= CART =================

    static void AddToCartPrompt()
    {
        string choice = GetYN("Add item to cart? (Y/N): ");
        if (choice == "Y")
        {
            int id = GetIntInput("Enter product ID: ");
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine("Invalid product.");
                Pause();
                return;
            }

            int qty = GetIntInput("Enter quantity: ");

            if (qty > product.Stock)
            {
                Console.WriteLine("Not enough stock.");
                Pause();
                return;
            }

            var existing = cart.FirstOrDefault(c => c.Product.Id == id);

            if (existing != null)
                existing.Quantity += qty;
            else
                cart.Add(new CartItem { Product = product, Quantity = qty });

            Console.WriteLine("Added to cart!");
            Pause();
        }
    }

    static void CartMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CART MENU ===");
            Console.WriteLine("1. View Cart");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Clear Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Back");

            int choice = GetIntInput("Choose: ");

            switch (choice)
            {
                case 1: ViewCart(); break;
                case 2: RemoveItem(); break;
                case 3: UpdateQuantity(); break;
                case 4: cart.Clear(); Console.WriteLine("Cart cleared."); Pause(); break;
                case 5: Checkout(); return;
                case 6: return;
            }
        }
    }

    static void ViewCart()
    {
        Console.WriteLine("=== YOUR CART ===");

        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            foreach (var c in cart)
            {
                Console.WriteLine($"{c.Product.Name} x{c.Quantity} = PHP {c.Quantity * c.Product.Price}");
            }
        }

        Pause();
    }

    static void RemoveItem()
    {
        int id = GetIntInput("Enter product ID to remove: ");
        cart.RemoveAll(c => c.Product.Id == id);
        Console.WriteLine("Item removed.");
        Pause();
    }

    static void UpdateQuantity()
    {
        int id = GetIntInput("Enter product ID: ");
        var item = cart.FirstOrDefault(c => c.Product.Id == id);

        if (item == null)
        {
            Console.WriteLine("Item not found.");
            Pause();
            return;
        }

        int qty = GetIntInput("New quantity: ");

        if (qty <= 0 || qty > item.Product.Stock)
        {
            Console.WriteLine("Invalid quantity.");
        }
        else
        {
            item.Quantity = qty;
        }

        Pause();
    }

    // ================= CHECKOUT =================

    static void Checkout()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
            Pause();
            return;
        }

        double total = cart.Sum(c => c.Quantity * c.Product.Price);

        Console.WriteLine($"Total: PHP {total}");

        double payment;

        while (true)
        {
            Console.Write("Enter payment: ");
            if (double.TryParse(Console.ReadLine(), out payment))
            {
                if (payment >= total) break;
                else Console.WriteLine("Insufficient payment.");
            }
            else Console.WriteLine("Invalid input.");
        }

        double change = payment - total;

        // Deduct stock
        foreach (var item in cart)
        {
            item.Product.Stock -= item.Quantity;
        }

        // Receipt
        Console.WriteLine("\n=== RECEIPT ===");
        Console.WriteLine($"Receipt No: {receiptCounter.ToString("D4")}");
        Console.WriteLine($"Date: {DateTime.Now}");

        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Product.Name} x{item.Quantity} = PHP {item.Quantity * item.Product.Price}");
        }

        Console.WriteLine($"Total: PHP {total}");
        Console.WriteLine($"Payment: PHP {payment}");
        Console.WriteLine($"Change: PHP {change}");

        // Save order
        orderHistory.Add(new Order
        {
            ReceiptNumber = receiptCounter,
            Date = DateTime.Now,
            Items = new List<CartItem>(cart),
            Total = total,
            Payment = payment,
            Change = change
        });

        receiptCounter++;
        cart.Clear();

        // Low stock alert
        Console.WriteLine("\nLOW STOCK ALERT:");
        foreach (var p in products)
        {
            if (p.Stock <= 5)
            {
                Console.WriteLine($"{p.Name} has only {p.Stock} left.");
            }
        }

        Pause();
    }

    // ================= HISTORY =================

    static void ShowHistory()
    {
        Console.WriteLine("=== ORDER HISTORY ===");

        if (orderHistory.Count == 0)
        {
            Console.WriteLine("No orders yet.");
        }
        else
        {
            foreach (var o in orderHistory)
            {
                Console.WriteLine($"Receipt #{o.ReceiptNumber} - PHP {o.Total}");
            }
        }

        Pause();
    }

    // ================= UTIL =================

    static int GetIntInput(string msg)
    {
        int value;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid input.");
        }
    }

    static string GetYN(string msg)
    {
        string input;
        do
        {
            Console.Write(msg);
            input = Console.ReadLine().ToUpper();

            if (input != "Y" && input != "N")
                Console.WriteLine("Enter Y or N only.");

        } while (input != "Y" && input != "N");

        return input;
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
