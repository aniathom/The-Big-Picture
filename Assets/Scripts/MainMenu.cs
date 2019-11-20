using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    public Animator transitionsAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGame()
    {
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }

    IEnumerator QuitScene()
    {
        transitionsAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    public void StartEX()
    {
        StartCoroutine(StartGame());
    }

    public void QuitEX()
    {
        StartCoroutine(QuitScene());
    }
}
