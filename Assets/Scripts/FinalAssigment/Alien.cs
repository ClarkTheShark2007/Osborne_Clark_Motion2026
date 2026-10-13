using Unity.VisualScripting;
using UnityEngine;

public class Alien : MonoBehaviour
{
    //Searching State Varibles
    public float searchChargeTimer;
    public float maxSpeed;
    public float totalSearchTime;
    [SerializeField] float totalMovementTime;
    Vector2 velocity;

    //Attacking State Varibles
    public float distanceForAttack;
    public float attackSpeed;
    Vector2 playerPos;
    public Vector2 attackPos;

    //Throwing State Varibles
    public float throwRadius;
    public float throwSpeed;
    Vector2 throwPostion;
    bool beingThrowned;

    //Player Varibles
    public GameObject player;
    Mod_Player playerScript;

    float t;

    void Start()
    {
        //Setup for mentioned Varibles above
        totalMovementTime = maxSpeed / totalSearchTime;
        attackPos = transform.position;
        playerScript = player.GetComponent<Mod_Player>();
    }

    void Update()
    {
        throwPlayer();
        Debug.DrawLine(transform.position, attackPos, Color.yellow);

        //If timer is ready, set velocity to max to the alien charges in that direction. Also sets a new random throw postion
        if(t >= searchChargeTimer)
        {
            int angle = Random.Range(0, 361);
            throwPostion = (Vector2) transform.position + new Vector2(Mathf.Cos((angle) * Mathf.Deg2Rad), Mathf.Sin((angle) * Mathf.Deg2Rad)) * throwRadius;
            playerPos = player.transform.position;
            velocity = (playerPos - (Vector2) transform.position).normalized * maxSpeed;
            t = 0;
        }

        // If the player distance is close enough to trigger attack state, then switch
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

            //If the player distance is touching the projected line AND is not rolling, then stop all player movement and bring close to me
            if(Vector2.Distance(attackPos, playerPos) <= 0.1f && !playerScript.isRolling)
            {
                attackPos = playerPos;
                playerScript.velocity = Vector3.zero;
                playerScript.canRoll = false;
                player.transform.position += (Vector3) ((Vector2)transform.position - playerPos).normalized * 2f * Time.deltaTime;
                
                //If the player distance is touching me, throw player in direction set with max with my throwspeed
                if(Vector2.Distance(playerPos, transform.position) <= 0.1f)
                {
                    beingThrowned = true;
                    playerScript.isBeingThrowned = true;
                    playerScript.velocity = ((Vector3)throwPostion - player.transform.position).normalized * throwSpeed;
                }
            }

        } 
        //Move attack to me and if its close enough to me, make it reflect my transform
        else
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
            // Sound effects can be put here

            if(playerScript.isBeingThrowned == false)
            {
                //Reset my movement and allow player to roll again
                beingThrowned = false;
                playerScript.canRoll = true;
            }
        }
    }
}
