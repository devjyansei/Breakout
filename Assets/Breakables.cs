using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    [SerializeField] public float health;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();     
    }

    void Update()
    {
        ChangeColor();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {health--;}

        if (health <= 0)
        {transform.gameObject.SetActive(false);}
    }
    void ChangeColor()
    {
        if (health >= 3)
        {sr.color = Color.red;}

        else if (health == 2)
        {sr.color = Color.yellow;}

        else
        {sr.color = Color.green;}
    }
}
