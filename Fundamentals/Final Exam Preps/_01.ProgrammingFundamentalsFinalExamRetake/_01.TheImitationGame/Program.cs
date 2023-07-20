using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string instruction;
            while ((instruction = Console.ReadLine()) != "Decode")
            {
                string[] tokens = instruction.Split('|');
                List<char> messageAsArr = encryptedMessage.ToList();
                switch (tokens[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(tokens[1]);
                        for (int i = 0; i < numberOfLetters; i++)
                        {
                            char temp = messageAsArr[0];
                            messageAsArr.Remove(temp);
                            messageAsArr.Add(temp);
                        }

                        encryptedMessage = ConvertToString(messageAsArr);
                        break;
                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        string value = tokens[2];
                        encryptedMessage = encryptedMessage.Insert(index, value);
                        break;
                    case "ChangeAll":
                        char substring = char.Parse(tokens[1]);
                        char replacement = char.Parse(tokens[2]);
                        for (int i = 0; i < messageAsArr.Count; i++)
                        {
                            if (messageAsArr[i] == substring)
                            {
                                messageAsArr[i] = replacement;
                            }
                        }

                        encryptedMessage = ConvertToString(messageAsArr);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        private static string ConvertToString(List<char> messageAsArr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < messageAsArr.Count; i++)
            {
                sb.Append(messageAsArr[i]);
            }

            var encryptedMessage = sb.ToString();
            return encryptedMessage;
        }
    }
}