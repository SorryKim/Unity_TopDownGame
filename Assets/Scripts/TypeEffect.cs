using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public GameObject EndCursor;
    public int CharPerSeconds;
    public bool isAnimation;

    Text msgText;
    AudioSource audioSource;
    string targetMsg;
    int index;
    float interval;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnimation)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
        
    }

    void EffectStart()
    {
        msgText.text = "";
        isAnimation = true;
        index = 0;
        EndCursor.SetActive(false);
        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        // End Animation
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        
        // Sound
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();
        
        index++;
        // Recursive
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnimation = false;
        EndCursor.SetActive(true);
    }

}
