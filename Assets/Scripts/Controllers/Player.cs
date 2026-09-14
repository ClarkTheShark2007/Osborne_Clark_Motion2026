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

    void Update()
    {
        if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(transform.position + Vector3.up);
        }

        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            Vector2 direction = (enemyTransform.position - transform.position);
            //Vector2.Distance(enemyTransform.position, transform.position);
            warpDrive(direction);
            
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        GameObject bomb = Instantiate(bombPrefab);
        bombPrefab.transform.position = inOffset;
    }

    void warpDrive(Vector3 direction)
    {
        transform.position += Vector3.Normalize(direction);
    }
}
