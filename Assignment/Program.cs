class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Challenge 1
        int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
        int[] arr1Common = CommonItems(arr1);
        /* write method to print arr1Common */
        Console.Write("Challenge 1: Indentical Elements: ");
        foreach (int identicalNum in arr1Common)
        {
            Console.Write($"{identicalNum} ");
        }

        //Challenge 2
        int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        InverseJagged(arr2);
        /* write method to print arr2 */

        //Challenge 3
        int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        CalculateDiff(arr3);
        /* write method to print arr3 */

        //Challenge 4
        int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] arr4Inverse = InverseRec(arr4);

        Console.WriteLine("\n\nChallenge 4: ");
        Console.Write("Result Array: {");
        for (int i = 0; i < arr4Inverse.GetLength(0); i++)
        {
            Console.Write("{");
            for (int j = 0; j < arr4Inverse.GetLength(1); j++)
            {
                Console.Write(arr4Inverse[i, j]);
                if (j == arr4Inverse.GetLength(1) - 1)
                    Console.Write("}");
                else
                    Console.Write(", ");
            }
            if (i == arr4Inverse.GetLength(0) - 1)
                Console.Write("}.");
            else
                Console.Write(", ");
        }
        /* write method to print arr4Inverse */

        //Challenge 5
        Demo("hello", 1, 2, "world");

        //Challenge 6
        // var a = "morning";
        // var b = "people";
        // SwapTwo(ref a, ref b);

        //Challenge 7
        Console.WriteLine("\n\nChallenge 7: ");
        string firstName, middleName, lastName;
        ParseNames("Mary Elizabeth Smith", out firstName, out middleName, out lastName);
        Console.WriteLine(
            $"First name: {firstName}, middle name: {middleName}, last name: {lastName}."
        );

        //Challenge 8
        GuessingGame();
    }

    /*
    Challenge 1. Given a jagged array of integers (two dimensions).
    Find the common elements in the nested arrays.
    Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
    Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
    */
    static int[] CommonItems(int[][] jaggedArray)
    {
        int[] a = (int[])jaggedArray[0].Clone();
        int[] b = (int[])jaggedArray[1].Clone();
        List<int> c = new List<int>() { };

        foreach (int numA in a)
        {
            foreach (int numB in b)
            {
                if (numA == numB)
                {
                    c.Add(numA);
                    break;
                }
            }
        }

        int[] result = new int[c.Count];
        c.CopyTo(result);
        return result;
    }

    /*
    Challenge 2. Inverse the elements of a jagged array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}}
    Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
     */
    static void InverseJagged(int[][] jaggedArray)
    {
        Console.WriteLine("\n\nChallenge 2: ");
        foreach (int[] arr in jaggedArray)
        {
            int[] revArr = Enumerable.Reverse(arr).ToArray();
            Console.Write("Reverse Array: ");
            for (int num = 0; num < revArr.Length; num++)
            {
                Console.Write(revArr[num] + " ");
                if (num == revArr.Length - 1)
                    Console.WriteLine("");
            }
        }
    }

    /*
    Challenge 3.Find the difference between 2 consecutive elements of an array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}}
    Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
     */
    static void CalculateDiff(int[][] jaggedArray)
    {
        Console.WriteLine("\n\nChallenge 3: ");
        calDiff(jaggedArray[0]);
        calDiff(jaggedArray[1]);

        void calDiff(int[] arr)
        {
            List<int> result = new List<int>() { };
            for (int i = 0; i < arr.Length - 1; i++)
            {
                result.Add(arr[i] - arr[i + 1]);
            }

            Console.Write("Diff Array: ");
            for (int i = 0; i < result.Count(); i++)
            {
                Console.Write(result[i] + " ");
                if (i == result.Count() - 1)
                    Console.WriteLine("");
            }
        }
    }

    /*
    Challenge 4. Inverse column/row of a rectangular array.
    For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
    Expected result: {{1,2},{3,4},{5,6}}
     */
    static int[,] InverseRec(int[,] recArray)
    {
        int row = recArray.GetLength(0);
        int collumn = recArray.GetLength(1);
        List<int> tempArr = new List<int>() { };
        int[,] result = new int[collumn, row];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < collumn; j++)
            {
                tempArr.Add(recArray[i, j]);
            }
        }

        for (int i = 0; i < collumn; i++)
        {
            for (int j = 0; j < row; j++)
            {
                result[i, j] = tempArr[i * row + j];
            }
        }

        return result;
    }

    /*
    Challenge 5. Write a function that accepts a variable number of params of any of these types:
    string, number.
    - For strings, join them in a sentence.
    - For numbers then sum them up.
    - Finally print everything out.
    Example: Demo("hello", 1, 2, "world")
    Expected result: hello world; 3 */
    static void Demo(params object[] args)
    {
        string stringResult = "";
        int numResult = 0;

        foreach (var arg in args)
        {
            if (arg is string)
                stringResult += arg + " ";
            else
                numResult += Convert.ToInt32(arg);
        }

        stringResult = stringResult.Substring(0, stringResult.Length - 1);
        Console.WriteLine($"\n\nChallenge 5: {stringResult}; {numResult}.");
    }

    /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type
    and if they’re string, lengths have to be more than 5.
    If they’re numbers, they have to be more than 18. */
    static void SwapTwo(params object[] args)
    {
        // var objectA = arg[0];
        // var objectB = arg[1];

        // if (objectA.GetType() != objectB.GetType())
        // {
        //     Console.WriteLine($"Object '{objectA}' and '{objectB}' are not from the same type.");
        // }
        // else if (objectA is string && objectB is string)
        // {
        //     string strA = (string)objectA;
        //     string strB = (string)objectB;

        //     if (strA.Length < 5 || strB.Length < 5)
        //     {
        //         Console.WriteLine("One of the string doesn't meet length requirement.");
        //         return;
        //     }
        //     else
        //         Swap(ref objectA, ref objectB);
        // }
        // else
        // {
        //     int intA = (int)objectA;
        //     int intB = (int)objectB;

        //     if (intA < 18 || intB < 18) {
        //         Console.WriteLine("Number must be > 18.");
        //         return;
        //     } else Swap(intA, intB);
        // }

        // void Swap(ref object a, ref object b)
        // {
        //     object temp = a;
        //     a = b;
        //     b = temp;
        //     Console.WriteLine($"Your object: {a}, {b}.");
        // }
    }

    /* Challenge 7. Write a function to parse the first name, middle name, last name given a string.
    The names will be returned by using out modifier */
    static void ParseNames(
        string input,
        out string firstName,
        out string middleName,
        out string lastName
    ) { 
        string[] stringArr = input.Split(" ");
        firstName = stringArr[0];
        middleName = stringArr[1];
        lastName = stringArr[2];
    }

    /* Challenge 8. Write a function that does the guessing game.
    The function will think of a random integer number (lets say within 100)
    and ask the user to input a guess.
    It’ll repeat the asking until the user puts the correct answer. */
    static void GuessingGame() {
        Console.WriteLine("\n\nChallenge 8:");
        Random random = new Random();
        int number = random.Next(1, 101);
        int guess;

        do {
            Console.Write("Guess number: ");
            guess = int.Parse(Console.ReadLine());
            if (guess < number) Console.WriteLine("You guess too low! Aim higher.");
            else if (guess > number) Console.WriteLine("You guess too high! Aim lower.");
            else Console.WriteLine($"Correct! The random number is {number}.");
        } while (guess != number);
    }
}
