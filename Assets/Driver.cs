using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{   
    // SterializedField переносит переменную в Unity
    // [SerializeField] float steerSpeed = 1f;  // если число целое, то f можно не писать
    // [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 18f;

    [SerializeField] float slowSpeed = 12f;
    [SerializeField] float boostSpeed = 30f; 

    void Update()
    {
        // движение по оси x (steerAmount) и y (moveAmount)
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // вращение по оси x, y, z
        transform.Rotate(0, 0, -steerAmount);

        // движение по оси x, y, z
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;
        }
    }

    
}
