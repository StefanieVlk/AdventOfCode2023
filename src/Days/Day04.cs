using Common;

namespace Days;

public class Day04
{
    private readonly List<string> myIntput = PuzzleInput.Read("day04.txt").ToList();
    private readonly Dictionary<int, List<int>> winningNumbers = new();
    private readonly Dictionary<int, List<int>> availableNumbers = new();

    public int ExecuteTask1()
    {
        var totalScore = 0;
        foreach(var line in myIntput)
        {
            var cardNumber = Convert.ToInt32(line.Split(':')[0].Split(' ').Last());
            var winning = line.Split(':')[1].Split('|')[0].Split(' ').ToList().Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList();
            var available = line.Split(':')[1].Split('|')[1].Split(' ').ToList().Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList();
            winningNumbers.Add(cardNumber, winning);
            availableNumbers.Add(cardNumber, available);
        }

        foreach(var cardNumber in availableNumbers.Keys)
        {
            totalScore += CalculateScore(cardNumber);
        }
        return totalScore;
    }

    private int CalculateScore(int cardNumber)
    {
        var score = 0;
        foreach(var number in availableNumbers[cardNumber])
        {
            if(winningNumbers[cardNumber].Contains(number))
            {
                score = IncreaseScore(score);
            }
        }
        return score;
    }

    private int IncreaseScore(int score)
    {
        if(score == 0)
        {
            return 1;
        }
        else
        {
            return 2 * score;
        }
    }

}