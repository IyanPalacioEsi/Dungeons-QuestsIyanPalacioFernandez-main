using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    private int direction = 1; // Dirección inicial

    void Update()
    {
        // Movimiento horizontal
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Cambiar de dirección si choca con una pared
        if (other.CompareTag("Wall"))
        {
            direction *= -1;
            Flip();
        }
    }

    void Flip()
    {
        // Voltear el sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
