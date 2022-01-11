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

      // Calculate unique IP addresses
      extractor.CalculateUniqueIpAddresses();
      Console.WriteLine($"Unique IP Addresses: \n{extractor.numberOfUniqueIpAddresses}");
    
      // Calculate top three active IP addresses
      extractor.CalculateTopThreeMostActiveIpAddresses();
      Console.WriteLine($"\nTop Three Active IP Addresses");
      foreach (var activeIpAddress in extractor.topThreeMostActiveIpAddresses)
      {
        Console.WriteLine(activeIpAddress);
      }
    }
  }
}
