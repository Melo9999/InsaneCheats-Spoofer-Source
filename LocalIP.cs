using System;
using System.Net;
using System.Net.Sockets;

namespace HWIDSpoofer
{
  internal class LocalIP
  {
    public string GetLocalIPAddress()
    {
      foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
      {
        if (address.AddressFamily == AddressFamily.InterNetwork)
          return address.ToString();
      }
      throw new Exception("Local IP Address Not Found!");
    }
  }
}