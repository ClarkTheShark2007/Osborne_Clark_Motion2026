using UnityEngine;
using UnityEngine.InputSystem;

public class Week2Lecture : MonoBehaviour
{
    /*Static Methods can be refernced whatever
     Instances need a references with it 
     Static Variables can be used wherever (float distance = Vector2.distance(a,b) 
     Instances Varibles need a refernces with it Debug.Log
    Transform. up is affected by gameobject rotation versus vector.2 is not
    */

    /* MY current understanding for the directon stuff is a little messy
     Vector substraction was used for the direction but I couldnt figure out normazilton
    */
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        VectorMath.DrawSqaure(mousePos, 5f, Color.red, 2f);
    }

}
