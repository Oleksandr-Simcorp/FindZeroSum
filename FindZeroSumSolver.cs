using Google.OrTools.Sat;

public static class FindZeroSumSolver
{
    // ILP method using Google OR-Tools CP-SAT to find a subset whose sum is zero
    public static List<int> FindZeroSumSubset(int[] numbers)
    {
        // Create the model
        CpModel model = new CpModel();
        var x = new IntVar[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            x[i] = model.NewBoolVar($"x_{i}");
        }

        // Constraint: sum of selected numbers == 0
        model.Add(LinearExpr.WeightedSum(x, numbers) == 0);
        // Constraint: at least one number must be selected
        model.Add(LinearExpr.Sum(x) >= 1);

        // Objective: maximize the number of selected elements
        model.Maximize(LinearExpr.Sum(x));

        // Solve
        CpSolver solver = new CpSolver();
        var status = solver.Solve(model);
        if (status == CpSolverStatus.Optimal || status == CpSolverStatus.Feasible)
        {
            List<int> subset = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (solver.Value(x[i]) > 0)
                    subset.Add(numbers[i]);
            }
            return subset;
        }
        return new List<int>();
    }
}