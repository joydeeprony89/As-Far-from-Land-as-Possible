using System;
using System.Collections.Generic;

namespace As_Far_from_Land_as_Possible
{
  class Program
  {
    static void Main(string[] args)
    {
      //var grid = new int[3][] { new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 1 } };
      var grid = new int[3][] { new int[] { 1, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
      Solution s = new Solution();
      var answer = s.MaxDistance(grid);
      Console.WriteLine(answer);
    }
  }


  public class Solution
  {
    public int MaxDistance(int[][] grid)
    {
      Queue<(int, int)> q = new Queue<(int, int)>();
      int m = grid.Length;
      int n = grid[0].Length;

      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
        {
          if (grid[i][j] == 1)
          {
            q.Enqueue((i, j));
          }
        }
      }

      // Base condition check, if no land or water exist
      if (q.Count == 0 || q.Count == m * n) return -1;

      int level = 0;
      List<int[]> directions = new List<int[]>();
      directions.Add(new int[] { 0, 1 });
      directions.Add(new int[] { 0, -1 });
      directions.Add(new int[] { 1, 0 });
      directions.Add(new int[] { -1, 0 });
      while (q.Count > 0)
      {
        int size = q.Count;
        while (size-- > 0)
        {
          var (rr, cc) = q.Dequeue();
          foreach (var direction in directions)
          {
            var r = rr + direction[0];
            var c = cc + direction[1];
            // check the array boundary
            if (r >= 0 && c >= 0 && r < m && c < n && grid[r][c] == 0)
            {
              // mark as visited
              grid[r][c] = 1;
              q.Enqueue((r, c));
            }
          }
        }
        level += 1;
      }

      return level - 1;
    }
  }
}
