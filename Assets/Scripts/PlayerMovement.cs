using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    Rigidbody2D rb;

     public ParticleSystem particles;
    [SerializeField] float maxAngularVelocity = 90;
   // [SerializeField] float thrust = 90;
    [SerializeField] float torque = 90;

    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float yInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");
        rb.AddForce(yInput * transform.up);

        if (Mathf.Abs(rb.angularVelocity) <= maxAngularVelocity)
        {
            rb.AddTorque(- rotateInput * Time.fixedDeltaTime * torque);
        }
        else
        {
            rb.angularVelocity = Mathf.Clamp(
                    rb.angularVelocity,
                    -maxAngularVelocity,
                    maxAngularVelocity 
            );
        }
       if (yInput > 0f)
       {
            if (!particles.isEmitting)
            {
                particles.Play();
            }
       }
       else 
       {
            if (particles.isEmitting)
                particles.Stop();
       }

        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        Debug.Log("Game Over");
       }
}
