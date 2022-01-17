using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game over"); 
            Invoke("Restart",restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
