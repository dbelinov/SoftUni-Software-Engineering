using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._FancyBarcodes
{
    class Product
    {
        public Product(string barcode)
        {
            Barcode = barcode;
            Group = "00";
        }

        public string Barcode { get; set; }
        public string Group { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@][#]{1,}[A-Z][A-Za-z0-9]{4,}[A-Z][@][#]{1,}";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                if (Regex.IsMatch(barcode, pattern))
                {
                    Product product = new Product(barcode);
                    string group = string.Empty;
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        char current = barcode[j];
                        if (Char.IsNumber(current))
                        {
                            group += current;
                        }
                    }
                    
                    if (group != string.Empty)
                    { 
                        product.Group = group;
                    }

                    Console.WriteLine($"Product group: {product.Group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }

            
            
        }
    }
}