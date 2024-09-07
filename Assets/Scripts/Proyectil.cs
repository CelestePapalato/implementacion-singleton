using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public Vector2 Direccion;

    [SerializeField]
    float timeAlive = 5f;
    [SerializeField]
    float rapidez = 1f;

    public float Rapidez { get => rapidez; set { rapidez = (value > 0) ? value : rapidez; } }

    private void Start()
    {
        Destroy(gameObject, timeAlive);
    }

    private void Update()
    {
        transform.Translate(Direccion * rapidez * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
