using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InClassWeek5 : MonoBehaviour
{
    public List<Transform> objects = new List<Transform>();
    float facingAngle;
    Vector3 facingDirection;
    int i;



    //Angle to Vector

    //Vector to Angle THIS IS WRONG ACOS DOES NOT WORK
    //float firstAngleVectorX = Mathf.Acos(45f * Mathf.Deg2Rad) * Mathf.Rad2Deg;
    //float secondAngleVectorX = Mathf.Acos(225f * Mathf.Deg2Rad) * Mathf.Rad2Deg;

    //How to get a Vector2 x/y to spit out an angle, this is of course is in Radians
    //Mathf.Atan2(Vector2.zero.y, Vector2.one.x); THIS HAS TO BE 2 AND REMEMBER y THNE X


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Euler angles the goat bro, less work 
        //Unity starts at 90 but we see 0 easily solved with y vector additon static

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            facingDirection = objects[i].position; //Postion of Object

            Vector3 vectorToFirstTarget = facingDirection - transform.position; //TO see the directon to target

            facingAngle = VectorMath.VectorToAngle(vectorToFirstTarget); //Angle of Object

            transform.eulerAngles = new Vector3(0, 0, facingAngle);

            i++;

            if(i >= objects.Count)
            {
                i = 0;
            }
        }
    }
}
