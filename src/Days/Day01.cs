using Common;

namespace Days;

public class Day01
{
    private readonly List<string> myInput = PuzzleInput.Read("day01.txt").ToList();

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
}