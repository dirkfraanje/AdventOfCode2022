using AdventOfCode2022;

Start();

static void Start()
{
    //Create day classes
    List<IDayBase> Days = new List<IDayBase>();
    for (int i = 1; i <= 7; i++)
    {
        var day = Type.GetType($"AdventOfCode2022.Day{i}");
        var newday = Activator.CreateInstance(day);
        Days.Add((IDayBase)newday);
    }

    //Ask for day number
    Console.WriteLine("Enter day number:");
    Console.WriteLine();
    var daynumber = Console.ReadLine();
    if (int.TryParse(daynumber, out int result))
    {
        var day = Days.FirstOrDefault(x => x.Day == result);
        if (day == null)
        {
            Console.WriteLine($"Day {result} is not available yet");
            Start();
            return;
        }
        day.LoadInput();
        day.ExecutePart1();
        day.ExecutePart2();
        Console.WriteLine();
    }
    else
        Console.WriteLine($"{daynumber} is not an integer");

    //Restart
    Start();
}