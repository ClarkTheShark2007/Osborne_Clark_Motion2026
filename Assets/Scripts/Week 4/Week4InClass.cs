using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Week4InClass : MonoBehaviour
{
    //float degrees = 90f;
    //float radians = degrees * Mathf
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<float> angle = new List<float>();
    public float Radius;
    [SerializeField] int i;
    public Vector2 offset;
    float timer;

    void Start()
    {
        //float FortyFiveDegrees = 45f;
        ////How to convert from degree to radian
        //float FortyFiveDInRadians = FortyFiveDegrees * Mathf.Deg2Rad;

        //float twoPiRadians = 2 * Mathf.PI;
        ////How to convert from radian to degree
        //float ttprInDegrees = twoPiRadians * Mathf.Rad2Deg;


        //Mathf.Cos(FortyFiveDegrees * Mathf.Deg2Rad) NEEDS TO BE RADIANS
        //Mathf.Sin()

        //How to get a Vector2 x/y to spit out an angle, this is of course is in Radians
        //Mathf.Atan2(Vector2.zero.x, Vector2.one.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Radians are much harder to visualize but you need them for the for what we just did
        //Dont know why we need angle of a vecotr

        timer += Time.deltaTime;

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            i++;
        }

        if(timer >= 2)
        {
            timer = 0;
            i++;
        }

        if (i >= angle.Count)
        {
            i = 0;
        }

        Vector2 Point = new Vector2(Mathf.Cos(angle[i] * Mathf.Deg2Rad), Mathf.Sin(angle[i] * Mathf.Deg2Rad)) * Radius;
        Debug.DrawLine(offset, Point + offset);
    }
}
