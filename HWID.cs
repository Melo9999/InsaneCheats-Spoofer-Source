using System.Management;

namespace HWIDSpoofer
{
  internal class Hwid
  {
    public string getHWID()
    {
      ManagementObjectCollection objectCollection = new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get();
      string empty = string.Empty;
      using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = objectCollection.GetEnumerator())
      {
        if (enumerator.MoveNext())
          empty = enumerator.Current["ProcessorId"].ToString();
      }
      return empty;
    }
  }
}
