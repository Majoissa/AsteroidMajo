using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefabBullet;
    public float speedThrusting = 1.0f;
    public float speedTurn = 1.0f;
    public float turnDirection = 0.0f;
    private bool thrusting = false;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shot();
        }

          Teleport();
        
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rb.AddForce(transform.up*speedThrusting);
        }

        if (turnDirection != 0)
        {
            rb.AddTorque(turnDirection*speedTurn);    
        }
    }

    private void Shot()
    {
        GameObject o = Instantiate(prefabBullet, transform.position, transform.rotation, transform);
        Bullet b = o.GetComponent<Bullet>();
        b.Shot(transform.up);
        
    }
private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asteroid")) {
            GameManager.instance.LoseLife();
            
        }
    }

    private void Teleport() {
    var screenPos = Camera.main.WorldToViewportPoint(transform.position);
    if (screenPos.x > 1 || screenPos.x < 0 || screenPos.y > 1 || screenPos.y < 0) {
        transform.position = new Vector2(-transform.position.x, -transform.position.y);
    }
}

}