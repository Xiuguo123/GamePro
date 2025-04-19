using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{  
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 300);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<AudioSource>().Play();
            other.GetComponent<PlayerController>().m_Scroe += 5;
            PlayerController.Cnum++;
            GameObject.Destroy(gameObject);
        }
    }
}
