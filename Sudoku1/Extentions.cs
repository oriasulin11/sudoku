using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal static class Extentions
    {
        /// <summary>
        /// This extention method findes all the combenations
        /// of elements in the given list of size SetSize.
        /// The way it works is quite simple, we pick an element than
        /// recursively findes a smaller combenation without that element. 
        /// </summary>
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this List<T> elements, int setSize)
        {
            // Base case
            if(setSize == 0)
            {
                yield return Enumerable.Empty<T>();
                yield break;
            }
            int index = 0;
            foreach (T element in elements)
            {
                // New list without the element and the elements before it
                List<T> remaining = elements.Skip(++index).ToList();
                // Recursive call to combinations with smaller size
                foreach (var combination in remaining.GetCombinations(setSize-1))
                {
                    // return a list of the element with all the smaller combinations 
                    yield return new List<T> {element}.Concat(combination);
                }
            }
        }
    }
}
