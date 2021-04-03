using System.Net;

namespace HWIDSpoofer
{
  internal class InternetConn
  {
    public bool CheckForInternetConnection()
    {
      try
      {
        using (WebClient webClient = new WebClient())
        {
          using (webClient.OpenRead("http://www.google.com"))
            return true;
        }
      }
      catch
      {
        return false;
      }
    }
  }
}
