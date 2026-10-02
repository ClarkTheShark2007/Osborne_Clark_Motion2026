using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Week4Journal : MonoBehaviour
{
    //List<float> circlePoints = new List<float>();
    public int numberOfCirclePoints;
    public int numberOfPowerUps;
    public float Radius;
    Color RadarColour;
    public Transform enemy;
    public GameObject powerUp;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RadarColour = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        playerRadar();

        if(Keyboard.current.pKey.wasPressedThisFrame)
        {
            powerUps();
        }
    }

    void powerUps()
    {
        int angle = 360 / numberOfPowerUps;

        //Instatiate a powerup prefab around the player within a radius using the angle above
        for (int i = 1; i < numberOfPowerUps + 1; i++)
        {
            Vector2 powerUpSpawn = new Vector2(Mathf.Cos((angle * i) * Mathf.Deg2Rad), Mathf.Sin((angle * i) * Mathf.Deg2Rad)) * Radius;
            GameObject spawnedPowerUp = Instantiate(powerUp);
            spawnedPowerUp.transform.position = powerUpSpawn + (Vector2) transform.position;
        }
    }

    void playerRadar ()
    {
        //Checks for distance to see if the player and enemy are close enough to make lines red
        if (Vector2.Distance(transform.position, enemy.position) <= Radius)
        {
            RadarColour = Color.red;
        }

        //Used 45 and multiply it by number of points 
        for (int i = 1; i < numberOfCirclePoints + 1; i++)
        {
            int angle = 360 / numberOfCirclePoints;

            //Gets the current point and the one next so it can connect a line togther
            Vector2 FirstPoint = new Vector2(Mathf.Cos((angle * i) * Mathf.Deg2Rad), Mathf.Sin((angle * i) * Mathf.Deg2Rad)) * Radius;
            Vector2 SeccondPoint = new Vector2(Mathf.Cos((angle * (i + 1)) * Mathf.Deg2Rad), Mathf.Sin((angle * (i + 1)) * Mathf.Deg2Rad)) * Radius;
            Debug.DrawLine(FirstPoint + (Vector2)transform.position, SeccondPoint + (Vector2)transform.position, RadarColour);
        }

        //Resets colour to green, which can be changed immeditaley if the enemy is too close to the players radius
        RadarColour = Color.green;
    }

    
}
