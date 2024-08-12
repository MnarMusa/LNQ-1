using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

public class ListGenerators
{
    public static List<Product> GenerateProducts()
    {
        return new List<Product>
        {
            new Product { ProductID = 1, ProductName = "apple", Category = "Fruits", UnitPrice = 1.20m, UnitsInStock = 0 },
            new Product { ProductID = 2, ProductName = "Abacus", Category = "electronic", UnitPrice = 0.80m, UnitsInStock = 10 },
            new Product { ProductID = 3, ProductName = "branch", Category = "tree", UnitPrice = 3.50m, UnitsInStock = 5 },
            new Product { ProductID = 4, ProductName = "Blueberry", Category = "Fruits", UnitPrice = 4.00m, UnitsInStock = 8 },
            new Product { ProductID = 5, ProductName = "Clover", Category = "tree", UnitPrice = 2.50m, UnitsInStock = 15 },
            new Product { ProductID = 6, ProductName = "cherry", Category = "Fruits", UnitPrice = 1.10m, UnitsInStock = 12 }
        };
    }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = ListGenerators.GenerateProducts();
        string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] wordsArr = { "apple", "Abacus", "branch", "Blueberry", "Clover", "cherry" };

        // Restriction Operators

        // 1. Find all products that are out of stock
        var outOfStockProducts = products.Where(p => p.UnitsInStock == 0).ToList();
        Console.WriteLine("1. Products that are out of stock:");
        foreach (var product in outOfStockProducts)
        {
            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}");
        }
        Console.WriteLine();

        // 2. Find all products that are in stock and cost more than 3.00 per unit
        var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m).ToList();
        Console.WriteLine("2. Products that are in stock and cost more than 3.00 per unit:");
        foreach (var product in expensiveInStockProducts)
        {
            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, UnitPrice: {product.UnitPrice}");
        }
        Console.WriteLine();

        // 3. Returns digits whose name is shorter than their value
        var shortNamedDigits = digitsArr.Where((name, index) => name.Length < index).ToList();
        Console.WriteLine("3. Digits whose name is shorter than their value:");
        foreach (var digit in shortNamedDigits)
        {
            Console.WriteLine(digit);
        }
        Console.WriteLine();

        // Ordering Operators

        // 1. Sort a list of products by name
        var sortedByName = products.OrderBy(p => p.ProductName).ToList();
        Console.WriteLine("1. Products sorted by name:");
        foreach (var product in sortedByName)
        {
            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}");
        }
        Console.WriteLine();

        // 2. Use a custom comparer to do a case-insensitive sort of the words in an array
        var sortedCaseInsensitive = wordsArr.OrderBy(word => word, StringComparer.OrdinalIgnoreCase).ToList();
        Console.WriteLine("2. Words sorted case-insensitively:");
        foreach (var word in sortedCaseInsensitive)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();

        // 3. Sort a list of products by units in stock from highest to lowest
        var sortedByStock = products.OrderByDescending(p => p.UnitsInStock).ToList();
        Console.WriteLine("3. Products sorted by units in stock from highest to lowest:");
        foreach (var product in sortedByStock)
        {
            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
        }
        Console.WriteLine();

        // 4. Sort a list of digits first by length of their name, then alphabetically by the name itself
        var sortedDigits = digitsArr.OrderBy(d => d.Length).ThenBy(d => d).ToList();
        Console.WriteLine("4. Digits sorted by length of their name, then alphabetically:");
        foreach (var digit in sortedDigits)
        {
            Console.WriteLine(digit);
        }
        Console.WriteLine();

        // 5. Sort first by word length and then by a case-insensitive sort of the words in an array
        var sortedWords = wordsArr.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase).ToList();
        Console.WriteLine("5. Words sorted first by length and then case-insensitively:");
        foreach (var word in sortedWords)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();

        // 6. Sort a list of products, first by category, and then by unit price, from highest to lowest
        var sortedByCategoryAndPrice = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice).ToList();
        Console.WriteLine("6. Products sorted by category, then by unit price from highest to lowest:");
        foreach (var product in sortedByCategoryAndPrice)
        {
            Console.WriteLine($"ProductID: {product.ProductID}, Category: {product.Category}, ProductName: {product.ProductName}, UnitPrice: {product.UnitPrice}");
        }
        Console.WriteLine();

        // 7. Sort first by word length and then by a case-insensitive descending sort of the words in an array
        var sortedWordsDescending = wordsArr.OrderBy(word => word.Length).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase).ToList();
        Console.WriteLine("7. Words sorted first by length and then case-insensitively in descending order:");
        foreach (var word in sortedWordsDescending)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();

        // 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array
        var filteredAndReversedDigits = digitsArr.Where(d => d.Length > 1 && d[1] == 'i').Reverse().ToList();
        Console.WriteLine("8. Digits whose second letter is 'i', reversed from the original order:");
        foreach (var digit in filteredAndReversedDigits)
        {
            Console.WriteLine(digit);
        }
    }
}
