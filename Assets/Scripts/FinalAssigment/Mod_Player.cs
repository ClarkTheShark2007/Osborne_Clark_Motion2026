using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mod_Player : MonoBehaviour
{
    Vector3 direction;
    public float maxSpeed = 3;
    public float rollSpeed = 45;
    public Vector3 velocity;
    public float accelerationReacher; //How long it takes to reach targeted max speed
    public float decelrationReacher; //How long it takes to reach targeted max speed
    [SerializeField] float timeToReachMaxAcceleration;
    [SerializeField] float timeToCompleteStop;
    [SerializeField] bool isRolling;
    [SerializeField] float totalTimeForCompleteRoll;
    public int amountOfRolls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToReachMaxAcceleration = maxSpeed / accelerationReacher;
        timeToCompleteStop = maxSpeed / decelrationReacher;
        totalTimeForCompleteRoll = (360/rollSpeed) * amountOfRolls;
    }

    // Update is called once per frame
    void Update()
    {

        playerMovement();
        if(!Keyboard.current.anyKey.isPressed)
        {
            velocity -= velocity.normalized * timeToCompleteStop * Time.deltaTime;
            if(velocity.magnitude <= 0.001f)
            {
                velocity = Vector3.zero;
            }
        }
    }

    void barrelRoll()
    {
        // Debug.Log(direction);
        // if(Keyboard.current.shiftKey.wasPressedThisFrame)
        // {
        //     if(direction.x == 1 || direction.x == -1)
        //     {
        //         isRolling = true;

        //     }
        // }

        // if(isRolling)
        // {
        //     transform.eulerAngles += new Vector3(0, direction.x, 0) * Time.deltaTime * rollSpeed;
        //     StartCoroutine(rolling());

        // }
    }

    IEnumerator rolling()
    {
        yield return new WaitForSeconds(totalTimeForCompleteRoll);
        isRolling = false;
    }
    void playerMovement()
    {
        if(!isRolling)
        {        
            direction = Vector3.zero;

            if(Keyboard.current.upArrowKey.isPressed)
            {
                direction += Vector3.up;
            }
            if(Keyboard.current.downArrowKey.isPressed)
            {
                direction += Vector3.down;
            }
            if(Keyboard.current.leftArrowKey.isPressed)
            {
                direction += Vector3.left;
            }
            if(Keyboard.current.rightArrowKey.isPressed)
            {
                direction += Vector3.right;
            }
        }
        //Movement of Player Code
        velocity = velocity + direction.normalized * timeToReachMaxAcceleration * Time.deltaTime;

        transform.position = transform.position + velocity * Time.deltaTime;

        if(velocity.magnitude >= maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        barrelRoll();


    }
}
