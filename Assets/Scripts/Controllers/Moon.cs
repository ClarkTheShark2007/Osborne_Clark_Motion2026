using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    int i;
    public int pointsToOrbit = 18;
    public float orbitSpeed;
    public int Radius;
    public Vector2 orbitPoint;
    int angle;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        angle = 360/pointsToOrbit; //What angle should be choosen around the radius

        //Gets the point that the Moon will move using the angle and moves in the direction of it
        orbitPoint = (Vector2) planetTransform.position + (new Vector2(Mathf.Cos((angle * i) * Mathf.Deg2Rad), Mathf.Sin((angle * i) * Mathf.Deg2Rad)) * Radius);
        transform.position += ((Vector3)orbitPoint - transform.position).normalized * orbitSpeed * Time.deltaTime;

        //If I is bigger the total points, reset orbit 
        if(Vector2.Distance(transform.position, orbitPoint) <= 0.1f)
        {
            i++;
            if(i > pointsToOrbit)
            {
                i = 0;
            }
        }
    }
}
