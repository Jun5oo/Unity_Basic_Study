using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager; 
    int score;


    void Awake()
    {
        score = 0;     
    }

    public void UpdateScore(int addScore) 
    {
        score += addScore;
        uiManager.UpdateScoreText(GetScore()); 
    }

    public int GetScore() => score; 
}
