Random rand = new Random();
int[] numbers = new int[100];
for (int i = 0; i < numbers.Length; i++)
{
    int v = rand.Next(-20000, 20000);
    numbers[i] = v;
}

var zeroSumSubset = FindZeroSumSolver.FindZeroSumSubset(numbers);
Console.WriteLine("Generated numbers: \n[" + string.Join(", ", numbers) + "]");

if (zeroSumSubset != null && zeroSumSubset.Count > 0)
{
    Console.WriteLine($"Found longest subset with sum 0: \n[{string.Join(", ", zeroSumSubset)}]");
    Console.WriteLine($"Sum of subset: {zeroSumSubset.Sum()}");
}
else
{
    Console.WriteLine("No subset with sum 0 found.");
}



