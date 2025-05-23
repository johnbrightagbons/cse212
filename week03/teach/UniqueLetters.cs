public static class UniqueLetters
{
    public static void Run()
    {
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
    private static bool AreUniqueLetters(string text)
    {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
        // Create a HashSet to store the letters seen so far
        // HashSet provides 0(1) lookup and insert time complexity of 0(n)
        var seenLetters = new HashSet<char>();

        // Iterate through each character in the text
        foreach (var letter in text)
        {
            // Check if the letter is already seen, it's duplicate
            if (!seenLetters.Add(letter))
            {
                // Duplicate found and return false
                return false;
            }
            // Else the letter is addeed to the set and continue

            // If no duplicates found, all letters are unique
            return true;

        }


        for (var i = 0; i < text.Length; ++i)
        {
            for (var j = 0; j < text.Length; ++j)
            {
                // Don't want to compare to yourself ... that will always result in a match
                if (i != j && text[i] == text[j])
                    return false;
            }
        }

        return true;
    }
}


// What is the difference between a set and a map?
// A set is a collection of unique elements or value that does not allow duplicates, while 
// a map (or dictionary) is a collection of key-value pairs where each key maps a specific value

//What is one use of a Dictionary (besides the class/object examples shown in the learning activity)?
// A Dictionary (or object/map in JavaScript) can be used to count occurrences of items efficiently
// example use case: Counting how many times each word appears in a text (word frequency).

// What is one of the most important things to remember when answering technical job interview questions?
// Interviewers are looking for how you approach problems, not just whether you get the right answer.
// Show how you break down the problem, consider edge cases, and ask clarifying questions