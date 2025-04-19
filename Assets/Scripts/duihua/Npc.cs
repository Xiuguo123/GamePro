using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 //npc
public class Npc : MonoBehaviour
{   
    //对话数据
    public string[] m_Datas = { "",
                                ""
                                };

    //对话面板
    public DuiHuaPanel m_DuiHuaPanel;

    //是否开启对话
    public bool m_IsStartDuiHua;

    //对话索引
    private int m_DuiHuaIndex;

    //寻路导航
    private NavMeshAgent m_Agent; 

    //路径点
    public Transform[] m_Paths;

    private float m_CurTime;

   
    private void Start() {
       
        m_DuiHuaIndex = 0;
        m_Agent = GetComponent<NavMeshAgent>();
    } 

    private void Update() {

        
        if(m_IsStartDuiHua)
        {
            //按F 对话继续
            if(Input.GetKeyDown(KeyCode.F))
            {
                m_DuiHuaIndex++;
                if(m_DuiHuaIndex>=m_Datas.Length)
                {
                    //关闭面板
                    m_DuiHuaPanel.gameObject.SetActive(false);
                    m_IsStartDuiHua =false;
                    m_DuiHuaIndex = 0;
                     
                    return;
                }
                m_DuiHuaPanel.SetStr(m_Datas[m_DuiHuaIndex]);
            }
        } 
    } 

    public bool IsRange(float _range)
    {
        float dis = Vector3.Distance(GameObject.FindWithTag("Player").transform.position,transform.position);
        if(dis <= _range)
        {
            return true;
        }

        return false;
    }

    private void OnMouseOver() {
        if(IsRange(5))
        {
            if(Input.GetMouseButtonDown(0))
            {
                //这个解决了点击UI之后会对场景中的物体有响应的问题
                if (EventSystem.current != null)
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                        return;
                }

                m_IsStartDuiHua = true;
                m_DuiHuaPanel.SetStr(m_Datas[m_DuiHuaIndex]);

            }
        }
    }
     
}
