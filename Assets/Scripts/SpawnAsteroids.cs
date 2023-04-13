using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] GameObject Asteroid;
    [SerializeField] float force = 15f;

    int spawnAmount = 4;
    void SpawnAsteroid ()
        {
            
        GameObject newAsteroid = Instantiate(Asteroid, Random.insideUnitCircle.normalized * 5, transform.rotation);

        Rigidbody2D astroForce = newAsteroid.GetComponent<Rigidbody2D>();
        
        astroForce.AddForce(Random.insideUnitCircle.normalized * force); // normalized makes it always 1, remove for random(0-1) * force.
        }
    // Start is called before the first frame update
    void Start()
    {
       
       SpawnAsteroid();
       SpawnAsteroid();
       SpawnAsteroid();

              
        /* GameObject newAsteroid2 = Instantiate(
                Asteroid, transform.position, transform.rotation); */
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Asteroid") == null)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnAsteroid();
                Debug.Log(i);
            }
            spawnAmount++;
            
        }
    }
}
