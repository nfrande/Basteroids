using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAsteroid : MonoBehaviour
{
    [SerializeField] GameObject tinyAsteroid;
    [SerializeField] GameObject ExplosionSound;
    

    // Start is called before the first frame update

     void OnTriggerEnter2D(Collider2D other) {
        
            if (other.gameObject.tag == "Bullet")
            {
               GameObject newExplosionSound = Instantiate(ExplosionSound);
                Destroy(newExplosionSound, 3);
                Destroy(gameObject);
                
                UI.instance.UpdateScore(300);
            }
     }
    void Start()
    {
        tinyAsteroid.gameObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized * 25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
