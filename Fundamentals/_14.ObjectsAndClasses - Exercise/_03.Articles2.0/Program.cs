using System;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ");
                string title = arguments[0];
                string content = arguments[1];
                string author = arguments[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
    
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}