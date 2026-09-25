using System;
using System.Collections.Generic;
using ExampleProtected;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("---Працюємо із наслідуванням---");

// Телефони
Device iPhone18ProMax =
    new Smartphone(brand: "Apple", model: "18 Pro Max", price: 84999, cpu: "A20 Pro", memory: "12 Гб", storage: "1 Тб", screenSize: 6.9F);
Device GalaxyS24Ultra =
    new Smartphone(brand: "Samsung", model: "Galaxy S24 Ultra", price: 79999, cpu: "Snapdragon 8 Gen 3", memory: "16 Гб", storage: "1 Тб", screenSize: 6.8F);
Device NokiaG22 =
    new Smartphone(brand: "Nokia", model: "G22", price: 4999, cpu: "MediaTek Helio G37", memory: "4 Гб", storage: "64 Гб", screenSize: 6.5F);
Device XiaomiRedmiNote13Pro =
    new Smartphone(brand: "Xiaomi", model: "Redmi Note 13 Pro", price: 8999, cpu: "MediaTek Dimensity 6080+", memory: "8 Гб", storage: "256 Гб", screenSize: 6.67F);
Device PocoX5Pro =
    new Smartphone(brand: "Poco", model: "X5 Pro", price: 7999, cpu: "Snapdragon 778G", memory: "6 Гб", storage: "128 Гб", screenSize: 6.67F);
Device iPhone14ProMax =
    new Smartphone(brand: "Apple", model: "14 Pro Max", price: 35000, cpu: "A20 Pro", memory: "12 Гб", storage: "512 Гб", screenSize: 6.9F);

// Ноутбуки
Device hp860g9 =
    new Laptop(brand: "HP", model: "EliteBook 860 g9", price: 23400, cpu: "Intel Core i5", memory: "32 Гб", storage: "1 Тб", display: "16\"");
Device dellLatitude =
    new Laptop(brand: "Dell", model: "Latitude 5430", price: 28500, cpu: "Intel Core i7", memory: "16 Гб", storage: "512 Гб", display: "14\"");
Device lenovoThinkPad =
    new Laptop(brand: "Lenovo", model: "ThinkPad T14", price: 34000, cpu: "AMD Ryzen 7", memory: "16 Гб", storage: "512 Гб", display: "14\"");
Device asusTuf =
    new Laptop(brand: "ASUS", model: "TUF Gaming A15", price: 39999, cpu: "AMD Ryzen 5", memory: "16 Гб", storage: "512 Гб", display: "15.6\"");
Device macBookAir =
    new Laptop(brand: "Apple", model: "MacBook Air M2", price: 49999, cpu: "Apple M2", memory: "8 Гб", storage: "256 Гб", display: "13.6\"");

List<Device> allDevices = new() { iPhone18ProMax, GalaxyS24Ultra, NokiaG22, XiaomiRedmiNote13Pro, PocoX5Pro, iPhone14ProMax, hp860g9, dellLatitude, lenovoThinkPad, asusTuf, macBookAir };
List<Device> wishlist = new();

bool running = true;
while (running)
{
    Console.WriteLine("\n==================================");
    Console.WriteLine(" Список Товарів");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Переглянути список бажаного");
    Console.WriteLine("2. Додати товар до бажаного");
    Console.WriteLine("3. Видалити товар з бажаного");
    Console.WriteLine("4. Вихід");
    Console.Write("Оберіть дію (1-4): ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    // Спрощений та чистий switch
    switch (choice)
    {
        case "1":
            ShowWishlist();
            break;
        case "2":
            AddDevice();
            break;
        case "3":
            RemoveDevice();
            break;
        case "4":
            running = false;
            Console.WriteLine("Роботу програми завершено.");
            break;
        default:
            Console.WriteLine("Невідома команда. Будь ласка, оберіть від 1 до 4.");
            break;
    }
}

// --- Локальні функції для спрощення логіки ---

void ShowWishlist()
{
    Console.WriteLine("--- Ваш список бажаного ---");
    if (wishlist.Count == 0) { Console.WriteLine("Список порожній."); return; }

    for (int i = 0; i < wishlist.Count; i++)
        Console.WriteLine($"{i + 1}. {wishlist[i]}");
}

void AddDevice()
{
    Console.WriteLine("--- Доступні товари ---");
    for (int i = 0; i < allDevices.Count; i++)
        Console.WriteLine($"{i + 1}. {allDevices[i]}");

    Console.Write("Введіть номер товару для додавання: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= allDevices.Count)
    {
        var device = allDevices[idx - 1];
        if (!wishlist.Contains(device))
        {
            wishlist.Add(device);
            Console.WriteLine("Успішно! Товар додано до списку бажаного.");
        }
        else Console.WriteLine("Цей товар вже є у вашому списку бажаного.");
    }
    else Console.WriteLine("Помилка: невірний номер товару.");
}

void RemoveDevice()
{
    if (wishlist.Count == 0) { Console.WriteLine("Список порожній, нічого видаляти."); return; }

    Console.WriteLine("--- Ваші бажані товари ---");
    for (int i = 0; i < wishlist.Count; i++)
        Console.WriteLine($"{i + 1}. {wishlist[i]}");

    Console.Write("Введіть номер товару для видалення: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= wishlist.Count)
    {
        wishlist.RemoveAt(idx - 1);
        Console.WriteLine("Товар видалено зі списку.");
    }
    else Console.WriteLine("Помилка: невірний номер товару.");
}