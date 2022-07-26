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
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�������� �ִ�?:2", "�ű� �� ������... ��:1" });
        talkData.Add(2000, new string[] { "�������̾�...:0", "���� ����!:1", "...:1", "�߻�������?:2" });
        talkData.Add(100, new string[] { "�̰��� �°��̰� �Űܾ��� �ڽ��̴�.", "... ���� �Űܾ� ����� �� �־�." });
        talkData.Add(101, new string[] { "����� å���̴�." });

        // Quest Talk

        // quest 10
        talkData.Add(1000 + 10, new string[] { "� ��!:0", "ó�� ���� ����̳�? �ʴ� ������?:1", "��°��̶�� �ϴ±���!:2", "�� �ڿ� �ִ� ���̸� �ѹ� �������� �ʰڴ�? :1" });
        talkData.Add(2000 + 11, new string[] { "�ȳ�, ���� ��������!:0", "�� ���� �ƴ� ������ ��ҳ�?:1", "�� ��Ź��!:2" });
   

        // quest 20
        talkData.Add(2000 + 20, new string[] { "�ʸ鿡 �̾��ѵ�, ��Ź�� �ϳ� �ص� �ɱ�?:1", "���� ���� ������ó���� ������ �Ҿ������...:1", "ã���� �� �ְڴ�??:2" });
        talkData.Add(5000 + 21, new string[] { "��ó���� ������ ã�Ҵ�." });
        talkData.Add(2000 + 22, new string[] { "����! ���� �°��̰� ¯�̾� !!!:1", "�츮 �������� ���̾�Ʈ�� �ұ�?... ����:2" });


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
            // �ش� ����Ʈ ���� ���� ��簡 ���� ��
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
