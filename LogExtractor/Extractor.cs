namespace LogExtractor
{
  class Extractor
  {
    public int numberOfUniqueIpAddresses { get; set; } = 0;
    public string[] topThreeMostVisitedUrls { get; set; } = { "None" };
    public string[] topThreeMostActiveIpAddresses { get; set; } = { "None" };
    public string[] ipLogs { get; set; } = { "None" };
  }
}
