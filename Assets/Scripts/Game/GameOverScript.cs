using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Text _totalScore;


    private void Awake()
    {
        _gameOverMenu.SetActive(false);
    }

    public void GameOver(int totalScore)
    {
        Time.timeScale = 0f;
        _gameOverMenu.SetActive(true);
        _totalScore.text = totalScore.ToString();
    }


    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
