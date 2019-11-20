using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPainting : MonoBehaviour {

    public PlayerController playerController;
    public Rigidbody2D playerRB;

    private PlayerStatManager statManager;
    public GameObject manager;
    public float pushTime;
    [HideInInspector]

    public float newMaxJump = 20;
    public float newMinJump = 15;
    public float pushTimer;
    private bool justPushed;

	// Use this for initialization
	void Start () {
        pushTimer = pushTime;
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
                StartCoroutine(SetJump());
                RemovePlayerComponents();

            }
        }
        else 
        {
            pushTimer = pushTime;
        }


    }


    IEnumerator SetJump()
    {
        statManager.maxJump = newMaxJump;
        statManager.minJump = newMinJump;
        yield return new WaitForSeconds(8);
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
