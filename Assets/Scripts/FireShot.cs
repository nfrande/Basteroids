using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;

    [SerializeField] float shotForce;
    [SerializeField] float lifeTime;
    [SerializeField] float shotPeriod;

    float shotTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && shotTime <= 0f)
        {
            GameObject  newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * shotForce);
            Destroy(newBullet, lifeTime);
            shotTime = shotPeriod;
        }
        shotTime -= Time.deltaTime;
    }

    public void Testi()
    {

    }
}
