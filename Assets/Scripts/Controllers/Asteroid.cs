using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public Vector2 arivalLocation;
    public Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        arivalLocation = new Vector2(transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance), transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance));
        //movementDirection = Vector2.Distance(arivalLocation, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.Normalize(movementDirection);
        //movementDirection = arivalLocation * moveSpeed * Time.deltaTime;
        //transform.position = (Vector2) transform.position + movementDirection * Time.deltaTime;

        //transform.position += Vector3.Lerp(transform.position, arivalLocation, moveSpeed) * Time.deltaTime;

        if (transform.position.magnitude < maxFloatDistance)
        {
            arivalLocation = new Vector2(transform.position.x + maxFloatDistance, transform.position.y + maxFloatDistance);
        }
    }
}
