using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialog : MonoBehaviour
{
   

    public string npcName;
    public string[] npcDialogLines;
    private DialogManager dialogManager;
    private bool isPlayerInDialogZone;
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = false;
        }
    }
    private string[] DialogPlusNPCName()
    {

        string[] finalDialog = new string[npcDialogLines.Length];

        

        for (int i = 0; i < npcDialogLines.Length; i++)
        {
            if (npcName != null)
            {
                finalDialog[i] = $"{npcName}\n{ npcDialogLines[1]}";
            }
            else
            {
                finalDialog[i] = npcDialogLines[i];
            }
        }

       
        
         
            return finalDialog;
        }
        // Update is called once per frame
        void Update()
    {
        if (isPlayerInDialogZone && Input.GetMouseButtonDown(1))
        {
            dialogManager.ShowDialog(DialogPlusNPCName());
        }
    }
}
