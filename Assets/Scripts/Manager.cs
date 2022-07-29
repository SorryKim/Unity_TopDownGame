using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public TypeEffect talkText;
    public GameObject scanObject;
    public Animator talkPanel;
    public bool isAction;
    public int talkIndex;
    public Image portraitImg;
    public Animator portraitAnim;
    public Sprite prevPortrait;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
        // Get Current Object
        isAction = true;
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        // Visible Talk for Action
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        // Set Talk data
        int questTalkIndex = 0;
        string talkData = "";

        if (talkText.isAnimation)
        {
            talkText.SetMsg("");
            return;
        }
        else {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        // End talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        // Continue Talk
        if (isNpc)
        {
            talkText.SetMsg(talkData.Split(':')[0]);

            // Show portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            if (prevPortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else
        {
            talkText.SetMsg(talkData);
            // Hide portrait
            portraitImg.color = new Color(1, 1, 1, 0);

        }

        isAction = true;
        talkIndex++;
    }

}
