using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager; 
    [SerializeField] InputManager inputManager;

    [SerializeField] Player player;

    [SerializeField] GameObject stairPrefab;
    [SerializeField] GameObject stairParent; 
    [SerializeField] GameObject ground; 
    
    [SerializeField] int stairNum = 15;
    
    float playerHeight;
    float stairHeight;
    float stairIntervalX;
    float stairIntervalY;

    float cameraBoundY = -5.5f;  

    List<GameObject> stairList = new List<GameObject>();

    void Awake()
    {
        playerHeight = player.GetComponent<BoxCollider2D>().size.y;
        stairHeight = stairPrefab.GetComponent<BoxCollider2D>().size.y;

        stairIntervalX = 2f;
        stairIntervalY = 1.5f; 

        Init();

        inputManager.keyPressed += MoveStairs; 
    }

    void Init()
    {
        Vector3 stairPos = new Vector3(0, (playerHeight + stairHeight)/2);
        
        GameObject firstStair = Instantiate(stairPrefab, stairPos + new Vector3(GetRandomX(), 0), Quaternion.identity);
        firstStair.transform.parent = stairParent.transform; 
        firstStair.name = $"stair0"; 
        stairList.Add(firstStair);

        for(int i=1; i<stairNum; i++)
        {
            GameObject nextStair = Instantiate(stairPrefab);
            nextStair.transform.position = stairList[stairList.Count - 1].transform.position + new Vector3(GetRandomX(), stairIntervalY);
            nextStair.name = $"stair{i}";
            nextStair.transform.parent = stairParent.transform;
            stairList.Add(nextStair);
        }
    }

    float GetRandomX()
    {
        return Random.Range(0, 2) == 0 ? -stairIntervalX : stairIntervalX; 
    }

    void MoveStairs(float xInput)
    {
        for (int i = 0; i < stairNum; i++)
            stairList[i].transform.position += new Vector3(xInput * -stairIntervalX, -stairIntervalY);

        ground.transform.position -= Vector3.one * stairIntervalY;

        if (ground.transform.position.y < cameraBoundY)
            ground.SetActive(false); 

        if (stairList[0].transform.position.y < cameraBoundY)
        {
            GameObject go = stairList[0];
            stairList.RemoveAt(0);
            go.transform.position = stairList[stairList.Count - 1].transform.position + new Vector3(GetRandomX(), stairIntervalY); 
            stairList.Add(go);
        }

        Physics2D.SyncTransforms();
        player.CheckPlayerOnStair(); 
    }

}
