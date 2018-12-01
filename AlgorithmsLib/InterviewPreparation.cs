using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLibrary
{
    public class InterviewPreparation
    {
       public string ReverseString(string input)
       {
           if (String.IsNullOrEmpty(input)) 
                return "";
        
           var output = "";
           for (var i = input.Length - 1; i >= 0; i--)
           {
               output += input[i];
           }

           return output;
       } 

#region Number to words
        private readonly string[] numbers_0to9 = {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };
        private readonly string[] numbers_10to19 = {
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
            "nineteen"
        };
        private readonly string[] numbers_Tens = {
            "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };
        private readonly string[] numbers_Hundreds = {
            "hundred", "thousand", "million", "trillon"
        };

        public string TurnNumberToWord(int input)
        {
            var output = "";

            int[] digits = ConvertNumberToDigits(input);
            
            var segment = 0;
            var container = new Stack<int>(); //last in first out

            for (var i = digits.Length-1; i >= 0; i--)
            {
                container.Push(digits[i]);

                if (container.Count == 3 
                    || (container.Count < 3 && i == 0))
                {
                    var temp = Turn3digitsIntegerIntoWord(
                        FormIntegerFromDigits( container.ToArray()));
                    if (segment > 0 && temp != "zero")
                    {
                        temp += ' ' + numbers_Hundreds[segment] + ' ';
                    }
                    if (temp != "zero")
                        output = output.Insert(0, temp);

                    segment++;
                    container.Clear();
                }
            }


            return output.Trim();
        }

        public string Turn3digitsIntegerIntoWord(int input)
        {
            //input is a number between [0, 999)
            //output is words, such as: one hundred twenty three
            if (input < 0) return null;

            var output = "";
            int firstDigit, secondDigit, lastDigit;

            switch (digitCount(input))
            {
                case 1:
                    output = numbers_0to9[input];
                    break;
                case 2:
                    firstDigit = input / 10;
                    lastDigit = input % 10;
                    if (firstDigit == 1)
                    {
                        output = numbers_10to19[lastDigit];
                    } else 
                    {
                        if (lastDigit == 0)
                        {
                            output = numbers_Tens[firstDigit - 2];
                        } else
                        {
                            output = numbers_Tens[firstDigit - 2] + ' ' + numbers_0to9[lastDigit];
                        }
                    }      
                    break;
                case 3:
                    firstDigit = input / 100;
                    secondDigit = input / 10 % 10;
                    lastDigit = input % 10;

                    if (firstDigit == 0 && secondDigit == 0 && lastDigit == 0)
                    {
                        output = "";
                        break;
                    }
                    if (secondDigit == 0 && lastDigit == 0)
                    {
                        output = numbers_0to9[firstDigit] + ' '
                            + numbers_Hundreds[0];
                        break;
                    }
                    if (secondDigit == 0 && lastDigit != 0)
                    {
                         output = numbers_0to9[firstDigit] + ' '
                            + numbers_Hundreds[0] + " and " 
                            + numbers_0to9[lastDigit];
                        break;                       
                    }
                    if (secondDigit == 1)
                    {
                         output = numbers_0to9[firstDigit] + ' '
                            + numbers_Hundreds[0] + " and " 
                            + numbers_10to19[lastDigit];
                        break;       
                    }

                    output = numbers_0to9[firstDigit] + ' '
                            + numbers_Hundreds[0] + ' '
                            + numbers_Tens[secondDigit - 2] + ' '
                            + numbers_0to9[lastDigit];
                    break;              
            }

            return output;
        } 

        public int digitCount(int num)
        {
            //input 56, should return 2;
            //input 38228, should return 5;
            var numstr = num.ToString();
            return numstr.Length;
        }
       #endregion

#region Regex 


#endregion
        // methods to find patterns in a string



    public int[] ConvertNumberToDigits(int num)
    {
        return num.ToString().ToCharArray().Select(a => a - '0').ToArray();

    }

    public int FormIntegerFromDigits(int[] nums)
    {
        if (nums == null)
            return -1;

        var output = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var power = nums.Length - (i + 1);
            output += nums[i]* (int)Math.Pow(10, power);
        }
        return output;
    }

    //https://dotnetcodr.com/2015/11/03/divide-an-integer-into-groups-with-c/
    public static IEnumerable<int> DistributeInteger(int total, int divider)
    {
        if (divider == 0)
        {
            yield return 0;
        }
        else
        {
            int rest = total % divider;
            double result = total / (double)divider;
    
            for (int i = 0; i < divider; i++)
            {
                if (rest-- > 0)
                    yield return (int)Math.Ceiling(result);
                else
                    yield return (int)Math.Floor(result);
            }
        }
    }      

    }
}