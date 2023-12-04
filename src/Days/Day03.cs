using Common;

namespace Days;

public class Day03
{
    private readonly string[] myInput = PuzzleInput.Read("day03.txt");
    private char[,]? inputAsChars;

    public int ExecuteTask1()
    {
        // read input data into 2D char array
        inputAsChars = new char[myInput.Length,myInput[0].Length];
        for(int i = 0; i < myInput.Length; i++)
        {
            var line = myInput[i].ToCharArray();
            for(int j = 0; j < line.Length; j++)
            {
                inputAsChars[i,j] = line[j];
            }
        }

        var result = 0;
        for(int row = 0; row < inputAsChars.GetLength(0); row++)
        {
            for(int column = 0; column < inputAsChars.GetLength(1); column++)
            {
                if(char.IsDigit(inputAsChars[row, column]))
                {
                    var indicesCoveredByCurrentNumber = GetArrayPositionsCoveredByNumber(row, column, out int number);
                    column += indicesCoveredByCurrentNumber.Count - 1;
                    if(IsPartNumber(indicesCoveredByCurrentNumber))
                    {
                        result+=number;
                    }
                }
            }
        }

        return result;
    }

    private List<(int, int)> GetArrayPositionsCoveredByNumber(int indexRow, int startingIndexColumn, out int number)
    {
        var coveredPositions = new List<(int, int)>
        {
            (indexRow, startingIndexColumn)
        };

        var singleDigitsOfNumber = new List<int>
        {
            Convert.ToInt32(new string(inputAsChars![indexRow, startingIndexColumn], 1))
        };

        while(true)
        {
            if(startingIndexColumn == inputAsChars?.GetLength(1) - 1)
            {
                break;
            }
            startingIndexColumn++;
            if(char.IsDigit(inputAsChars![indexRow, startingIndexColumn]))
            {
                coveredPositions.Add((indexRow, startingIndexColumn));
                singleDigitsOfNumber.Add(Convert.ToInt32(new string(inputAsChars![indexRow, startingIndexColumn], 1)));
            }
            else
            {
                break;
            }

        }
        
        var numberOfDigits = singleDigitsOfNumber.Count;
        number = 0;
        foreach(var digit in singleDigitsOfNumber)
        {
            number += Convert.ToInt32(digit * Math.Pow(10, numberOfDigits - 1));
            numberOfDigits--;
        }

        return coveredPositions;
    }

    private bool IsPartNumber(List<(int, int)> indicesCoveredByNumber)
    {
        for(int i = 0; i < indicesCoveredByNumber.Count; i++)
        {
            var checkedIndex = indicesCoveredByNumber[i];
            for(int rowAdapt = -1; rowAdapt <= 1; rowAdapt++)
            {
                for(int columnAdapt = - 1; columnAdapt <= 1; columnAdapt++)
                {
                    var neighbouringChar = '.';
                    try{
                        neighbouringChar = inputAsChars![checkedIndex.Item1 + rowAdapt, checkedIndex.Item2 + columnAdapt];
                    } catch(Exception){}
                    
                    if(neighbouringChar != '.' && !char.IsDigit(neighbouringChar))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}