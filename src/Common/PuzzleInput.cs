namespace Common;

public static class PuzzleInput {
    public static string[] Read(string fileName)
    {
        return File.ReadAllLines(Path.Combine("Data", fileName));
    }
}