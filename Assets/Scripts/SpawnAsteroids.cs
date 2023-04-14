using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] GameObject Asteroid;
    [SerializeField] float force = 15f;

    public float halfScreenWidth = 8.9f;
    public float halfScreenHeight = 5f;
    int spawnAmount = 3;
    
    /* void SpawnAsteroid ()
        {
            
            GameObject newAsteroid = Instantiate(Asteroid, Random.insideUnitCircle.normalized * 5, transform.rotation);

            Rigidbody2D astroForce = newAsteroid.GetComponent<Rigidbody2D>();

                   
            astroForce.AddForce(Random.insideUnitCircle.normalized * force); // normalized makes it always 1, remove for random(0-1) * force.
        }
    */ 


    // Start is called before the first frame update
    
     void SpawnAsteroidz(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 position;
            int tries = 10;
            do
            {
                position = new Vector2(
                    Random.Range(-halfScreenWidth, halfScreenWidth),
                    Random.Range(-halfScreenHeight, halfScreenHeight)
                );
                tries--;
            }

            while (PositionHasOther(position, 5) && tries >0);

            GameObject newAsteroid = Instantiate(Asteroid, position, Quaternion.identity);
            Rigidbody2D astroForce = newAsteroid.GetComponent<Rigidbody2D>();

                   
            astroForce.AddForce(Random.insideUnitCircle.normalized * force);
        }
    }
    bool PositionHasOther(Vector2 pos, float radius)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        Collider2D[] results = new Collider2D[5];
        int collisions = Physics2D.OverlapCircle(pos, radius, contactFilter, results);
        return collisions > 0;
    }
    void Start()
    {
        SpawnAsteroidz(2);
     /*  
       SpawnAsteroid();
       SpawnAsteroid();
       SpawnAsteroid();
    */
              
        /* GameObject newAsteroid2 = Instantiate(
                Asteroid, transform.position, transform.rotation); */
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Asteroid") == null)
        {
            
                SpawnAsteroidz(spawnAmount);
               // Debug.Log(i);
            
           spawnAmount++;
            
        }
    }

    
}
