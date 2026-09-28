using UnityEngine;
using System.Collections.Generic;

public class Week4Journal : MonoBehaviour
{
    //List<float> circlePoints = new List<float>();
    int numberOfCirclePoints = 8;
    float angle = 45;
    public float Radius;
    Color RadarColour;
    public Transform enemy;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RadarColour = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        playerRadar();
    }

    void playerRadar ()
    {

        if (Vector2.Distance(transform.position, enemy.position) <= Radius)
        {
            RadarColour = Color.red;
        }

        //Used 45 and multiply it by number of points 
        for (int i = 1; i < numberOfCirclePoints + 1; i++)
        {
            Vector2 FirstPoint = new Vector2(Mathf.Cos((angle * i) * Mathf.Deg2Rad), Mathf.Sin((angle * i) * Mathf.Deg2Rad)) * Radius;
            Vector2 SeccondPoint = new Vector2(Mathf.Cos((angle * (i + 1)) * Mathf.Deg2Rad), Mathf.Sin((angle * (i + 1)) * Mathf.Deg2Rad)) * Radius;
            Debug.DrawLine(FirstPoint + (Vector2)transform.position, SeccondPoint + (Vector2)transform.position, RadarColour);
        }

        RadarColour = Color.green;
    }

    
}
