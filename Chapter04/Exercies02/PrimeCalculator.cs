using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Exercies02
{
    public class PrimeCalculator
    {

        public PrimeCalculator(){
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            Trace.AutoFlush = true;
        }

        public bool CheckPrimeNummber(int nummber){
            bool output = true;
            for(int i = 2; i < 9;i++){
                if(nummber != i && nummber / i * i == nummber){
                    output = false;
                    break;
                }
            }
            return output;
        }

        public int GetNextBiggerPrimeNummber(int nummber){
            while(!CheckPrimeNummber(++nummber));
            return nummber;
        }

        public String GetPrimeFactor(int nummber){
            Trace.WriteLine(message: $"Start Executing GetPrimeFactor; {DateTime.Now}");
            String output = $"Prime factors of {nummber} are: ";
            
            int getNextD(int n, int startP = 2){
                if(n != (n / startP) * startP){
                    startP = getNextD(n, GetNextBiggerPrimeNummber(startP));
                }

                return startP;
            }
            
            ArrayList list = new ArrayList();
            int nextN = nummber;
            int sum = 0;
            do{
                int tmp = getNextD(nextN); 
                list.Add(getNextD(tmp));
                sum = sum != 0 ? sum * tmp : tmp;
                nextN /= tmp;
            }while(sum != nummber || sum < nummber);

            foreach(int i in list){
                output += $"{i} x ";
            }

            Trace.WriteLine(message: $"Finish Executing GetPrimeFactor; {DateTime.Now}");
            return output.Substring(0, output.Length -3);
        }

        static void Main(string[] args){
            Object t;
            PrimeCalculator t = new PrimeCalculator();
            Console.WriteLine(t.GetPrimeFactor(1000));
        }
    }
}
