using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager; 
    public Action<float> keyPressed; 

    void Update()
    {
        if (gameManager.IsGameOver())
            return; 

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            keyPressed?.Invoke(-1f); 
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            keyPressed?.Invoke(1f); 
    }
}
