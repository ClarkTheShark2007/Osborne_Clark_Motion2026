using Unity.VisualScripting;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject player;
    public float searchChargeTimer;
    public float maxSpeed;
    public float totalSearchTime;
    public float distanceForAttack;
    public float attackSpeed;
    public float throwRadius;
    public float throwSpeed;
    [SerializeField] float totalMovementTime;
    float t;
    Vector2 velocity;
    Vector2 playerPos;
    public Vector2 attackPos;
    public Vector2 attackVelocity;
    Vector2 throwPostion;
    bool beingThrowned;
    Mod_Player playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalMovementTime = maxSpeed / totalSearchTime;
        attackPos = transform.position;
        playerScript = player.GetComponent<Mod_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        throwPlayer();
        Debug.DrawLine(transform.position, attackPos, Color.yellow);

        //If timer is ready, set velocity to max to the alien charges in that direction
        if(t >= searchChargeTimer)
        {
            int angle = Random.Range(0, 361);
            throwPostion = (Vector2) transform.position + new Vector2(Mathf.Cos((angle) * Mathf.Deg2Rad), Mathf.Sin((angle) * Mathf.Deg2Rad)) * throwRadius;
            playerPos = player.transform.position;
            velocity = (playerPos - (Vector2) transform.position).normalized * maxSpeed;
            t = 0;
        }

        if(Vector2.Distance(transform.position, player.transform.position) <= distanceForAttack)
        {
            playerPos = player.transform.position;

            t = 0;
            Debug.Log("Atackking the player!");
            if (!beingThrowned)
            {
                attackPos += (playerPos - attackPos).normalized * attackSpeed * Time.deltaTime;
            } else 
            {
                attackPos = transform.position;
            }


            if(Vector2.Distance(attackPos, playerPos) <= 0.1f)
            {
                attackPos = playerPos;
                playerScript.velocity = Vector3.zero;
                player.transform.position += (Vector3) ((Vector2)transform.position - playerPos).normalized * 2f * Time.deltaTime;
                
                if(Vector2.Distance(playerPos, transform.position) <= 0.1f)
                {
                    playerScript.isBeingThrowmed = true;
                    beingThrowned = true;
                    playerScript.velocity = ((Vector3)throwPostion - player.transform.position).normalized * throwSpeed;
                }
            }

        } else
        {
            attackPos += ((Vector2)transform.position - attackPos).normalized * attackSpeed * Time.deltaTime;
            if(Vector2.Distance(attackPos, transform.position) <= 0.5f)
            {
                attackPos = transform.position;        
            }
        }

        transform.position = (Vector2) transform.position + velocity * Time.deltaTime;

        //Makes velocity decelerate and makes it 0 once its close enough to it
        velocity -= velocity.normalized * totalMovementTime * Time.deltaTime;
        if(velocity.magnitude <= 0.001f)
        {
            velocity = Vector3.zero;
        }

        t += Time.deltaTime;
    }

    void throwPlayer()
    {
        if(beingThrowned)
        {
            //playerScript.velocity = playerScript.velocity + ((Vector3)throwPostion - player.transform.position).normalized * Time.deltaTime;
            //player.transform.position += ((Vector3)throwPostion - player.transform.position) * 2f * Time.deltaTime;


            if(Vector2.Distance(player.transform.position, transform.position) >= throwRadius +3f)
            {
                beingThrowned = false;
                playerScript.isBeingThrowmed = false;
            }
        }
    }
}
