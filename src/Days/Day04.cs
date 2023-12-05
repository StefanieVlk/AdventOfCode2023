using Common;

namespace Days;

public class Day04
{
    private readonly List<string> myIntput = PuzzleInput.Read("day04.txt").ToList();
    private readonly Dictionary<int, List<int>> winningNumbers = new();
    private readonly Dictionary<int, List<int>> availableNumbers = new();
    private Dictionary<int, (int score, int countWinningNumbers, int cardCopies)> cardStats = new();

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
            var currentScore = CalculateScore(cardNumber, out int countWinningNumbers);
            cardStats.Add(cardNumber, (currentScore, countWinningNumbers, 1));
            totalScore += currentScore;
        }
        return totalScore;
    }

    public int ExecuteTask2()
    {
        for(int i = 1; i <= cardStats.Count; i++)
        {
            Console.WriteLine($"Current card: {i}");
            int cardCopyCount = 1;
            while(cardCopyCount <= cardStats[i].cardCopies)
            {
                for(int c = 1; c <= cardStats[i].countWinningNumbers; c++)
                {
                    if(i + c > cardStats.Count)
                    {
                        continue;
                    }
                    var currentStats = cardStats[i+c];
                    int newCardCopiesCount = currentStats.cardCopies + 1;
                    cardStats[i + c] = (currentStats.score, currentStats.countWinningNumbers, newCardCopiesCount);
                    //Console.WriteLine($"Increased count of card {i+c} to {cardStats[i+c].cardCopies}");
                }
                cardCopyCount++;
            }
        }

        return cardStats.Values.Select(x => x.cardCopies).Sum();
    }

    private int CalculateScore(int cardNumber, out int countWinningNumbers)
    {
        var score = 0;
        countWinningNumbers = 0;
        foreach(var number in availableNumbers[cardNumber])
        {
            if(winningNumbers[cardNumber].Contains(number))
            {
                score = IncreaseScore(score);
                countWinningNumbers++;
            }
        }
        return score;
    }

    private static int IncreaseScore(int score)
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