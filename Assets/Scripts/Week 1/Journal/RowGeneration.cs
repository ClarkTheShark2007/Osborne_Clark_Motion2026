using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RowGeneration : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPush()
    {
        Vector2 originPoint = new Vector2(0,0);

        int sqauresToDraw = int.Parse(inputField.text);
        Debug.Log(sqauresToDraw);

        if(sqauresToDraw >= 1)
        {
            for (int i = 1; i < sqauresToDraw + 1; i++)
            {
                int spaceToAdd = i;
                Vector2 bl =  new Vector2(originPoint.x, originPoint.y);
                Vector2 tl =  new Vector2(originPoint.x, originPoint.y + 1);
                Vector2 br =  new Vector2(originPoint.x + spaceToAdd, originPoint.y);
                Vector2 tr =  new Vector2(originPoint.x + spaceToAdd, originPoint.y + 1);

                Debug.DrawLine(bl, tl, Color.white, 99f);
                Debug.DrawLine(bl, br, Color.white, 99f);
                Debug.DrawLine(tl, tr, Color.white, 99f);
                Debug.DrawLine(tr, br, Color.white, 99f);
            }
        }
    }
}
