using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform targetTrasnform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldWeTurnRight = false;

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);

        Vector3 DirectonToTarget = targetTrasnform.position - transform.position; //Direction to turret and the target for the turret

        if(Vector3.Dot(DirectonToTarget, transform.right) >= 0) //Has to be right cuase unity faces right by defualy (90 degree example), 
        {
            //Speeds need to be higher to turn
            shouldWeTurnRight = true;

            transform.eulerAngles -= new Vector3(0, 0, 1f) * Time.deltaTime; //Subtract to turn to right
        } else
        {
            transform.eulerAngles += new Vector3(0, 0, 1f) * Time.deltaTime; //Add to turn to left
        }



        Debug.Log(shouldWeTurnRight);
    }
}
