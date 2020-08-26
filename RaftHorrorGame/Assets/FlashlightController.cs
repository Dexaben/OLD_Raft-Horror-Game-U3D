using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
    public float pil_deger;
    PlayerControl m_player;
    Light m_light;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerControl>();
        m_light = GetComponent<Light>();
      
    }
    void Update () {
		if(m_player.flashlight_onoff == true)
        {
            m_light.enabled = true;
            pil_deger -= Time.deltaTime * 0.1f;
        }
        else
        {
            m_light.enabled = false;
        }
        if(pil_deger < 30f && pil_deger >= 20)
        {
            m_light.intensity = 4;
        }
        if(pil_deger < 20f && pil_deger >= 10)
        {
            m_light.intensity = 3;
        }
        if(pil_deger < 10f && pil_deger > 0)
        {
            m_light.intensity = 1.5f;
        }
        if (pil_deger == 0f)
        {
            m_light.intensity = 0.2f;
        }
	}
}
