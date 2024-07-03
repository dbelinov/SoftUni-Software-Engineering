using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            System.Globalization.CultureInfo customCulture =
                (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ",";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            using var context = new BookShopContext();
            // DbInitializer.ResetDatabase(context);

            Console.WriteLine(RemoveBooks(context));
            IncreasePrices(context);
        }

        // public static string GetBooksByAuthor(BookShopContext context, string command)
        // {
        //     if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
        //     {
        //         return string.Empty;
        //     }
        //
        //     return string.Join(Environment.NewLine, context.Books
        //         .Where(b => b.AgeRestriction == ageRestriction)
        //         .Select(b => b.Title)
        //         .OrderBy(b => b));
        //
        // }

        public static string GetGoldenBooks(BookShopContext context)
            => string.Join(Environment.NewLine, context.Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title));

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price);


            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId);
            
            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            
            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ");
            
            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b);
            
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var target = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < target)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price });

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            
            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = $"{a.FirstName} {a.LastName}" })
                .OrderBy(a => a.FullName);

            StringBuilder sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }
            
            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
            => string.Join(Environment.NewLine, context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b));

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName });

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
            
            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books.Count(b => b.Title.Length > lengthCheck);

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Select(a => new { a.FirstName, a.LastName, Copies = a.Books.Sum(b => b.Copies) })
                .OrderByDescending(a => a.Copies);
            
            return string.Join(Environment.NewLine, authorsCopies.Select(a => $"{a.FirstName} {a.LastName} - {a.Copies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name);
            
            return string.Join(Environment.NewLine, categoryProfit.Select(c => $"{c.Name} ${c.Profit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")
                })
                .OrderBy(c => c.Name);

            StringBuilder sb = new StringBuilder();
            foreach (var categoryBook in categoryBooks)
            {
                sb.AppendLine($"--{categoryBook.Name}");
                foreach (var book in categoryBook.Books)
                {
                    sb.AppendLine(book);
                }
            }
            
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int count = books.Count();
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            context.SaveChanges();

            return count;
        }
    }
}