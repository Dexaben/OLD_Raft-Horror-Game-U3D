using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Envanter : MonoBehaviour {
    public Transform[] bar;
    public Image image;
    public Image[] resim;
    public Sprite[] sprites;
    int index = 0;

	void Start () {
		
	}

	public void AddItem(int spritesindex) {
        resim[index] = Instantiate(image,bar[index].transform.parent, false);
        resim[index].sprite = sprites[spritesindex];
        resim[index].transform.parent = bar[index].transform;
        resim[index].transform.position = bar[index].transform.position;
        Instantiate(resim[index]);
        
        index++;
	}
}
