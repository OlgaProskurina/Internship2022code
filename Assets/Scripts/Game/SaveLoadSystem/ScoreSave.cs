[System.Serializable]
public class ScoreSave
{
    private int _lastScore;
    private int _highScore;

    public ScoreSave(int lastScore, int hightScore)
    {
        _lastScore = lastScore;
        _highScore = hightScore;
    }
}
