public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}");
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int l1Idx = 0;
        int l2Idx = 0;

        for (int i = 0; i < select.Length; i++) {
            if (select[i] == 1) {
                result[i] = list1[l1Idx];
                l1Idx++;
            } else {
                result[i] = list2[l2Idx];
                l2Idx++;
            }
        }
        return result;
    }
}