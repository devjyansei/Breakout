using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] LevelManager levelmanager;
    private void Awake()
    {
        //levelmanager = FindObjectOfType<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        float randomForce = Random.value > 0.5f ? 1 : -1;   // random.value 0 ve 1 arasý random deger döndürür. deðer 0.5ten büyükse 1, deðilse -1 döndürecek.
        Vector2 forceDirection = new Vector2(randomForce,-1);
        rb.AddForce(forceDirection.normalized*speed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("GameOver"))
        {
            Debug.Log("GAME OVER !");
            Time.timeScale = 0;
        }
        if (other.transform.CompareTag("Breakable"))
        {
            if (levelmanager.CheckWin())
            {
                Debug.Log("WIN ! ");
                Time.timeScale = 0;
            } 
        }
    }
}
