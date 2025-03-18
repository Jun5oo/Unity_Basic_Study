using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager; 
    [SerializeField] TextMeshProUGUI scoreText; 

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString(); 
    }
}
