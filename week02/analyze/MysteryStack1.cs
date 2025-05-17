public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>(); // Create a new stack
        foreach (var letter in text) // Iterate through each character in the string
            stack.Push(letter); //Pushes each letter of the input string into the stack
        // The stack now contains the characters in reverse order

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop(); // Pops each letter and adds it to the result string

        return result;
    }
}

//What the Function Does
// It takes a string as input and reverses it
//Pushes each character of the input string onto a stack
//Pops all characters off the stack and builds a new string

// Example 
// Input: "racecar"
// Output: "racecar"
// The output is the same as the input because "racecar" is a palindrome