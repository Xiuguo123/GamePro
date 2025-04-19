using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���������ű�
public class SaveSoundVBtn : MonoBehaviour
{
    public AudioSource m_As;

    //�Ƿ��һ������
    //0��
    //1����
    private int m_IsFirstSet;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("M", m_As.volume);
            PlayerPrefs.SetInt("S", 1);
        });     
    }

  
}
