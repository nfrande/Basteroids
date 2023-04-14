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
    [SerializeField] float thrust = 2;

    [SerializeField] GameObject Player;

    [SerializeField] AudioSource explosion;

    float shield = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");
        rb.AddForce(yInput * transform.up * Time.deltaTime * thrust);

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

        shield -= Time.deltaTime;
        if (shield < 0f && gameObject.GetComponent<Collider2D>().enabled == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            Debug.Log("Shield is off!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
       
       // Debug.Log("Game Over");
       explosion.Play();
       if (UI.instance.lives > 0)
       {
       gameObject.transform.position = Vector3.zero;
       gameObject.transform.rotation = Quaternion.identity;
       gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       gameObject.GetComponent<Collider2D>().enabled = false;
              
       UI.instance.UpdateLives(-1);
       
       // Instantiate(Player);
       Debug.Log(UI.instance.lives);
       shield = 3f;
       Debug.Log("Shield is on!");
       }
       else
       {
        Destroy(gameObject);
        Debug.Log("Game Over!");
       }
       }
}
