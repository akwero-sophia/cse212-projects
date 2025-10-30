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

        // PLAN FOR MULTIPLES OF:
        // Step 1: Create a new array of doubles with size equal to 'length'
        // Step 2: Use a loop that runs 'length' times (from 0 to length-1)
        // Step 3: For each position i in the array:
        //         - Calculate the multiple: number * (i + 1)
        //         - Note: We use (i + 1) because we want 1st multiple, 2nd multiple, etc.
        //         - For example: if number = 7, we want 7*1, 7*2, 7*3, etc.
        // Step 4: Store each calculated multiple in the array at position i
        // Step 5: After the loop completes, return the filled array

        // Create array to hold the multiples
        double[] multiples = new double[length];
        
        // Loop through each position and calculate the multiple
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple: number * (position + 1)
            // We add 1 to i because arrays are 0-indexed but we want 1st, 2nd, 3rd multiples
            multiples[i] = number * (i + 1);
        }
        
        return multiples;
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

        // PLAN FOR ROTATE LIST RIGHT:
        // When we rotate right by 'amount', the last 'amount' elements move to the front
        // Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} rotated right by 3
        //          The last 3 elements {7, 8, 9} move to the front
        //          Result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // Step 1: Calculate the split point where we divide the list
        //         - Split point = data.Count - amount
        //         - This gives us the index where the "rotation" happens
        //         - Example: 9 elements, rotate by 3 → split at index 6 (9 - 3)
        //
        // Step 2: Extract the last 'amount' elements (these will move to the front)
        //         - Use GetRange(splitPoint, amount) to get elements from splitPoint to end
        //         - Example: GetRange(6, 3) gets elements at indices 6, 7, 8 → {7, 8, 9}
        //
        // Step 3: Remove those last 'amount' elements from the original list
        //         - Use RemoveRange(splitPoint, amount)
        //         - Example: After removing, list becomes {1, 2, 3, 4, 5, 6}
        //
        // Step 4: Insert the extracted elements at the beginning (index 0)
        //         - Use InsertRange(0, extractedElements)
        //         - Example: Insert {7, 8, 9} at beginning → {7, 8, 9, 1, 2, 3, 4, 5, 6}

        // Calculate where to split the list
        int splitPoint = data.Count - amount;
        
        // Extract the last 'amount' elements that will move to the front
        List<int> elementsToMove = data.GetRange(splitPoint, amount);
        
        // Remove those elements from their current position at the end
        data.RemoveRange(splitPoint, amount);
        
        // Insert the extracted elements at the beginning of the list
        data.InsertRange(0, elementsToMove);
    }
}