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
        arivalLocation = (Vector2) transform.position + new Vector2(Random.Range(-1f, 1) , Random.Range(-1f, 1)).normalized * maxFloatDistance;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movementDirection = (arivalLocation - (Vector2) transform.position).normalized * moveSpeed * Time.deltaTime;

        transform.position += (Vector3) movementDirection;

        if (Vector2.Distance(transform.position, arivalLocation) <= arrivalDistance)
        {
            arivalLocation = (Vector2) transform.position + new Vector2(Random.Range(-1f, 1) , Random.Range(-1f, 1)).normalized * maxFloatDistance;
        }
    }
}
