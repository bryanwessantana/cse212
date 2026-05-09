using System.Collections.Generic;

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
        // Plan:
        // 1. Create a new array of doubles with the size provided by the 'length' parameter.
        // 2. Use a loop (for) that runs 'length' times to calculate each multiple.
        // 3. In each iteration, calculate the multiple by multiplying the starting 'number' 
        //    by the current index + 1 (since index starts at 0).
        // 4. Store each calculated multiple in the corresponding index of the array.
        // 5. Return the completed array.

        double[] results = new double[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results;
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
        // Plan:
        // 1. Identify the starting point for the slice to be moved. Since we are rotating 
        //    to the right, the elements at the end of the list will move to the front.
        // 2. Use 'GetRange' to capture the part of the list that needs to be moved to the 
        //    front (from 'data.Count - amount' to the end).
        // 3. Use 'RemoveRange' to delete those same elements from their original position 
        //    at the end of the list.
        // 4. Use 'InsertRange' at index 0 to place the captured elements at the very 
        //    beginning of the list.
        
        // This effectively "shifts" the list to the right.

        if (data.Count > 0 && amount > 0)
        {
            // Calculate the starting index of the segment to move
            int startIdx = data.Count - amount;
            
            // Get the segment that will move to the front
            List<int> segmentToMove = data.GetRange(startIdx, amount);
            
            // Remove it from the end
            data.RemoveRange(startIdx, amount);
            
            // Insert it at the beginning
            data.InsertRange(0, segmentToMove);
        }
    }
}