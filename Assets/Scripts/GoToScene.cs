using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public bool isAutomatic;
    public bool manualEnter;
    public string sceneName = "New Scene name here";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAutomatic && !manualEnter)
        {
            manualEnter = Input.GetButtonDown("Fire1");
        }
    }

    //Teleport automatico
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if (isAutomatic)
            {
                SceneManager.LoadScene(sceneName);
            }
           
        }

    }
    //Teleport Manual
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if(!isAutomatic && manualEnter)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

}
