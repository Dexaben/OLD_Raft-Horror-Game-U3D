using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animplay : MonoBehaviour {

    public GameObject JumpCam;
    public GameObject vrcam;

    public float sure;

    void Start()
    {
        StartCoroutine(EndJump());
    }
    IEnumerator EndJump()
    {
        JumpCam.SetActive(true);
        vrcam.SetActive(false);

        yield return new WaitForSeconds(sure);
        JumpCam.SetActive(false);
        vrcam.SetActive(true);

    }
}
