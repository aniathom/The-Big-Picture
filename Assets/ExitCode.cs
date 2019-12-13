using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCode : MonoBehaviour
{

    public PlayerController player;
    public GameObject manager;
    public PlayerStatManager statManager;
    public string levelName;

    private Vector2 baseGravity;
    // Use this for initialization
    void Start()
    {
        baseGravity = Physics2D.gravity;
        statManager = manager.GetComponent<PlayerStatManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == 9)
        {
            Debug.Log("Henry exits.");
            StartCoroutine(ResetLevel());
        }
    }
    public IEnumerator ResetLevel()
    {
        player.enabled = false;
        //reset player stats after death
        Physics2D.gravity  = baseGravity;
        statManager.maxJump = 15;
        statManager.minJump = 10;
        //play death animation
        yield return new WaitForSeconds(0.5f);
        player.enabled = true;
        SceneManager.LoadScene(levelName);
    }
}