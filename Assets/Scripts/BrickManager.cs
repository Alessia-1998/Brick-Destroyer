using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField]
    Color oneLifeColor, twoLifeColor, threeLifeColor;

    [SerializeField]
    int hitPoints=3;

    SpriteRenderer sprite;

    AudioSource brickHitSound;

    [SerializeField]
    ParticleSystem brickHitParticles;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ChangeColorOnLife();
        brickHitSound = GetComponent<AudioSource>();

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            hitPoints --;
            ChangeColorOnLife();
            brickHitSound.Play();
            brickHitParticles.Play();

            Vector3 collisionPoint = new Vector3( collision.contacts[0].point.x, collision.contacts[0].point.y );
            Vector3 ballDir = collision.gameObject.transform.position - collisionPoint;
            brickHitParticles.gameObject.transform.rotation = Quaternion.LookRotation( ballDir.normalized, Vector3.back );
            brickHitParticles.transform.position = collisionPoint;

            if( hitPoints <= 0 )
            {
                GameManager.gameManager.BrickDestroyed();
                Destroy(gameObject);
            }
        }
    }

    void ChangeColorOnLife()
    {
        switch(hitPoints)
        {
            case 1:
                sprite.color = oneLifeColor;
                break;
            case 2:
                sprite.color = twoLifeColor;
                break;
            case 3:
                sprite.color = threeLifeColor;
                break;
            default:
                sprite.color = oneLifeColor;
                break;
        }

        ParticleSystem.MainModule particleModule = brickHitParticles.main;
        particleModule.startColor = sprite.color;
    }
}
