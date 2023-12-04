//static int findLongestSubsequence(int[] arr)
//{
//    int[] subSequence = getSubsequence(arr);
//    for (global::System.Int32 i = 0; i < arr.Length; i++)
//    {
//        arr[i] = arr[i + 1];
//        arr[i] = arr[i + 1] - arr[i - 1];

//    }
//    return -1;
//}

//static int[] getSubsequence(int[] arr)
//{
//    return new int[2];
//}

//static int[] getLongSubsequence(int[] arr)
//{
//    return new int[2];
//}

//static bool validateOddEven(int[] arr)
//{
//    int sum = 0;
//    for (int i = 0; i < arr.Length; i++)
//    {
//        sum += arr[i];
//    }
//    if (sum % 2 == 0)
//    {
//        return true;
//    }
//    return false;
//}

//static int getLength(int[] arr)
//{
//    return arr.Length;
//}

static int findLongestSubsequence(int[] arr)
{
    int n = arr.Length;
    Dictionary<int, int> evenDiffCounts = new Dictionary<int, int>();
    Dictionary<int, int> oddDiffCounts = new Dictionary<int, int>();

    int maxLen = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            int diff = Math.Abs(arr[i] - arr[j]);
            int diffCount = evenDiffCounts.ContainsKey(diff) ? evenDiffCounts[diff] : 0;

            if (diffCount % 2 == 0)
            {
                maxLen = Math.Max(maxLen, j - i + 1);
            }

            if ((j - i + 1) % 2 == 0)
            {
                evenDiffCounts[diff] = diffCount + 1;
            }
            else
            {
                oddDiffCounts[diff] = oddDiffCounts.ContainsKey(diff) ? oddDiffCounts[diff] + 1 : 1;
            }
        }
    }

    return maxLen;
}

Console.WriteLine("Ingrese el tamaño del arreglo: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] arr = new int[n];

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Ingrese el numero en la posicion: {i}");
    arr[i] = Convert.ToInt32(Console.ReadLine());
}

int result = findLongestSubsequence(arr);
Console.WriteLine(result);
