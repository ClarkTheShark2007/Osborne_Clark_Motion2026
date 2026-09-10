using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public List <Vector2> postions = new List <Vector2>();
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Mouse.current.leftButton.isPressed)
        {
            if(timer >= 0.1f)
            {
                Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                if(postions.Count > 2)
                {
                    //Debug.DrawLine(mousePos, postions[postions.Count - 1], Color.white, 1f);
                    
                    for(int i = 1; i < postions.Count + 1; i++)
                    {
                        if(i >= postions.Count )
                        {
                            break;
                        }
                        Debug.DrawLine(postions[postions.Count - i], postions[postions.Count - (1 + i)], Color.white, 0.1f);
                    }

                    postions.Add(mousePos);
                } else
                {
                    postions.Add(mousePos);
                }

                timer = 0;
            }
        } 
        else if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 ogMousePos = new Vector2(postions[^1].x,postions[^1].y);

            float sizeOfLine = Mathf.Sqrt(ogMousePos.x * mousePos.x + ogMousePos.y * mousePos.y);
            Debug.Log("The size of the line is... " + sizeOfLine);
            postions.Clear();
        }
    }
}
