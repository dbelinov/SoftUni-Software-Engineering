using System;
using System.Collections.Generic;
using System.Linq;

/*
3
Fur Elise|Beethoven|A Minor
Moonlight Sonata|Beethoven|C# Minor
Clair de Lune|Debussy|C# Minor
Add|Sonata No.2|Chopin|B Minor
Add|Hungarian Rhapsody No.2|Liszt|C# Minor
Add|Fur Elise|Beethoven|C# Minor
Remove|Clair de Lune
ChangeKey|Moonlight Sonata|C# Major
Stop
*/

namespace _03.ThePianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }
    class Program
    {
        static void Main()
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < numberOfPieces; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split('|');
                string name = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];
                Piece piece = new Piece(name, composer, key);
                pieces.Add(piece);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arguments = command.Split('|');
                string name = arguments[1];
                bool pieceIsInCollection = PieceInCollection(pieces, name);
                switch (arguments[0])
                {
                    case "Add":
                        string composer = arguments[2];
                        string key = arguments[3];
                        if (!pieceIsInCollection)
                        {
                            Piece piece = new Piece(name, composer, key);
                            pieces.Add(piece);
                            Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        Piece foundPiece = pieces.FirstOrDefault(x => x.Name == name);
                        if (pieceIsInCollection)
                        {
                            pieces.Remove(foundPiece);
                            Console.WriteLine($"Successfully removed {name}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = arguments[2];
                        Piece pieceInCollection = pieces.FirstOrDefault(x => x.Name == name);
                        if (pieceInCollection != null)
                        {
                            pieceInCollection.Key = newKey;
                            Console.WriteLine($"Changed the key of {name} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                        }
                        break;
                }
            }

            foreach (Piece piece in pieces)
            {
                Console.WriteLine(piece);
            }
        }

        private static bool PieceInCollection(List<Piece> pieces, string nameToEdit)
        {
            Piece pieceIsInCollection = pieces.FirstOrDefault(x => x.Name == nameToEdit);
            if (pieceIsInCollection == null)
                return false;
            return true;
        }
    }
}