using NUnit.Framework;
using LogExtractor;

namespace LogExtractor.Test
{
    public class Tests
    {
        private readonly string[] IpLogs = {
          "50.112.00.11 - admin [11/Jul/2018:17:31:05 +0200] \"GET /hosting/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"",
          "50.112.00.11 - admin [11/Jul/2018:17:33:01 +0200] \"GET /asset.css HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"",
          "50.112.00.11 - admin [11/Jul/2018:17:33:01 +0200] \"GET /asset.css HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"",
          "50.112.00.11 - admin [11/Jul/2018:17:33:01 +0200] \"GET /asset.css HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"",
          "168.41.191.40 - - [09/Jul/2018:10:12:03 +0200] \"GET /docs/manage-websites/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0\"",
          "168.41.191.40 - - [09/Jul/2018:10:12:03 +0200] \"GET /docs/manage-websites/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0\"",
          "168.41.191.40 - - [09/Jul/2018:10:12:03 +0200] \"GET /docs/manage-websites/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0\"",
          "72.44.32.10 - - [09/Jul/2018:15:48:20 +0200] \"GET /download/counter/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86; en-US) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7\"",
          "72.44.32.10 - - [09/Jul/2018:15:48:20 +0200] \"GET /download/counter/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86; en-US) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7\"",
          "177.71.128.21 - - [10/Jul/2018:22:21:03 +0200] \"GET /docs/manage-websites/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (compatible; MSIE 10.6; Windows NT 6.1; Trident/5.0; InfoPath.2; SLCC1; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 2.0.50727) 3gpp-gba UNTRUSTED/1.0\""
        };
    
        [Test, Description("Calculate Unique Ip Addressess")]
        public void CalculateUniqueIpAddresses_IpLogsObtained_ReturnUniqueIpAddresses()
        {
            Extractor extractor = new Extractor();
            extractor.ipLogs = IpLogs;

            extractor.CalculateUniqueIpAddresses();
            
            int expectedResults = 4;
            Assert.AreEqual(expectedResults, extractor.numberOfUniqueIpAddresses);
        }
        
        [Test, Description("Calculate Most Active Ip Addressess")]
        public void CalculateMostActiveIp_IpLogsObtained_ReturnMostActiveIpAddresses()
        {
            Extractor extractor = new Extractor();
            extractor.ipLogs = IpLogs;

            extractor.CalculateTopThreeMostActiveIpAddresses();
            
            string[] expectedResults = { "50.112.00.11", "168.41.191.40", "72.44.32.10" };
            Assert.AreEqual(expectedResults, extractor.topThreeMostActiveIpAddresses);
        }

        [Test, Description("Calculate Unique Ip Addressess Successful")]
        public void CalculateMostVisitedUrls_IpLogsObtained_ReturnMostVisitedUrls()
        {
            Extractor extractor = new Extractor();
            extractor.ipLogs = IpLogs;

            extractor.CalculateTopThreeMostVisitedUrls();

            string[] expectedResults = {"/docs/manage-websites/", "/asset.css", "/download/counter/"};
            Assert.AreEqual(expectedResults, extractor.topThreeMostVisitedUrls);
        }
    }
}