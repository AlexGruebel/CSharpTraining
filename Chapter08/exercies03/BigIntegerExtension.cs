using System;
using System.Collections.Generic;
using System.Numerics;

namespace exercies03{
    public static class BigIntegerExtension{
        
        public static string ToWords(this BigInteger e){
            string number = e.ToString();
            var numbersL = new Dictionary<int, string>();
            numbersL.Add(3, "hundred");
            numbersL.Add(4, "thousand");
            numbersL.Add(7, "million");
            numbersL.Add(9, "milliard");
            numbersL.Add(12, "billion");

            Dictionary<int, string> numbers = new Dictionary<int, string>();
            numbers.Add(1, "one");
            numbers.Add(2, "two");
            numbers.Add(3, "three");
            numbers.Add(4, "four");
            numbers.Add(5, "five");
            numbers.Add(6, "six");
            numbers.Add(7, "seven");
            numbers.Add(8, "eight");
            numbers.Add(9, "nine");
            numbers.Add(10, "teen");
            numbers.Add(11, "eleven");
            numbers.Add(12, "twelve");
            numbers.Add(13, "thirteen");
            numbers.Add(20, "twenty");
            numbers.Add(30, "thirty");
            numbers.Add(40, "fourty");
            numbers.Add(50, "fifty");
            numbers.Add(60, "sixty");
            numbers.Add(70, "seventy");
            numbers.Add(80, "eighty");
            numbers.Add(90, "ninety");

            string output = "";
            int len = number.Length;
            if(len <= 2){
                output = GetNumberToNineNine(number);
            }else{
                int x = 0;
                /*
                do{
                    int i = 0;
                    number = number.Substring(x, number.Length -x);
                    len = number.Length;
                    Console.WriteLine($"{len} {number}");
                    while(!numbersL.ContainsKey(len - i) && len > 2){i++;};
                    if(x != 0){
                        output+= " and ";
                    }
                    Console.WriteLine(i);
                    output += GetNumberToNineNine(number.Substring(0,len <= 2 ? len :i+1));
                    if(len >= 3){
                        output += " " + numbersL[len -i];
                    }
                    x=i + 1;
                }while(len >2);
                    */ 
                test(ref x, number);
            }

            void test(ref int x, string str){
                do{
                    int i = 0;
                    str = str.Substring(x, str.Length -x);
                    len = str.Length;
                    Console.WriteLine($"{len} {str}");
                    while(!numbersL.ContainsKey(len - i) && len > 2){i++;};
                    if(x != 0){
                        output+= " and ";
                    }
                    Console.WriteLine($"{i} {str}");

                    if(i >= 2){
                        test(ref x, str.Substring(0, i +1));
                    }else{
                        output += GetNumberToNineNine(number.Substring(0,len <= 2 ? len :i+1));
                    }
                    if(len >= 3){
                        output += " " + numbersL[len -i];
                    }
                    x=i + 1;
                }while(len >2);
            }

            string GetNumberToNineNine(string gnnumber){
                string gnoutput = "";
                if(gnnumber.Length>2){
                    throw new Exception("to much length");
                }
                byte nI = Convert.ToByte(gnnumber);
                if(numbers.ContainsKey(nI)){
                    gnoutput = numbers[nI];
                }else{
                    gnoutput = numbers[Convert.ToByte(gnnumber.Substring(0,1) + "0")];
                    gnoutput += numbers[Convert.ToByte(gnnumber.Substring(1,1))];
                }
                return gnoutput;
            }
             
            return output;
        }
    }
}