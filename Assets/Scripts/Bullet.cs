using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f; 
    private Rigidbody2D rb;
    public AudioClip shootSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Obtener el componente AudioSource y asegúrate de que los clips estén asignados
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootSound;
        // Reproduce el sonido de disparo
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot(Vector2 direction)
    {
        rb.AddForce(direction*speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
