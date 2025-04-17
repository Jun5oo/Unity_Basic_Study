using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    WaitForSeconds waitTime = new WaitForSeconds(3); 

    public bool isGameOver; 

    void Awake()
    {
        isGameOver = false; 
    }

    public void GameOver()
    {
        isGameOver = true;
        StartCoroutine(coRestart()); 
    }

    public bool IsGameOver() => isGameOver; 

    IEnumerator coRestart()
    {
        yield return waitTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
