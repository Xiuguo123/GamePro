using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameViiwPanel : MonoBehaviour
{
    public Button m_ReStart;
    
    void Start()
    {
        m_ReStart.onClick.AddListener(() =>
        {
            PlayerController.Cnum = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
     
}
