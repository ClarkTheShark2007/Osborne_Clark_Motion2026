using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    Vector2 currentPos;

    // Update is called once per frame
    void Update()
    {
        Vector2 starPos = starTransforms[0].position;
        Debug.DrawLine(starPos, starTransforms[0].position, Color.white, 1f);
        starPos = Vector3.Lerp(starTransforms[1].position, starPos, 1f) * Time.deltaTime;
    }

    void Start()
    {
        //DrawConstellation();
    }

    void DrawConstellation()
    {
    }
}
