using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float RestartDelay = 5f;
    public GameObject LevelCompleted;
    private bool _gameHasEnded = false;

    public void EndGame()
    {
        if (_gameHasEnded) return;

        _gameHasEnded = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        Invoke("Restart", RestartDelay);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        LevelCompleted.SetActive(true);
        Invoke("Restart", RestartDelay);
    }
}
 