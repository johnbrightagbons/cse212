using Microsoft.VisualStudio.TestTools.UnitTesting;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create an empty array to store the multipes of the number
        double[] multiples = new double[length]; // Initialize the array with the size of 'length'

        // Loop through the array and fill it with multiples of the number
        for (int i = 0; i < length; i++) // Start from 0 to length - 1
        {
            // Calculate the multiples of the number and addd it to the array
            multiples[i] = number * (i + 1); // This will give the multiples of the number
        }
        // Return the array of multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // If the input list is empty, return immediately
        if (data.Count == 0)
            return; // No need to rotate an empty list

        // If the amount is equal to the size of the list, return the list as 
        // it is already rotated
        amount = amount % data.Count; // Calculate the effective rotation amount
        if (amount == 0)
            return; // No need to rotate the list

        // Get the last amount of elements from the list
        var lastPart = data.GetRange(data.Count - amount, amount); // Get the last 'amount' elements

        // Get the first part of the list excluding the last 'amount' elements
        var firstPart = data.GetRange(0, data.Count - amount); // Get the first part of the list

        // Remove the original list and rebuild it with the new order
        data.Clear(); // Clear the original list
        data.AddRange(lastPart); // Add the last part to the list
        data.AddRange(firstPart); // Add the first part to the list

    }
}
