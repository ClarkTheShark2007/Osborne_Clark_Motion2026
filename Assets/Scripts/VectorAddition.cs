using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;
    Vector2 origin = new Vector2(0,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rPlusB = rTransform.position + bTransform.position;

        if(Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, bTransform.position, Color.blue);
        }

        if(Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rTransform.position, Color.red);
        }

        if(Keyboard.current.rKey.isPressed && Keyboard.current.bKey.isPressed) 
        {
            Debug.DrawLine(origin, rPlusB, Color.magenta);
        }
    }
}
