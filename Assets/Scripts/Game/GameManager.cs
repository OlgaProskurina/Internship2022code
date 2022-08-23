using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameOverScript _gameOverScript;
    [SerializeField] private DropAfterEnemyDeath _heartDrop;

    private int _gameScore = 0;
    private int _enemyAmount;


    private void Awake()
    {
        _enemyAmount = FindObjectsOfType<Enemy>().Length;
        player.GetComponent<Damagaeble>().OnDie.AddListener(GameOver);
        Enemy.OnKilled += Enemy_OnKilled;
        Enemy.OnKilledScoreCost += Enemy_OnKilledScoreCost;        
    }


    private void Enemy_OnKilled(GameObject enemy)
    {
        _heartDrop.DropItemWithChance(enemy.transform.position);
        enemy.SetActive(false);
        _enemyAmount--;
        if(_enemyAmount == 0)
        {
            GameOver();
        }
    }


    private void Enemy_OnKilledScoreCost(int score)
    {
        _gameScore += score;
    }

    
    public void GameOver()
    {
        Debug.Log("Game over");
        _gameOverScript.GameOver(_gameScore);
    }


    private void OnDestroy()
    {
        Enemy.OnKilled -= Enemy_OnKilled;
        Enemy.OnKilledScoreCost -= Enemy_OnKilledScoreCost;
    }
}
