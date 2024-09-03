using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public Vector2 Direccion;

    [SerializeField]
    float timeAlive = 5f;

    public float Rapidez { get => Rapidez; set { Rapidez = (value > 0) ? value : Rapidez; } }

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Rapidez * Direccion;
        Destroy(gameObject, timeAlive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
