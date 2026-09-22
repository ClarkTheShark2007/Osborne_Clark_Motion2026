using UnityEngine;
using UnityEngine.InputSystem;

public class Week3Lecture : MonoBehaviour
{
    //Frame rate stuff happens every frame, this can be bad especially when you dont want somthing hppeing every frame
    //Time.detla time good cause dosnt give an adavantge over others 
    //Im kinda getting it for acceleration but deceleration im completly confused 

    public Vector3 currentVelocity;
    public float speed;
    public float accelerationTime;
    public float deaccelerationTime;
    public float currentAcceleration;
    public float deacceleration;
    float maxSpeed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        deacceleration = maxSpeed / deaccelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //In class activties 
        Vector3 accelerationDirection = Vector3.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }

        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        if (accelerationDirection == Vector3.zero)
        {
            //currentVelocity -= accelerationDirection.normalized * currentAcceleration * Time.deltaTime;
        }
        else 
        {
            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }

        transform.position = transform.position + currentVelocity * Time.deltaTime;

    }
}
