using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    float ballspeed = 10f;

    [SerializeField]
    AudioSource ballSound, deathSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

  

    private void FixedUpdate()
    {
        keepConstantVelocity();
    }

    void keepConstantVelocity()
    {
        body.velocity = ballspeed * body.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameManager.gameManager.GameOver();
            deathSound.Play();
        }
    }
}
