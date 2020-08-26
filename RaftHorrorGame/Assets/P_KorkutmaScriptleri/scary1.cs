using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scary1 : MonoBehaviour {
    public GameObject scary1anim;
    public AudioSource m_audiosource;
    private void Start()
    {
        if (PlayerPrefs.GetInt("scary1") == 1)
        {
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Debug.Log("scary1 destroy");
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        m_audiosource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("scary1") == 1)
        { 
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Debug.Log("scary1 destroy");
    }
}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            
            StartCoroutine("Scary1");
        }
    }
    IEnumerator Scary1()
    {
        scary1anim.GetComponent<Animator>().enabled = true;
        m_audiosource.PlayOneShot(m_audiosource.clip);
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("scary1", 1);
        scary1anim.GetComponent<Animator>().enabled = false;
        Destroy(gameObject);
      
    }
}
