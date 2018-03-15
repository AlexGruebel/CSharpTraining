using System;
using System.Text.RegularExpressions;

namespace SharedLibaray{

    public static class StringExtension{

        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }

        public static bool IsValidPassword(this string input){
            return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
        }
    }
}
