using System;
using System.Collections.Generic;

namespace CodilityMinimumNucleotide
{
  //Task description
  //A DNA sequence can be represented as a string consisting of the letters A, C, G and T, which correspond to the types of successive nucleotides in the sequence.Each nucleotide has an impact factor, which is an integer. 
  //Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively.You are going to answer several queries of the form: What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence?

  //The DNA sequence is given as a non-empty string S = S[0]S[1]...S[N - 1] consisting of N characters.There are M queries, which are given in non-empty arrays P and Q, each consisting of M integers.
  //The K-th query (0 ≤ K<M) requires you to find the minimal impact factor of nucleotides contained in the DNA sequence between positions P[K] and Q[K] (inclusive).

  //For example, consider string S = CAGCCTA and arrays P, Q such that:

  //  P[0] = 2    Q[0] = 4
  //  P[1] = 5    Q[1] = 5
  //  P[2] = 0    Q[2] = 6
  //The answers to these M = 3 queries are as follows:

  //The part of the DNA between positions 2 and 4 contains nucleotides G and C(twice), whose impact factors are 3 and 2 respectively, so the answer is 2.
  //The part between positions 5 and 5 contains a single nucleotide T, whose impact factor is 4, so the answer is 4.
  //The part between positions 0 and 6 (the whole string) contains all nucleotides, in particular nucleotide A whose impact factor is 1, so the answer is 1.
  //Write a function:

  //class Solution { public int[] solution(string S, int[] P, int[] Q); }

  //that, given a non-empty string S consisting of N characters and two non-empty arrays P and Q consisting of M integers, returns an array consisting of M integers specifying the consecutive answers to all queries.

  //Result array should be returned as an array of integers.

  //For example, given the string S = CAGCCTA and arrays P, Q such that:

  //    P[0] = 2    Q[0] = 4
  //    P[1] = 5    Q[1] = 5
  //    P[2] = 0    Q[2] = 6
  //the function should return the values [2, 4, 1], as explained above.

  //Write an efficient algorithm for the following assumptions:

  //N is an integer within the range[1..100, 000];
  //M is an integer within the range[1..50, 000];
  //each element of arrays P, Q is an integer within the range[0..N − 1];
  //P[K] ≤ Q[K], where 0 ≤ K<M;
  //string S consists only of upper-case English letters A, C, G, T.

  class CodilityMinimumNucleotide
  {
    static void Main(string[] args)
    {
      string s = "CAGCCTA";
      int[] P = { 2, 5, 0 };
      int[] Q = { 4, 5, 6 };
      int[] r = solution(s, P, Q);
    }
    public static int[] solution(string s, int[] P, int[] Q)
    {
      int[] r = new int[P.Length];
      int[,] accumulative = new int[s.Length+1, 4];
      int[] row = new int[4];
      
      for ( int i = 0; i < s.Length; i ++ )
      {
        accumulative[i, 0] = row[0];
        accumulative[i, 1] = row[1];
        accumulative[i, 2] = row[2];
        accumulative[i, 3] = row[3];
        if (s[i] == 'A')
          row[0]++;
        else if (s[i] == 'C')
          row[1]++;
        else if (s[i] == 'G')
          row[2]++;
        else if (s[i] == 'T')
          row[3]++;
      }

      accumulative[s.Length, 0] = row[0];
      accumulative[s.Length, 1] = row[1];
      accumulative[s.Length, 2] = row[2];
      accumulative[s.Length, 3] = row[3];

      for ( int j = 0; j < P.Length; j ++ )
      {
        int from = P[j];
        int to   = Q[j]+1;

        if ((accumulative[to, 0] - accumulative[from, 0]) > 0)
          r[j] = 1;
        else if ((accumulative[to, 1] - accumulative[from, 1]) > 0)
          r[j] = 2;
        else if ((accumulative[to, 2] - accumulative[from, 2]) > 0)
          r[j] = 3;
        else if ((accumulative[to, 3] - accumulative[from, 3]) > 0)
          r[j] = 4;
      }

      return r;
    }
  }
}
