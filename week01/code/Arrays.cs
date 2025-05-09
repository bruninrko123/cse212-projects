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




        //create a new array to store the results
        //The array should have the same lenght of the variable lenght 
        double[] result = new double[length];

        //loop "lenght" number of times using a for loop
        //start adding the number itself to the array and then increment it by the number each time you loop and save to the array
        for (int i=0; i<length; i++)
            result[i] = number + (number*i);


            


        return result; // return the result
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


        

        //Create a temporary list to save the part of the original list to be removed
        List<int>temporaryList = data.GetRange((data.Count) - amount, amount);

        //Remove this same portion from the original list
        data.RemoveRange((data.Count) - amount, amount);

      
        //Create a list to temporarily save what is in the original list "data", excluding the part removed at the beggining
        //Then, clear the original list
        List<int> dataTemporary = new();
        dataTemporary.AddRange(data);
        data.Clear();

     

        //iterate through the original list, adding the values in the temporary list
        for (int i = 0; i< temporaryList.Count; i++)
            data.Add(temporaryList[i]);
        
        

        //Add the data you stored in dataTemporary back into the original list, after the value shifted right
        data.AddRange(dataTemporary);
        

        

        
        



    }
}
