using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine(₱"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }

    public bool HasEnoughStock(int qty)
    {
        return qty <= RemainingStock;
    }

    public double GetItemTotal(int qty)
    {
        return Price * qty;
    }

    public void DeductStock(int qty)
    {
        RemainingStock -= qty;
    }
}

class CartItem
{
    public Product Product;
    public int Quantity;
    public double Subtotal;
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Hersheys", Price = 300, RemainingStock = 35 },
            new Product { Id = 2, Name = "Kitkat", Price = 100, RemainingStock = 24  },
            new Product { Id = 3, Name = "Toblerone", Price = 190, RemainingStock = 10  },
            new Product { Id = 4, Name = "Snickers", Price = 150, RemainingStock = 36 }
        };

        CartItem[] cart = new CartItem[10];
        int cartCount = 0;
        bool continueShopping = true;

        while (continueShopping)
        {
            Console.WriteLine("\n=== STORE MENU ===");
            foreach (var p in products)
            {
                p.DisplayProduct();
            }

            Console.Write("Enter product number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > products.Length)
            {
                Console.WriteLine("Invalid product number.");
                continue;
            }

            Product selected = products[choice - 1];

            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("Product is out of stock.");
                continue;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("Not enough stock available.");
                continue;
            }

            bool found = false;
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selected.Id)
                {
                    cart[i].Quantity += qty;
                    cart[i].Subtotal = cart[i].Product.GetItemTotal(cart[i].Quantity);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full.");
                    continue;
                }

                cart[cartCount] = new CartItem
                {
                    Product = selected,
                    Quantity = qty,
                    Subtotal = selected.GetItemTotal(qty)
                };
                cartCount++;
            }

            selected.DeductStock(qty);
            Console.WriteLine("Item added to cart.");

            Console.Write("Add more items? (Y/N): ");
            string input = Console.ReadLine().ToUpper();
            continueShopping = input == "Y";
        }

        double grandTotal = 0;
        Console.WriteLine("\n=== RECEIPT ===");

        for (int i = 0; i < cartCount; i++)
        {
            Console.WriteLine($"{cart[i].Product.Name} x {cart[i].Quantity} = ₱{cart[i].Subtotal}");
            grandTotal += cart[i].Subtotal;
        }

        Console.WriteLine(₱"Grand Total: ₱{grandTotal}");

        double discount = 0;
        if (grandTotal >= 5000)
        {
            discount = grandTotal * 0.10;
            Console.WriteLine(₱"Discount: ₱{discount}");
        }

        double finalTotal = grandTotal - discount;
        Console.WriteLine(₱"Final Total: ₱{finalTotal}");

        Console.WriteLine("\n=== UPDATED STOCK ===");
        foreach (var p in products)
        {
            Console.WriteLine(₱"{p.Name}: {p.RemainingStock} left");
        }
    }
}
