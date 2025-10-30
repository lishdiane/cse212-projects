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

        // ----- Explanation ----- 
        // First I will create an instance of a multiplier that is set to 1 
        // Then I will make an empty array set to length
        // I will make a for loop with i < length as the condition.
        // In the for loop, number will be multiplied by the multiplier and added to the array.
        // Finally the multiplier will be incremented by 1. 

        var multiplier = 1;
        double[] results = new double[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = number * multiplier;
            multiplier++;
        }

        return results; // replace this return statement with your own
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

        // ----- Explanation -----
        // First I will create an copy of the array to hold the new positions and their values;
        // Then I will make a for loop with i < length of the array as the condition. 
        // In the for loop I will determine the new position by using remainders.
        // I will set the item to its new position in the copy.
        // Finally, I will set the copy array to the data array.

        var newList = data.ToList();

        for (int i = 0; i < data.Count; i++)

        {
            int position = (i + amount) % data.Count;
            newList[position] = data[i];

        }
        
        for (int i = 0; i < newList.Count; i++)
        {
            data[i] = newList[i];
        }
    }
}
