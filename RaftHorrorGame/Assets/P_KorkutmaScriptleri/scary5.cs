using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scary5 : MonoBehaviour {
    public GameObject scary1anim, pil1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("scary5") == 1)
        {
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Debug.Log("scary2 destroy");
        }
    }
    private void OnLevelWasLoaded(int level)
    {

        if (PlayerPrefs.GetInt("scary5") == 1)
        {
            Destroy(scary1anim.GetComponent<Animator>());
            Destroy(gameObject);
            Debug.Log("scary2 destroy");
        }

    }
    private void Update()
    {
        if (pil1 == null)
        {
            StartCoroutine("Scary1");
        }
    }
    IEnumerator Scary1()
    {
        GameObject.FindGameObjectWithTag("fenerspotlight").GetComponent<Light>().enabled = false;
        scary1anim.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(20);
        PlayerPrefs.SetInt("scary5", 1);
        scary1anim.GetComponent<Animator>().enabled = false;
        Destroy(gameObject);

    }
}
