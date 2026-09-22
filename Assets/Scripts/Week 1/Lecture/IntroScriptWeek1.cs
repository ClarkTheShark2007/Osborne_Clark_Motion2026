using UnityEngine;

public class IntroScriptWeek1 : MonoBehaviour
{

    //int x = 0;
    //int y = 1;
    //float health = 0.5f;

    Vector2 originPosition = new Vector2(0,0);
    Vector2 currentPosistion = new Vector2(3, -2);
    Vector2 dVector = new Vector2(0, 1);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.DrawLine(originPosition, currentPosistion, Color.yellow, 15f);
        Debug.DrawLine(originPosition, dVector, Color.gray, 15);
        Debug.Log(currentPosistion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
