using System;
using System.Collections.Generic;
using System.Linq;

namespace DefenseIO.Infra.Shared.Utils
{
    public static class ListUtils
    {
        public static object[,] ToMatrix(this IEnumerable<object[]> list)
        {
            int listSize = list.Count();
            if (listSize == 0) return new object[,] { };

            object[,] matrix = new object[listSize, list.First().Length];
            for (var i = 0; i < listSize; i++)
            {
                object[] item = list.ElementAt(i); 
                for(var j = 0; j < item.Length; j++)
                {
                    matrix[i, j] = item[j];
                }
            }
            return matrix;
        }
    }
}
