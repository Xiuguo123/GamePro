using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().m_Hp--;
            if (other.GetComponent<PlayerController>().m_Hp <= 0)
            {
                other.transform.GetChild(0).GetComponent<AudioSource>().Play();
                other.GetComponent<PlayerController>().r.enabled = false;
                other.GetComponent<PlayerController>().Effeect.SetActive(true);
                gameObject.SetActive(false);
            }
            GameObject.Destroy(gameObject);
        }
    }
}
