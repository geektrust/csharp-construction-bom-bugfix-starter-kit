/*
 * This is the driver code. Don't change it!!!
 */

public class Program
{
    private static HouseEstimator estimator = new HouseEstimator();

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            throw new Exception("No command line arguments passed");
        }

        estimator = new HouseEstimator();

        foreach (string arg in args)
        {
            Handle(arg);
        }
    }

    public static void Handle(string input)
    {
        string[] tokens = input.Trim().Split(' ');

        string command = tokens[0];

        if (command == "ADD_COMPONENT")
        {
            string component = tokens[1];
            int quantity = int.Parse(tokens[2]);

            estimator.AddComponent(component, quantity);
        }
        else if (command == "TOTAL_COST")
        {
            Console.WriteLine(
                "Total Construction Cost: "
                + estimator.CalculateTotalCost()
            );
        }
        else
        {
            Console.WriteLine("INVALID_COMMAND");
        }
    }
}
