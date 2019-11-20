using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFallPainting : MonoBehaviour {

    public PlayerController playerController;
    public Rigidbody2D playerRB;

    public PlayerStatManager statManager;

    public GameObject manager;
    public float pushTime;
    [HideInInspector]
    public float pushTimer;

    public Vector2 slowGravity;
    private Vector2 baseGravity;
    private bool justPushed;

    [SerializeField]
    private float newMin = 8;
    [SerializeField]
    private float newMax = 5;

	// Use this for initialization
	void Start () {
        pushTimer = pushTime;
        baseGravity = Physics2D.gravity;
        statManager = manager.GetComponent<PlayerStatManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerController != null && playerRB != null) 
        { 
            if(pushTimer >= 0 && !playerController.isCancelledPressed)
            {
                pushTimer -= Time.deltaTime;
            }
            //once the timer is up, we get the player's input and push them away
            else {
                justPushed = true;
                pushTimer = pushTime;
                //idle
                StartCoroutine(SetGravity(slowGravity));
                RemovePlayerComponents();
            }
        }
        else 
        {
            pushTimer = pushTime;
        }


    }

    IEnumerator SetGravity(Vector2 tempGravity)
    {
        Physics2D.gravity = tempGravity; 
        statManager.maxJump = newMax;
        statManager.minJump = newMin;
        yield return new WaitForSeconds(8);
        Physics2D.gravity  = baseGravity;
        statManager.maxJump = 15;
        statManager.minJump = 10;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //I know this isn't the most elegant solution, as it will always get these components of the
            //player whenever it touches the player, but everything I've tried has been inconsistent
            //at best, so I'm just going to leave it like this because it's consistent this way.
            playerController = collision.GetComponent<PlayerController>();
            playerRB = collision.GetComponent<Rigidbody2D>();

        }
    }

    private void RemovePlayerComponents() {
        playerController = null;
        playerRB = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the player exits the blast core, then we set the PlayerController variable to null.
        if (collision.gameObject.layer == 9)
        {
            playerController = null;
            playerRB = null;
        }
    }
}


