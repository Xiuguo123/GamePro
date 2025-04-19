using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightingSystem;
using UnityEngine.Video;

public class ItemsVideo : MonoBehaviour
{
    public VideoPanel m_VidoPanle;

    public VideoPlayer play;

    public VideoClip m_Vclip; 

    private void OnMouseDown() {
        if(IsRange())
        {
                play.clip = m_Vclip;
            play.Play();
            m_VidoPanle.gameObject.SetActive(true);
        } 
    }

    private void OnMouseEnter() {
        if(GetComponent<Highlighter>()!=null)
            GetComponent<Highlighter>().ConstantOn();
    }

    private void OnMouseExit() {
         if(GetComponent<Highlighter>()!=null)
            GetComponent<Highlighter>().ConstantOff();
    }

      public bool IsRange()
    {
        float dis = Vector3.Distance(GameObject.FindWithTag("Player").transform.position,transform.position);
        if(dis<=3)
            return true;
        return false;
    }
}
