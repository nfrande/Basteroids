using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAsteroid : MonoBehaviour
{
    [SerializeField] GameObject tinyAsteroid;
    // Start is called before the first frame update

     void OnTriggerEnter2D(Collider2D other) {
        
            if (other.gameObject.tag == "Bullet")
            {
                Destroy(gameObject);
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
