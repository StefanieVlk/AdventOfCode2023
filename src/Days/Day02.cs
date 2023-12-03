using Common;

namespace Days;

public class Day02
{
    private readonly List<string> myInput = PuzzleInput.Read("day02.txt").ToList();

    private readonly Dictionary<string, int> availableCubes = new(){
        {"red", 12},
        {"green", 13},
        {"blue", 14}
    };

    public int ExecuteTask1()
    {
        List<int> idsOfPossibleGames = new();

        foreach(var line in myInput)
        {
            var isPossibleGame = true;
            var rounds = line.Split(';');
            var gameIndex = Convert.ToInt32(rounds[0].Split(' ')[1].Trim(':'));
            foreach(var round in rounds)
            {
                var splitRound = round.Split(' ');
                for(int i = 0; i < splitRound.Length; i++)
                {
                    var test = availableCubes.Keys.First();
                    var currentCheck = splitRound[i].Trim(',');
                    
                    if(availableCubes.Keys.Contains(currentCheck))
                    {
                        if(Convert.ToInt32(splitRound[i-1]) > availableCubes[currentCheck])
                        {
                            isPossibleGame = false;
                            break;
                        }
                    }
                }
            }
            if(isPossibleGame)
            {
                idsOfPossibleGames.Add(gameIndex);
            }
        }
        return idsOfPossibleGames.Sum();
    }

    public int ExecuteTask2()
    {
        List<int> powerCubeSet = new();
        foreach(var line in myInput)
        {
            var redCubesPerRound = new List<int>();
            var greenCubesPerRound = new List<int>();
            var blueCubesPerRound = new List<int>();

            var redSplit = line.Split("red");
            var greenSplit = line.Split("green");
            var blueSplit = line.Split("blue");

            for(int i = 0; i < redSplit.Length - 1; i++)
            {
                redCubesPerRound.Add(Convert.ToInt32(redSplit[i].Trim().Split(' ').Last()));
            }

            for(int i = 0; i < greenSplit.Length - 1; i++)
            {
                greenCubesPerRound.Add(Convert.ToInt32(greenSplit[i].Trim().Split(' ').Last()));
            }

            for(int i = 0; i < blueSplit.Length - 1; i++)
            {
                blueCubesPerRound.Add(Convert.ToInt32(blueSplit[i].Trim().Split(' ').Last()));
            }
            powerCubeSet.Add(redCubesPerRound.Max() * greenCubesPerRound.Max() * blueCubesPerRound.Max());
        }

        return powerCubeSet.Sum();
    }
}