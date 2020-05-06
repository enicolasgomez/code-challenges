using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
  // A non-empty array A consisting of N integers is given.The consecutive elements of array A represent consecutive cars on a road.

  //Array A contains only 0s and/or 1s:

  //0 represents a car traveling east,
  //1 represents a car traveling west.
  //The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P<Q<N, is passing when:
  //P is traveling to the east and Q is traveling to the west.

  //For example, consider array A such that:


  // A[0] = 0
  // A[1] = 1
  // A[2] = 0
  // A[3] = 1
  // A[4] = 1

  //We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

  //Write a function:

  //class Solution { public int solution(int[] A); }

  //  that, given a non-empty array A of N integers, returns the number of pairs of passing cars.
  //  The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

  //For example, given:

  //  A[0] = 0
  //  A[1] = 1
  //  A[2] = 0
  //  A[3] = 1
  //  A[4] = 1

  //the function should return 5, as explained above.
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      int[] A = { 0, 1, 0, 1, 1 };
      int n = solution(A);
    }
    public static int solution(int[] A)
    {
      List<int> remaining_ones = new List<int>();
      int count_ones = 0;
      int total = 0;

      for (int i = 0; i < A.Length; i++)
        count_ones += A[i];

      int passed_ones = 0;

      for (int i = 0; i < A.Length; i ++)
      {
        passed_ones += A[i];
        remaining_ones.Add(count_ones - passed_ones);
      }

      for (int i = 0; i < A.Length; i++)
      {
        if (A[i] == 0)
          total += remaining_ones[i];
        if ( total > 1000000000 )
        {
          total = -1;
          break; 
        }
      }


      return total;
    }
  }
}
