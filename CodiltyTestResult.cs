using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodiltyTestResult
{
  class CodiltyTestResult
  {
    static void Main(string[] args)
    {
      string[] T = { "test1a", "test2", "test1b", "test1c", "test3" };
      string[] R = { "", "OK", "", "OK", "" };
      int n = solution(T, R);
    }
    public static int solution(string[] T, string[] R)
    {
      Dictionary<int, bool> groups = new Dictionary<int, bool>();

      for (int i = 0; i < T.Length ; i++ )
      {
        string value = Regex.Replace(T[i], "[A-Za-z ]", "");
        int parsedValue = int.Parse(value);
        if (!groups.ContainsKey(parsedValue))
          groups.Add(parsedValue, true);
        groups[parsedValue] = (groups[parsedValue] && (R[i] == "OK") ) ;
      }
      int valid = 0;

      foreach (KeyValuePair<int, bool> kvp in groups)
        if (kvp.Value)
          valid++;

      return (int) valid * 100 / groups.Count;
    }

  }
}
