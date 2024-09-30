using System;
using System.Collections.Generic;

namespace Uppgift_004_04
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Välkommen till parenteskontrollprogrammet!");
            CheckParanthesis();
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey(); // Håller fönstret öppet
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("Ange en sträng för att kontrollera om den är välformad:");
            string input = Console.ReadLine();

            if (IsWellFormed(input))
            {
                Console.WriteLine("Strängen är välformad.");
            }
            else
            {
                Console.WriteLine("Strängen är inte välformad.");
            }
        }

        static bool IsWellFormed(string input)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> matchingParentheses = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };

            foreach (char c in input)
            {
                // Kolla efter öppnande parenteser
                if (matchingParentheses.ContainsKey(c))
                {
                    stack.Push(c); // Lägg till på stacken
                }
                // Kolla efter stängande parenteser
                else if (matchingParentheses.ContainsValue(c))
                {
                    if (stack.Count == 0) // Ingen öppnande parentes att matcha
                    {
                        return false;
                    }

                    char openingParenthesis = stack.Pop(); // Ta bort senaste öppna parentesen
                    if (matchingParentheses[openingParenthesis] != c)
                    {
                        return false; // Det är inte den rätta matchningen
                    }
                }
            }

            // Om stacken är tom är alla parenteser välformade
            return stack.Count == 0;
        }
    }
}