namespace LogExtractor
{
  class Extractor
  {
    public int numberOfUniqueIpAddresses { get; set; } = 0;
    public string[] topThreeMostVisitedUrls { get; set; } = { "None" };
    public string[] topThreeMostActiveIpAddresses { get; set; } = { "None" };
    public string[] ipLogs { get; set; } = { "None" };

    /// <summary>
    ///  Obtains the logs you want to extract the file from
    /// </summary>
    /// <param name="pathToFile">Path to the file where the logs are located</param>
    public void GetLogs(string pathToFile)
    {
      ipLogs = File.ReadAllLines(pathToFile);
    }
  }
}