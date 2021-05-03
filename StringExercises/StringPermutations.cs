using System.Collections.Generic;

namespace StringExercises
{
    public static class StringPermutations
    {
        public static HashSet<string> Permutations(this string input)
            => input.Permutations(0);

        private static HashSet<string> Permutations(this string input, int index)
        {
            var permutationsSet = new HashSet<string>();

            if (index == input.Length - 1)
                return permutationsSet;

            for(int charIndex = index; charIndex <= input.Length -1; charIndex++)
            {
                var permutation = input.Swap(index, charIndex);
                permutationsSet.Add(permutation);

                permutationsSet.UnionWith(permutation.Permutations(index + 1));
            }

            return permutationsSet;
        }

        private static string Swap(this string input, int firstPosition, int secondPosition)
        {
            var characters = input.ToCharArray();
            var temp = characters[firstPosition];
            characters[firstPosition] = characters[secondPosition];
            characters[secondPosition] = temp;

            return new string(characters);
        }
    }
}
