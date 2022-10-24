using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public bool isAutomatic;
    public bool manualEnter;
    public string sceneName = "New Scene name here";
    public string uuid; //Hace referencia a universal unique identifier
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
        Teleport(other.name);
        //Al hacer lo de Teleport(other.name) ya no hace falta poner esto
       /* if(other.name == "Player")
        {
            if (isAutomatic)
            {
                SceneManager.LoadScene(sceneName);
            }
           
        }
       */

    }
    //Teleport Manual
    private void OnTriggerStay2D(Collider2D other)
    {
        Teleport(other.name);
       /* if (other.name == "Player")
        {
            if(!isAutomatic && manualEnter)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
       */
    }
    private void Teleport (string objName)
    {
        if(objName == "Player")
        {
            if(isAutomatic || (isAutomatic && manualEnter))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
