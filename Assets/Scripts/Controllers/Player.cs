using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float numberOfBombs;
    public Vector2 bombTrailSpacing;


    void Update()
    {   
        Vector3 playersTransform = transform.position;

        if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(playersTransform + Vector3.up);
        }

        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(playersTransform);
        }

        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            Vector2 direction = (enemyTransform.position - playersTransform);
            //Vector2.Distance(enemyTransform.position, transform.position);
            warpDrive(direction);
            
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        GameObject bomb = Instantiate(bombPrefab);
        bomb.transform.position = inOffset;
    }

    void SpawnBombTrail(Vector3 playerPostion)
    {
        for(int i = 1; i < numberOfBombs + 1; i++)
        {
            GameObject bomb = Instantiate(bombPrefab);
            bomb.transform.position = playerPostion - (Vector3) (bombTrailSpacing * i);
            Debug.Log(bombPrefab.transform.position);
        }
    }

    void warpDrive(Vector3 direction)
    {
        transform.position += Vector3.Normalize(direction);
    }
}
