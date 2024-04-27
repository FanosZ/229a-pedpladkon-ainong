using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Die();
        }
        
        if (collision.CompareTag("Enermy"))
        {
            Die();
        }
    }

    void Die()
    {
        Respawn();

    }

    void Respawn()
    {
        transform.position = startPos;
    }
}