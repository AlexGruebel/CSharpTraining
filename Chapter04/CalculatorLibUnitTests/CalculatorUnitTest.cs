using System;
using Xunit;
using CalculatorLib;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTest{
        [Fact]
        public void addingTwoAndTwo(){
            Calculator calc = new Calculator();
            double actual =  calc.Add(2, 2);
            double expected = 4;            
            Assert.Equal(expected, calc.Add(2, 2));
        }

        [Fact]
        public void addingTwoAndThree(){
            //Arrange
            Calculator calc = new Calculator();
            double expected = 5;
            //Act
            double actual = calc.Add(2, 3);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
