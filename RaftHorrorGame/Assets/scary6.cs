using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scary6 : MonoBehaviour {
    public GameObject scary1anim;

    private void Start()
    {
        if (PlayerPrefs.GetInt("scary6") == 1)
        {
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Destroy(scary1anim);
      
        }
    }
    private void OnLevelWasLoaded(int level)
    {
    
        if (PlayerPrefs.GetInt("scary6") == 1)
        {
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Destroy(scary1anim);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            StartCoroutine("Scary1");
        }
    }
    IEnumerator Scary1()
    {
        scary1anim.GetComponent<Animator>().enabled = true;
      
        yield return new WaitForSeconds(7);
        PlayerPrefs.SetInt("scary6", 1);
        scary1anim.GetComponent<Animator>().enabled = false;
        Destroy(gameObject);
        Destroy(scary1anim);

    }
}
