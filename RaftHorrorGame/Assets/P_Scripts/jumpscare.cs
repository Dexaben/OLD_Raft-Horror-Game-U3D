using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
 
    public GameObject newgo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            newgo.SetActive(true);
            Destroy(gameObject);
        }
    }
}
