using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    [SerializeField] GameObject shield;

    [SerializeField] GameObject ExplosionSound;

    float shieldTime = 3f;

    Collider2D shieldStatus; 

    // Start is called before the first frame update
    void Start()
    {
        shieldStatus = gameObject.GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponent<ParticleSystem>();
        // shield.SetActive(false);
        ResetShield();
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

        shieldTime -= Time.deltaTime;
        if (shieldTime < 0f && shieldStatus.enabled == false)
        {
            shieldStatus.enabled = true;
            Debug.Log("Shield is off!");
            shield.SetActive(false);
        }

         if (Input.GetKeyDown(KeyCode.Escape))
       {
        Application.Quit();
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
       shieldTime = 3f;
       Debug.Log("Shield is on!");
       shield.SetActive(true);
       }
       else
       {
        Destroy(gameObject);
        Debug.Log("Game Over!");
        GameObject newExplosionSound = Instantiate(ExplosionSound);
        Destroy(newExplosionSound, 3);
        SceneManager.LoadScene("GameOver");
       }
       }

       public void ResetShield()
       {
        gameObject.GetComponent<Collider2D>().enabled = false;
        Debug.Log("Shield is on!");
        shieldTime = 3f;
        shield.SetActive(true);
       }
}
