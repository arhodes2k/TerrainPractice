using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] float transTime;
       GameObject door;
    [SerializeField] GameObject img;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("door");
        
        //eventThrower.GetComponent<TheThrowerGO>().InvokedEventToListenFor.AddListener(MethodToRun);
        door.GetComponent<Door>().DreamTeleport.AddListener(StartTransition); //this is the in-house method that's being called.
    }

    
    void StartTransition()
    {
        StartCoroutine(TransitionCoroutine());

    }

    IEnumerator TransitionCoroutine()
    {
        img.SetActive(true);
        yield return new WaitForSeconds(transTime);

        LoadNextScene();
    }
    
   
    void LoadNextScene()
    {
        SceneManager.LoadScene("InHouseScene");
    }
}