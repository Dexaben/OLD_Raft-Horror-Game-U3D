using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class typewriteranim : MonoBehaviour
{
    char[] type = "11.06.2019  Malıköy Kasabası Güzergahı".ToCharArray();
    Text text;
    AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        text = GetComponent<Text>();
        StartCoroutine("bekle");
    }
    IEnumerator bekle()
    {
   
        for (int i = 0; i < type.Length; i++)
        {
            yield return new WaitForSeconds(0.2f); 
            text.text += type[i].ToString();
            if (type[i] != ' ')
            {
             
                m_AudioSource.PlayOneShot(m_AudioSource.clip);
            }
        }


    }
}
