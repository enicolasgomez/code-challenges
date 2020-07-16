using System;

namespace MicrosoftSplitArrayChallenge
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] v = { 4 , -1, -6, 125, 11 , 15, 19, 9, 3, 1, 25, -7, -32, 7 };
      int sep = 9;

      split(ref v, 0, v.Length-1, sep);

      Console.ReadLine();
    }
    static void split(ref int[] v, int i, int j, int sep)
    {
      while (v[i] <= sep) i++;
      while (v[j] > sep) j--;

      if ( j >= i + 1)
      {
        swap(ref v, i, j);
        split(ref v, 0, v.Length - 1, sep);
      }
    }

    static void swap(ref int[] v, int i, int j)
    {
      int aux = v[i];
      v[i] = v[j];
      v[j] = aux;
    }
  }
}
