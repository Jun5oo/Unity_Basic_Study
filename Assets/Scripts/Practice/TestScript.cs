using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int goal;
    public int currentScore;

    private int tries; 
    private int randomScore;

    private int min = 5;
    private int max = 10; 

    void Awake()
    {
        goal = 50; 
        currentScore = 0; 
        tries = 0; 
        
        Debug.Log($"{goal}점 이상의 점수를 쌓아보세요! Space키를 눌러 점수를 얻으실 수 있습니다.");
    }
    void Update()
    {
        if (currentScore > goal)
            return; 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomScore = Random.Range(min, max + 1);
            currentScore += randomScore;
            tries++; 
            
            Debug.Log("현재 점수: " + currentScore);
            
            if(currentScore > goal)
                Debug.Log($"{tries}번 만에 목표점수보다 높게 쌓았습니다.");
        }    
    }
}
