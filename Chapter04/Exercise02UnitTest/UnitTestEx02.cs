using System;
using Xunit;
using Exercies02; 
namespace UnitTestEx02
{
    public class UnitTest1{

        /*
        Arrange --> Variabel declarieren
        Act --> die Werte ausrechnen
        Asert --> die Werte vergleichen
         */

        PrimeCalculator calc = new PrimeCalculator();
        [Fact]
        public void TestCheckPrimeNummber(){
            Assert.Equal(false, calc.CheckPrimeNummber(10));
            Assert.Equal(true, calc.CheckPrimeNummber(7));

        }

        [Fact]
        public void TestGetNextBiggerPrimeNummber(){
            Assert.Equal(5, calc.GetNextBiggerPrimeNummber(3));
            Assert.False(8 == calc.GetNextBiggerPrimeNummber(5));
        }


        [Fact]
        public void TestGetPrimeFactor(){
            Assert.Equal("Prime factors of 4 are: 2 x 2", calc.GetPrimeFactor(4));
            Assert.Equal("Prime factors of 50 are: 2 x 5 x 5", calc.GetPrimeFactor(50));
        }
    }
}
