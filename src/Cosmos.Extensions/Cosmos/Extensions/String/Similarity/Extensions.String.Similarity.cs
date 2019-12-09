using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Evaluate Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="similarityMinimal"></param>
        /// <returns></returns>
        public static double EvaluateSimilarity(this string text, string toCheck, double similarityMinimal) {
            const int diffFound = 0;
            return EvaluateSimilarity(text, toCheck, similarityMinimal, diffFound);
        }

        private const int MMaxDifToleradas = 2;

        /// <summary>
        /// Evaluate Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <param name="similarityMinimal"></param>
        /// <param name="diffFound"></param>
        /// <returns></returns>
        public static double EvaluateSimilarity(this string text, string toCheck, double similarityMinimal, int diffFound) {
            //if you have too many differences and no longer comparing
            if (diffFound >= MMaxDifToleradas)
                return 0.0;

            //ignore spaces
            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');

            //if they are equal 100%
            if (text.EqualsIgnoreCase(toCheck))
                return 1;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = toCheck;
            if (text.Length != toCheck.Length) {
                if (text.Length > toCheck.Length)
                    portionText = text.Substring(0, toCheck.Length);
                else if (toCheck.Length > text.Length)
                    portionToCheck = toCheck.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return 0.75;
            }

            //evaluate the differences
            var totalDifferences = 0;
            var posDifference = -1;
            for (var i = 0; i < text.Length; i++) {
                if (i >= toCheck.Length
                 || text.ToCharArray()[i] != toCheck.ToCharArray()[i])
                    totalDifferences++;
                if (posDifference < 0 && totalDifferences == 1)
                    posDifference = i;
            }

            //but return percentage according to the amount of differences
            var res = Convert.ToDouble(text.Length - totalDifferences) / Convert.ToDouble(text.Length);

            if (totalDifferences <= MMaxDifToleradas)
                return res;

            //suppose that only 1 difference was found
            var differences = diffFound + 1;
            //Consider if the dif is a missing character in text2
            var resConCarAwayInText2 = text.Substring(posDifference + 1).EvaluateSimilarity(toCheck.Substring(posDifference), similarityMinimal, differences);
            //Consider if the dif is a missing character in text1
            var resConCarAwayInText1 = text.Substring(posDifference).EvaluateSimilarity(toCheck.Substring(posDifference + 1), similarityMinimal, differences);
            //Consider if the dif is a changed character
            var resConCarCharacter = text.Substring(posDifference + 1).EvaluateSimilarity(toCheck.Substring(posDifference + 1), similarityMinimal, differences);
            //If any of the 3 is valid, calculate similarity as
            //  simParte1 + max(simParte2) - 0.1 / 2
            if (resConCarAwayInText2 > similarityMinimal || resConCarAwayInText1 > similarityMinimal || resConCarCharacter > similarityMinimal)
                return (1.0 + Math.Max(resConCarAwayInText2, Math.Max(resConCarAwayInText1, resConCarCharacter)) - 0.10) / 2.0;
            return res;
        }

        /// <summary>
        /// Evaluate Type Similarity
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static TypeSimilarity EvaluateTypeSimilarity(this string text, string toCheck) {
            //ignore spaces
            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');

            //if they are equal 100%
            if (text.EqualsIgnoreCase(toCheck))
                return TypeSimilarity.Same;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = toCheck;
            if (text.Length != toCheck.Length) {
                if (text.Length > toCheck.Length)
                    portionText = text.Substring(0, toCheck.Length);
                else if (toCheck.Length > text.Length)
                    portionToCheck = toCheck.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return (text.Length > toCheck.Length ? TypeSimilarity.MayorLong : TypeSimilarity.MinorLong);
            }

            return TypeSimilarity.Any;
        }
    }
}