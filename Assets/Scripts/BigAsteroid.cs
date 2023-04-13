using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
    [SerializeField] GameObject tinyAsteroid;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other) {
        
            if (other.gameObject.tag == "Bullet")
            {
                Destroy(gameObject);
                Instantiate(tinyAsteroid, pos1.position, transform.rotation);
                Instantiate(tinyAsteroid, pos2.position, transform.rotation);
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
