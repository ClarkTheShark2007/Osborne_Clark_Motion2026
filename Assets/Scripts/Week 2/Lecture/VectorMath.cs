using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 upDirection = Vector3.up;
        
        float distance = Vector2.Distance(Vector3.up, upDirection);
    }

    public static float GetMagnitude(Vector2 vector) //Size 
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    public static Vector2 GetNormalizedVector2(Vector2 vector) //Direction
    {
        float sizeOfVector = GetMagnitude(vector);
        Vector2 normaliezVector = new Vector2(vector.x, vector.y) / sizeOfVector;
        return normaliezVector;
    }

    public static void DrawSqaure(Vector2 centerPoint, float size, Color colour, float duration)
    {
        //Top Line
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //Left Line
         startPoint = centerPoint + new Vector2(-size, size);
         endPoint = centerPoint + new Vector2(-size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //Right Line
        startPoint = centerPoint + new Vector2(size, size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //Bottom Line
         startPoint = centerPoint + new Vector2(-size, -size);
         endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);
    }
}
