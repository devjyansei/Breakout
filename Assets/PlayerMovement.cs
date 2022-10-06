using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(-10, 10)] float xBounds = 7.2f;
    [SerializeField] [Range(-10, 10)] float speed;
    
    void Update()
    {
        Movement();

        Vector3 position = transform.position;        
        position.x = Mathf.Clamp(position.x, -xBounds, xBounds);
        transform.position = position;
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position += horizontal * Vector3.right;   // Vector3(1,0,0) * 1 yada -1
    }
}
