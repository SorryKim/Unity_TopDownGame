using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("마을 사람들과 대화나누기", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("뇬디의 동전 찾아주기", new int[] { 2000, 5000, 1000 }));
        questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        // Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        // Control Quest Object
        ControlObject();

        // Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length )
            NextQuest();
        
        // Return Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questActionIndex = 0;
        questId += 10;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == 2)
                {
                    questObject[0].SetActive(false);
                }
                break;
        }
    }
}
