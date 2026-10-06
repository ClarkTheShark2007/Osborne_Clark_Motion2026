using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject player;
    public float searchChargeTimer;
    public float maxSpeed;
    public float totalSearchTime;
    public float distanceForAttack;
    [SerializeField] float totalMovementTime;
    float t;
    public Vector2 velocity;
    public Vector2 playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalMovementTime = maxSpeed / totalSearchTime;
    }

    // Update is called once per frame
    void Update()
    {
        //If timer is ready, get player postion and set velocity to max to the alien charges in that direction
        if(t >= searchChargeTimer)
        {
            playerPos = player.transform.position;
            velocity = (playerPos - (Vector2) transform.position).normalized * maxSpeed;
            t = 0;
        }

        if(Vector2.Distance(transform.position, player.transform.position) <= distanceForAttack)
        {
            velocity = Vector3.zero;
            Debug.Log("Atackking the player!");
        } else
        {
            transform.position = (Vector2) transform.position + velocity * Time.deltaTime;
        }


        //Makes velocity decelerate and makes it 0 once its close enough to it
        velocity -= velocity.normalized * totalMovementTime * Time.deltaTime;
        if(velocity.magnitude <= 0.001f)
        {
            velocity = Vector3.zero;
        }


        t += Time.deltaTime;
    }
}
