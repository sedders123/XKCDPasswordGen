using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace XKCDPasswordGen
{
    /// <summary>
    /// A helper class to generate XKCD style passwords
    /// </summary>
    public class XkcdPasswordGen
    {
        private static readonly RandomNumberGenerator CryptoRandom;
        private static Random Random { get; }
        internal static readonly string[] Words;

        static XkcdPasswordGen()
        {
            CryptoRandom = RandomNumberGenerator.Create();
            Random = new Random();
            Words = WordsList();
        }

        /// <summary>
        /// Generates an XKCD style password
        /// </summary>
        /// <param name="numWords">Number of words to be included in the password</param>
        /// <param name="separator">String to go inbetween each word (defaults to a space)</param>
        /// <param name="crypto">Use cryptographicaly secure random number generator (Slower than standard random number generator)</param>
        /// <returns>An XKCD style password</returns>
        public static string Generate(int numWords, string separator = " ", bool crypto = true)
        {
            Validator.RequireValidNumber(numWords);

            var words = new List<string>();
            for (var i = 0; i < numWords; i++)
            {
                var randIndex = RandomInteger(0, Words.Length, crypto);
                words.Add(Words[randIndex]);
            }
            return string.Join(separator, words);
        }

        private static int RandomInteger(int min, int max, bool crypto = true)
        {
            return crypto ? RandomCryptoInteger(min, max) : Random.Next(min, max);
        }

        private static int RandomCryptoInteger(int min, int max)
        {
            var scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                var fourBytes = new byte[4];
                CryptoRandom.GetBytes(fourBytes);

                scale = BitConverter.ToUInt32(fourBytes, 0);
            }
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }

        private static string[] WordsList()
        {
            string[] words;

            var assembly = typeof(XkcdPasswordGen).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream("XKCDPasswordGen.EFFLargeWordlist.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var commaSeperatedWords = reader.ReadToEnd();
                    words = commaSeperatedWords.Split(',').ToArray();
                }
            }
            return words;
        }
    }

    internal static class Validator
    {
        public static void RequireValidNumber(int number)
        {
            var maxNumber = XkcdPasswordGen.Words.Length;
            if (number > maxNumber)
            {
                throw new ArgumentOutOfRangeException(string.Format("Number must be less than {0}", maxNumber));
            }
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number must be grater than 0");
            }
        }
    }
}
