using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    float ballspeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        keepConstantVelocity();
    }

    void keepConstantVelocity()
    {
        body.velocity = ballspeed * body.velocity.normalized;
    }
}
