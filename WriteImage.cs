using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;

namespace HWIDSpoofer
{
  internal class WriteImage
  {
    private static int[] cColors = new int[16]
    {
      0,
      128,
      32768,
      32896,
      8388608,
      8388736,
      8421376,
      12632256,
      8421504,
      (int) byte.MaxValue,
      65280,
      (int) ushort.MaxValue,
      16711680,
      16711935,
      16776960,
      16777215
    };

    public Bitmap LoadPicture(string url)
    {
      Bitmap bitmap = (Bitmap) null;
      Stream stream = (Stream) null;
      HttpWebResponse httpWebResponse = (HttpWebResponse) null;
      try
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
        httpWebRequest.AllowWriteStreamBuffering = true;
        httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        if ((stream = httpWebResponse.GetResponseStream()) != null)
          bitmap = new Bitmap(stream);
      }
      finally
      {
        stream?.Close();
        httpWebResponse?.Close();
      }
      return bitmap;
    }

    public void ConsoleWritePixel(Color cValue)
    {
      Color[] array = ((IEnumerable<int>) WriteImage.cColors).Select<int, Color>((Func<int, Color>) (x => Color.FromArgb(x))).ToArray<Color>();
      char[] chArray = new char[4]{ '░', '▒', '▓', '█' };
      int[] numArray = new int[4]{ 0, 0, 4, int.MaxValue };
      for (int length = chArray.Length; length > 0; --length)
      {
        for (int index1 = 0; index1 < array.Length; ++index1)
        {
          for (int index2 = 0; index2 < array.Length; ++index2)
          {
            int num1 = ((int) array[index1].R * length + (int) array[index2].R * (chArray.Length - length)) / chArray.Length;
            int num2 = ((int) array[index1].G * length + (int) array[index2].G * (chArray.Length - length)) / chArray.Length;
            int num3 = ((int) array[index1].B * length + (int) array[index2].B * (chArray.Length - length)) / chArray.Length;
            int num4 = ((int) cValue.R - num1) * ((int) cValue.R - num1) + ((int) cValue.G - num2) * ((int) cValue.G - num2) + ((int) cValue.B - num3) * ((int) cValue.B - num3);
            if ((length <= 1 || length >= 4 || num4 <= 50000) && num4 < numArray[3])
            {
              numArray[3] = num4;
              numArray[0] = index1;
              numArray[1] = index2;
              numArray[2] = length;
            }
          }
        }
      }
      Console.ForegroundColor = (ConsoleColor) numArray[0];
      Console.BackgroundColor = (ConsoleColor) numArray[1];
      Console.Write(chArray[numArray[2] - 1]);
    }

    public void ConsoleWriteImage(Bitmap source)
    {
      int num1 = 39;
      Decimal num2 = Math.Min(Decimal.Divide((Decimal) num1, (Decimal) source.Width), Decimal.Divide((Decimal) num1, (Decimal) source.Height));
      Size size = new Size((int) ((Decimal) source.Width * num2), (int) ((Decimal) source.Height * num2));
      Bitmap bitmap = new Bitmap((Image) source, size.Width * 2, size.Height);
      for (int y = 0; y < size.Height; ++y)
      {
        for (int index = 0; index < size.Width; ++index)
        {
          this.ConsoleWritePixel(bitmap.GetPixel(index * 2, y));
          this.ConsoleWritePixel(bitmap.GetPixel(index * 2 + 1, y));
        }
        Console.WriteLine();
      }
      Console.ResetColor();
    }
  }
}