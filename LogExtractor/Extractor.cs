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

    /// <summary>
    /// Calculate three most active Ip addresses
    /// </summary>
    public void CalculateTopThreeMostActiveIpAddresses()
    {
      // Extract out IP Address List
      var ipAddressList = ipLogs.Select(log =>
      {
        return log.Substring(0, log.IndexOf(" "));
      });

      // Place key/value = ipAddress/numberOfIps
      Dictionary<string, int> activeIpAddressList = new Dictionary<string, int>();
      foreach (string ipAddress in ipAddressList)
      {
        if (!activeIpAddressList.ContainsKey(ipAddress))
          activeIpAddressList.Add(ipAddress, 1);
        else
          activeIpAddressList[ipAddress] = activeIpAddressList[ipAddress] + 1;
      }

      var sortedActiveIpAddressList = activeIpAddressList
          .OrderByDescending(_ => _.Value)
          .Take(3)
          .Select(keyValuePair => keyValuePair.Key)
          .ToArray();

      topThreeMostActiveIpAddresses = sortedActiveIpAddressList;
    }

    /// <summary>
    ///  Calculate three most visited URLs
    /// </summary>
    public void CalculateTopThreeMostVisitedUrls()
    {
      //Extract out urls
      var ipAddressList = ipLogs.Select(log =>
      {
        int startIndex = log.IndexOf("GET ") + 4;
        int length = log.IndexOf(" HTTP") - startIndex;

        return log.Substring(startIndex, length);
      });

      // Place key/value = urls/occurenceOfUrls
      Dictionary<string, int> urlList = new Dictionary<string, int>();
      foreach (string ipAddress in ipAddressList)
      {
        if (!urlList.ContainsKey(ipAddress))
          urlList.Add(ipAddress, 1);
        else
          urlList[ipAddress] = urlList[ipAddress] + 1;
      }

      var sortedUrlList = urlList
          .OrderByDescending(_ => _.Value)
          .Take(3)
          .Select(keyValuePair => keyValuePair.Key)
          .ToArray();

      topThreeMostVisitedUrls = sortedUrlList;
    }
  }
}
