public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {   
        int list1Counter =0;
        int list2Counter =0;
        int[] result = new int[select.Length];
        int resultCounter = 0;
        foreach(int n in select){
            if(n == 1){
                result[resultCounter] = list1[list1Counter];
                resultCounter++;
                list1Counter++;
            }
            else if(n == 2){
                result[resultCounter] = list2[list2Counter];
                resultCounter++;
                list2Counter++;
            }
        }
        return result;
    }
}