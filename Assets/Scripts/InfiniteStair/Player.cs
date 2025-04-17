using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    BoxCollider2D bc;
    Rigidbody2D rb; 

    [SerializeField] GameManager gameManager;
    [SerializeField] ScoreManager scoreManager; 
    [SerializeField] LayerMask stairLayer;

    WaitForSeconds waitTime = new WaitForSeconds(1f); 

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>(); 
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 
    }

    public void CheckPlayerOnStair()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position + (Vector3.down * (bc.size.y / 2)), Vector2.down, 0.5f, stairLayer);

        if (hit.collider == null)
        {
            gameManager.GameOver();
            StartCoroutine(coWait()); 
        }

        else
            scoreManager.UpdateScore(1); 
    }

    void OnDrawGizmos()
    {
        if (bc == null)
            bc = GetComponent<BoxCollider2D>();

        Vector3 start = this.transform.position + (Vector3.down * (bc.size.y / 2));
        Vector3 direction = Vector3.down * 0.5f;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(start, direction);
    }

    IEnumerator coWait()
    {
        yield return waitTime;
        rb.gravityScale = 1f;
    }
}
