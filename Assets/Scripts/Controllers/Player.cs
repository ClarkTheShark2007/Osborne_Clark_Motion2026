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
    public float distanceSpawn;


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

        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            spawnCornerBomb(playersTransform);
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

    void spawnCornerBomb(Vector3 playerPos)
    {
        int cornerDirection = Random.Range(0, 4);

        if(cornerDirection == 0)
        {
            GameObject bomb = Instantiate(bombPrefab);
            Vector2 tlBombPos = new Vector2 (playerPos.x - distanceSpawn, playerPos.y + distanceSpawn);
            bomb.transform.position = tlBombPos;
        }
        else if(cornerDirection == 1)
        {
            GameObject bomb = Instantiate(bombPrefab);
            Vector2 blBombPos = new Vector2 (playerPos.x - distanceSpawn, playerPos.y - distanceSpawn);
            bomb.transform.position = blBombPos;
        }
        else if(cornerDirection == 2)
        {
            GameObject bomb = Instantiate(bombPrefab);
            Vector2 trBombPos = new Vector2 (playerPos.x + distanceSpawn, playerPos.y + distanceSpawn);
            bomb.transform.position = trBombPos;
        }
        else if(cornerDirection == 3)
        {
            GameObject bomb = Instantiate(bombPrefab);
            Vector2 brBombPos = new Vector2 (playerPos.x + distanceSpawn, playerPos.y - distanceSpawn);
            bomb.transform.position = brBombPos;
        }
    }

    void warpDrive(Vector3 direction)
    {
        transform.position += Vector3.Normalize(direction);
    }
}
