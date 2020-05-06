using System;
using System.Collections.Generic;

namespace VacationsForeingCountry
{
  class Program
  {
    /*
    * Task description
    * You want to spend your next vacation in a foreign country. In the summer you are free for N consecutive days. 
    * You have consulted Travel Agency and learned that they are offering a trip to some interesting location in the country every day. 
    * For simplicity, each location is identified by a number from 0 to N − 1. Trips are described in a non-empty array A: for each K (0 ≤ K < N), A[K] is the identifier of a location which is the destination of a trip offered on day K. 
    * Travel Agency does not have to offer trips to all locations, and can offer more than one trip to some locations.
    *
    * You want to go on a trip every day during your vacation. Moreover, you want to visit all locations offered by Travel Agency. 
    * You may visit the same location more than once, but you want to minimize duplicate visits. 
    * The goal is to find the shortest vacation (a range of consecutive days) that will allow you to visit all the locations offered by Travel Agency.
    *
    * For example, consider array A such that:
    *
    *     A[0] = 7
    *     A[1] = 3
    *     A[2] = 7
    *     A[3] = 3
    *     A[4] = 1
    *     A[5] = 3
    *     A[6] = 4
    *     A[7] = 1
    *     
    * Travel Agency offers trips to four different locations (identified by numbers 1, 3, 4 and 7). 
    * The shortest vacation starting on day 0 that allows you to visit all these locations ends on day 6 (thus is seven days long). 
    * However, a shorter vacation of five days (starting on day 2 and ending on day 6) also permits you to visit all locations. 
    * On every vacation shorter than five days, you will have to miss at least one location.
    *
    * Write a function:
    *
    * class Solution { public int solution(int[] A); }
    *
    * that, given a non-empty array A consisting of N integers, returns the length of the shortest vacation that allows you to visit all the offered locations.
    *
    * For example, given array A shown above, the function should return 5, as explained above.
    *
    * Given A = [2, 1, 1, 3, 2, 1, 1, 3], the function should return 3. 
    * One of the shortest vacations that visits all the places starts on day 3 (counting from 0) and lasts for 3 days.
    *
    * Given A = [7, 5, 2, 7, 2, 7, 4, 7], the function should return 6. 
    * The shortest vacation that visits all the places starts on day 1 (counting from 0) and lasts for 6 days.
    *
    */
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      //case 1
      int[] c1 = { 7, 3, 7, 3, 1, 3, 4, 1 }; // 5

      //case 2
      int[] c2 = { 2, 1, 1, 3, 2, 1, 1, 3 }; // 3

      //case 3
      int[] c3 = { 7, 5, 2, 7, 2, 7, 4, 7 }; // 6

      //case 4
      int[] c4 = { 1, 1, 2, 3, 1, 1, 1, 1, 2, 2, 3, 1 }; //3

      //case 5
      int[] c5 = { 1, 2, 2, 3, 2, 2, 1, 1, 2, 1, 2, 3 }; //3

      int i = solution(c5);
    }
    public static int solution(int[] A)
    {
      int dif = count_different(A, 0, A.Length);
      int index = 0;
      int max = int.MaxValue;

      int p = 0;
      int q = 1;

      Dictionary<int, int> stack = new Dictionary<int, int>();

      AddToDic(stack, A[p]);
      AddToDic(stack, A[q]);

      while (q < A.Length && p < A.Length - dif)
      {
        bool valid = match_different( stack, dif );
        if (!valid)
        {
          q++;
          if ( q < A.Length )
            AddToDic(stack, A[q]);
        }
        else
        {
          if ( ( q - p + 1 ) < max )
          {
            max = (q - p + 1);
            index = p;
          }
          RemoveFromDic(stack, A[p]);
          p++;
        }
      }
      if ((q - p + 1) < max)
        max = (q - p + 1);
      return max;
    }
    public static void RemoveFromDic(Dictionary<int, int> d, int k)
    {
      if (d.ContainsKey(k))
        d[k]--;
    }
    public static void AddToDic(Dictionary<int, int> d, int k)
    {
      if (!d.ContainsKey(k))
        d.Add(k, 0);
      d[k]++;
    }
    public static bool match_different( Dictionary<int, int> s, int n )
    {
      List<int> dif = new List<int>();
      foreach (KeyValuePair<int, int> kvp in s)
        if ( !dif.Contains(kvp.Key) && ( kvp.Value > 0 ) )
          dif.Add(kvp.Key);
      return ( dif.Count == n );
    }
    public static int count_different(int[] A, int p, int q)
    {
      List<int> d = new List<int>();
      for (int i = p; i < q; i++)
        if (!d.Contains(A[i]))
          d.Add(A[i]);
      return d.Count;
    }
  }
}
