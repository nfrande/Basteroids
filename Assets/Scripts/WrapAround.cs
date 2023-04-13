using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
float halfScreenWidth = 8.9f;
float halfScreenHeight = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 xVec = Vector3.right * halfScreenWidth * 2;
        Vector3 yVec = Vector3.up * halfScreenHeight * 2;

        if (transform.position.x > halfScreenWidth)
        transform.position -= xVec;
        if (transform.position.x < -halfScreenWidth)
        transform.position += xVec;
       
        if (transform.position.y > halfScreenHeight)
        transform.position -= yVec;
        if (transform.position.y < -halfScreenHeight)
        transform.position += yVec;
    

    }
}
