using UnityEngine;
using UnityEngine.InputSystem;

public class Week3Journal : MonoBehaviour
{
    public Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
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

        transform.position = transform.position + direction.normalized * Time.deltaTime;
    }
}
