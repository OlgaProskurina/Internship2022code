using UnityEngine;

public class PauseScript : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
    }

  
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }


    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}
