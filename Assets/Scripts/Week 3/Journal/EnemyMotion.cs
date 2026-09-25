using System.Collections;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    public Transform player;
    public Vector2 randomLocation;
    public float maxDistanceForRandomPosition;
    public float distanceToPlayer;
    public float maxSpeedSearching;
    public float maxSpeedChasing;
    public float resetSearchTime;
    float speed;
    public Vector3 velcoity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = maxSpeedSearching;
        randomLocation = (Vector2) transform.position + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * maxDistanceForRandomPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, player.position) <= distanceToPlayer)
        {
            transform.position += ((Vector3)player.position - transform.position).normalized * maxSpeedChasing * Time.deltaTime;
        }
        else
        {
            transform.position += ((Vector3)randomLocation - transform.position).normalized * speed * Time.deltaTime;

            if (velcoity.magnitude <= maxSpeedChasing)
            {
                velcoity = velcoity.normalized * maxSpeedChasing;
            }

            if(Vector2.Distance(randomLocation, transform.position) <= 0.1f)
            {
                StartCoroutine(resetSpeed());
                randomLocation = (Vector2)transform.position + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * maxDistanceForRandomPosition;

            }
        }
    }

    IEnumerator resetSpeed()
    {
        speed = 0f;
        yield return new WaitForSeconds(resetSearchTime);
        speed = maxSpeedSearching;
    }

    
}
