using Common;

namespace Days;

public class Day01
{
    private readonly List<string> myInput = PuzzleInput.Read("day01.txt").ToList();

    readonly List<string> writtenDigits = new(){"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

    public int ExecuteTask1()
    {
        var result = 0;
        foreach(var input in myInput)
        {
            var inputAsChars = input.ToCharArray().ToList();
            var digits = inputAsChars.Where(x => char.IsDigit(x));
            result += Convert.ToInt32(new string(digits.First(), 1)) * 10;
            result += Convert.ToInt32(new string(digits.Last(), 1));
        }
        return result;
    }
    
    public int ExecuteTask2()
    {
        var result = 0;
        foreach(var input in myInput)
        {
            Dictionary<int, string> existingWrittenDigits = new();
            foreach(var digit in writtenDigits)
            {
                if(input.Contains(digit))
                {
                    var startIndices = input.AllIndicesOf(digit);
                    foreach(var index in startIndices)
                    {
                        existingWrittenDigits.Add(index, digit);
                    }
                }
            }

            var inputToInvestigate = "";

            var inputAsChars = input.ToCharArray().ToList();

            for(int i = 0; i < inputAsChars.Count; i++)
            {
                if(existingWrittenDigits.Keys.Contains(i))
                {
                    inputToInvestigate += ConvertToInteger(existingWrittenDigits[i]);
                }
                if(char.IsDigit(inputAsChars[i]))
                {
                    inputToInvestigate += inputAsChars[i];
                }
            }

            var digits = inputToInvestigate.ToCharArray().ToList().Where(x => char.IsDigit(x));
            result += Convert.ToInt32(new string(digits.First(), 1)) * 10;
            result += Convert.ToInt32(new string(digits.Last(), 1));
        }
        return result;
    }

    private static string ConvertToInteger(string writtenDigit)
    {
        switch(writtenDigit)
        {
            case "one": 
                return "1";
            case "two":
                return "2";
            case "three":
                return "3";
            case "four":
                return "4";
            case "five":
                return "5";
            case "six":
                return "6";
            case "seven":
                return "7";
            case "eight":
                return "8";
            case "nine":
                return "9";
            default:
                throw new Exception("unexpected Digit!");
        }
    }
}