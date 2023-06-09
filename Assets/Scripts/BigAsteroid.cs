using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
    [SerializeField] GameObject tinyAsteroid;

    [SerializeField] GameObject ExplosionSound;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other) {
        
            if (other.gameObject.tag == "Bullet")
            {
                
                Destroy(gameObject);
                GameObject newExplosionSound = Instantiate(ExplosionSound);
                Destroy(newExplosionSound, 3);
                
                UI.instance.UpdateScore(100);
                if (pos1 != null)
                Instantiate(tinyAsteroid, pos1.position, transform.rotation);
                if (pos2 != null)
                Instantiate(tinyAsteroid, pos2.position, transform.rotation);
                if (pos3 != null)
                Instantiate(tinyAsteroid, pos3.position, transform.rotation);
            }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
