using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������
public class BGM : MonoBehaviour
{ 
    void Start()
    {
        //�ӱ���������ж�ȡ����
        //�ж��ǲ��ǵ�һ�����ã����������Ĭ����1
        int isfirst = PlayerPrefs.GetInt("S");
        if(isfirst == 0)
        {
            Debug.Log("��һ����������");
            GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            Debug.Log("�Ѿ����ù�����");
            float v = PlayerPrefs.GetFloat("M");
            GetComponent<AudioSource>().volume = v;
        }
    } 
}
