using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score = 0;

    private void Awake()
    {
        _scoreText.text = _score.ToString();
        Enemy.OnKilledScoreCost += AddScore;
    }

    public void AddScore(int enemyCost)
    {
        _score += enemyCost;
        _scoreText.text = _score.ToString();
    }


    private void OnDestroy()
    {
        Enemy.OnKilledScoreCost -= AddScore;
    }
}
