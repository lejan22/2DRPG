using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questId;
    public bool questCompleted;
    public string title;
    public string startText;
    public string completedText;
    private QuestManager questManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText($"{ title}\n{ startText}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompleteQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText($"{ title}\n{ completedText}");
        questCompleted = true;
        gameObject.SetActive(false);
    }
}
