namespace LogExtractor
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Count() == 0)
      {
        Console.WriteLine("No arguments found, needs one argument which is the path to the file.");
        return;
      }


      Extractor extractor = new Extractor();

      // Place logs into object
      extractor.GetLogs(args[0]);
    }
  }
}