using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // Talk Data
        // NPC A_ID : 1000, NPC B_ID : 2000
        // Box: 100, Desk: 101
        talkData.Add(1000, new string[] { "안녕?:0", "잘지내고 있니?:2", "옮길 때 조심해... ㅋ:1" });
        talkData.Add(2000, new string[] { "오랜만이야...:0", "나는 뇬디!:1", "...:1", "잘생겨졌네?:2" });
        talkData.Add(100, new string[] { "이것은 승건이가 옮겨야할 박스이다.", "... 빨리 옮겨야 퇴근할 수 있어." });
        talkData.Add(101, new string[] { "평범한 책상이다." });

        // Quest Talk

        // quest 10
        talkData.Add(1000 + 10, new string[] { "어서 와!:0", "처음 보는 사람이네? 너는 누구니?:1", "김승건이라고 하는구나!:2", "저 뒤에 있는 아이를 한번 만나보지 않겠니? :1" });
        talkData.Add(2000 + 11, new string[] { "안녕, 나는 뇬디라고해!:0", "너 내가 아는 누구랑 닮았네?:1", "잘 부탁해!:2" });
   

        // quest 20
        talkData.Add(2000 + 20, new string[] { "초면에 미안한데, 부탁을 하나 해도 될까?:1", "내가 저기 나무근처에서 동전을 잃어버려서...:1", "찾아줄 수 있겠니??:2" });
        talkData.Add(5000 + 21, new string[] { "근처에서 동전을 찾았다." });
        talkData.Add(2000 + 22, new string[] { "고마워! 역시 승건이가 짱이야 !!!:1", "우리 오랜만에 다이어트나 할까?... ㅎㅎ:2" });


        // NPC portrait Data
        // 0: normal, 1: speak, 2: happy, 3: angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            // 해당 퀘스트 진행 순서 대사가 없을 때
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); // Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex);  // Get First Quest Talk
        }


        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id,int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
