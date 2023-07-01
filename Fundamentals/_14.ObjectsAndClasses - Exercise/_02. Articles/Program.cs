using System;

/*
some title, some content, some author
3
Edit: better content
ChangeAuthor:  better author
Rename: better title
*/

namespace _02._Articles
{
    class Program
    {
        static void Main()
        {
            string[] arguments = Console.ReadLine().Split(", ");
            string startingTitle = arguments[0];
            string startingContent = arguments[1];
            string startingAuthor = arguments[2];

            Article article = new Article(startingTitle, startingContent, startingAuthor);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                switch (tokens[0])
                {
                    case "Edit":
                        string newContent = tokens[1];
                        article.Content = newContent;
                        break;
                    case "ChangeAuthor":
                        string newAuthor = tokens[1];
                        article.Author = newAuthor;
                        break;
                    case "Rename":
                        string newTitle = tokens[1];
                        article.Title = newTitle;
                        break;
                }
            }

            Console.WriteLine(article);
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