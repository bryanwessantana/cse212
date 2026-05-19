using System;
using System.Collections.Generic;

public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // Created a set to keep track of letters we've seen so far
        HashSet<char> seenLetters = new HashSet<char>();

        foreach (var letter in text) {
            // If Add returns false, it means the letter was already in the set, so we have a duplicate
            if (!seenLetters.Add(letter)) {
                return false; 
            }
        }

        // If we finish the loop without finding duplicates, all letters are unique
        return true;
    }
}