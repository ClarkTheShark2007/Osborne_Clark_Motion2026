using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mod_Player : MonoBehaviour
{
    //Player Movement Varibles
    Vector3 direction;
    public float maxSpeed = 3;
    public Vector3 velocity;
    public float accelerationReacher; //How long it takes to reach targeted max speed
    public float decelrationReacher; //How long it takes to reach targeted max speed
    float timeToReachMaxAcceleration;
    float timeToCompleteStop;

    //Barrel Roll Varibles 
    public float barrelRollSpeed = 6f;
    public bool isRolling;
    public bool canRoll = true;
    public int amountOfBarrelRolls;
    public float rollsPerSeccond;

    //Thrown Varibles 
    public bool isBeingThrowned;
    public int amountOfSpins;
    public float spinsPerSeccond = 0.5f;

    float t;

    void Start()
    {
        timeToReachMaxAcceleration = maxSpeed / accelerationReacher;
        timeToCompleteStop = maxSpeed / decelrationReacher;
    }
    
    void Update()
    {
        playerMovement();
        barrelRoll();
        beingThrown();

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
        if(isRolling == true)
        {
            velocity = new Vector3 (barrelRollSpeed * direction.x, 0f, 0f);

            t += Time.deltaTime * rollsPerSeccond;

            if(t >= rollsPerSeccond)
            {
                t = rollsPerSeccond;
            }

            transform.eulerAngles = new Vector3(0,(t*360) * direction.x,0);

            if(t >= rollsPerSeccond)
            {
                isRolling = false;
                transform.eulerAngles = new Vector3(0,0,0);
                t = 0;
            }
        }
    }
    void beingThrown()
    {
        if(isBeingThrowned)
        {
            t += Time.deltaTime * spinsPerSeccond;

            if(t >= amountOfSpins)
            {
                t = amountOfSpins;
            }
            transform.eulerAngles = new Vector3(0,0,t*360);

            if(t >= amountOfSpins)
            {
                isBeingThrowned = false;
                transform.eulerAngles = new Vector3(0,0,0);
                t = 0;
            }
        }
    }
    void playerMovement()
    {
{        if(!isRolling) //Stops direction input if barrel rolling, as player moves only left or right
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

        
        //Edge Case checks to see if speed should go down OR if player is able to roll, modified by the alien
        if(velocity.magnitude >= maxSpeed && !isBeingThrowned && !isRolling)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        if(Keyboard.current.shiftKey.wasPressedThisFrame && !isRolling && !isBeingThrowned && canRoll)
        {
            if(direction.x == 1 || direction.x == -1)
            {
                isRolling = true;
                
            }
        }
        }
    }
}

