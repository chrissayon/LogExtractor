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

    /// <summary>
    /// Calculate number of unique IP addresses based off log files.
    /// Result will be placed into "numberOfUniqueIpAddresses" member
    /// </summary>
    public void CalculateUniqueIpAddresses()
    {
      // Extract out IP Address List
      var ipAddressList = ipLogs.Select(log =>
      {
        return log.Substring(0, log.IndexOf(" "));
      });

      HashSet<string> uniqueIpAddresses = new HashSet<string>();
      
      // Place list into HashSet and grab the list of addresses in HashSet
      uniqueIpAddresses.UnionWith(ipAddressList);

      numberOfUniqueIpAddresses = uniqueIpAddresses.Count();
    }
  }
}
