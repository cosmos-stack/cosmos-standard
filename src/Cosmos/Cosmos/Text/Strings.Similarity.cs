using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Cosmos.Text
{
    /// <summary>
    /// Type Similarity
    /// </summary>
    public enum StringSimilarityTypes
    {
        /// <summary>
        /// Any
        /// </summary>
        Any,

        /// <summary>
        /// Same
        /// </summary>
        Same,

        /// <summary>
        /// Mayor long
        /// </summary>
        MayorLong,

        /// <summary>
        /// Minor long
        /// </summary>
        MinorLong,
    }

    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        private const int MAX_DIF_TOLERADAS = 2;

        /// <summary>
        /// Evaluate string similarity and return quantitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <param name="similarityMinimal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EvaluateSimilarity(string text, string ComparisonText, double similarityMinimal)
        {
            const int diffFound = 0;
            return EvaluateSimilarity(text, ComparisonText, similarityMinimal, diffFound);
        }

        /// <summary>
        /// Evaluate string similarity and return quantitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <param name="similarityMinimal"></param>
        /// <param name="diffFound"></param>
        /// <returns></returns>
        public static double EvaluateSimilarity(string text, string ComparisonText, double similarityMinimal, int diffFound)
        {
            //if you have too many differences and no longer comparing
            if (diffFound >= MAX_DIF_TOLERADAS)
                return 0.0;

            //ignore spaces
            text = RemoveWhiteSpace(text);
            ComparisonText = RemoveWhiteSpace(ComparisonText);

            //if they are equal 100%
            if (text.EqualsIgnoreCase(ComparisonText))
                return 1;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = ComparisonText;
            if (text.Length != ComparisonText.Length)
            {
                if (text.Length > ComparisonText.Length)
                    portionText = text.Substring(0, ComparisonText.Length);
                else if (ComparisonText.Length > text.Length)
                    portionToCheck = ComparisonText.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return 0.75;
            }

            //evaluate the differences
            var totalDifferences = 0;
            var posDifference = -1;
            for (var i = 0; i < text.Length; i++)
            {
                if (i >= ComparisonText.Length
                 || text.ToCharArray()[i] != ComparisonText.ToCharArray()[i])
                    totalDifferences++;
                if (posDifference < 0 && totalDifferences == 1)
                    posDifference = i;
            }

            //but return percentage according to the amount of differences
            var res = Convert.ToDouble(text.Length - totalDifferences) / Convert.ToDouble(text.Length);

            if (totalDifferences <= MAX_DIF_TOLERADAS)
                return res;

            //suppose that only 1 difference was found
            var differences = diffFound + 1;
            //Consider if the dif is a missing character in text2
            var resConCarAwayInText2 = EvaluateSimilarity(text.Substring(posDifference + 1), ComparisonText.Substring(posDifference), similarityMinimal, differences);
            //Consider if the dif is a missing character in text1
            var resConCarAwayInText1 = EvaluateSimilarity(text.Substring(posDifference), ComparisonText.Substring(posDifference + 1), similarityMinimal, differences);
            //Consider if the dif is a changed character
            var resConCarCharacter = EvaluateSimilarity(text.Substring(posDifference + 1), ComparisonText.Substring(posDifference + 1), similarityMinimal, differences);
            //If any of the 3 is valid, calculate similarity as
            //  simParte1 + max(simParte2) - 0.1 / 2
            if (resConCarAwayInText2 > similarityMinimal || resConCarAwayInText1 > similarityMinimal || resConCarCharacter > similarityMinimal)
                return (1.0 + Math.Max(resConCarAwayInText2, Math.Max(resConCarAwayInText1, resConCarCharacter)) - 0.10) / 2.0;
            return res;
        }

        /// <summary>
        /// Evaluate string similarity and return qualitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <returns></returns>
        public static StringSimilarityTypes EvaluateSimilarity(string text, string ComparisonText)
        {
            //ignore spaces
            text = RemoveWhiteSpace(text);
            ComparisonText = RemoveWhiteSpace(ComparisonText);

            //if they are equal 100%
            if (text.EqualsIgnoreCase(ComparisonText))
                return StringSimilarityTypes.Same;

            //ignore remaining text
            var portionText = text;
            var portionToCheck = ComparisonText;
            if (text.Length != ComparisonText.Length)
            {
                if (text.Length > ComparisonText.Length)
                    portionText = text.Substring(0, ComparisonText.Length);
                else if (ComparisonText.Length > text.Length)
                    portionToCheck = ComparisonText.Substring(0, text.Length);
                if (portionText.EqualsIgnoreCase(portionToCheck))
                    return (text.Length > ComparisonText.Length ? StringSimilarityTypes.MayorLong : StringSimilarityTypes.MinorLong);
            }

            return StringSimilarityTypes.Any;
        }
    }

    public static partial class StringsExtensions
    {
        /// <summary>
        /// Evaluate string similarity and return quantitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <param name="similarityMinimal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EvaluateSimilarity(this string text, string ComparisonText, double similarityMinimal)
        {
            return Strings.EvaluateSimilarity(text, ComparisonText, similarityMinimal);
        }

        /// <summary>
        /// Evaluate string similarity and return quantitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <param name="similarityMinimal"></param>
        /// <param name="diffFound"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EvaluateSimilarity(this string text, string ComparisonText, double similarityMinimal, int diffFound)
        {
            return Strings.EvaluateSimilarity(text, ComparisonText, similarityMinimal, diffFound);
        }

        /// <summary>
        /// Evaluate string similarity and return qualitative results.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ComparisonText"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringSimilarityTypes EvaluateSimilarity(this string text, string ComparisonText)
        {
            return Strings.EvaluateSimilarity(text, ComparisonText);
        }
    }
}