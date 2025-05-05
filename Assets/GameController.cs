using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] float transTime;


    [SerializeField] JoeController Joe;
    [SerializeField] GameObject deathScreenUI;

    [SerializeField] Marg marg;

    [SerializeField] GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
      



    }

    void Update()
    {
        if (Joe.killed)
        {
            StartCoroutine(TransitionCoroutineA());
        } 

        if (Joe.wakeUp)
        { 
            WakeUp();
        }
       
        
    }

    IEnumerator TransitionCoroutineA()
    {
        deathScreenUI.SetActive(true); 
        yield return new WaitForSeconds(1.2f);
        enemies[0].SetActive(false); 
        enemies[1].SetActive(false);
        yield return new WaitForSeconds(transTime);
        
            Reload();
    
    }

    void WakeUp(){

        if(marg.saved){
        SceneManager.LoadScene("EndScene");
        } 
        if(!marg.saved){
        SceneManager.LoadScene("BadEndScene");
        } 


    }
    void Reload()
    {
        
        SceneManager.LoadScene("InHouseScene");
    }
}
