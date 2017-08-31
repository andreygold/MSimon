using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoursController : MonoBehaviour {

	private SpriteRenderer sprite;
	public int thisButtonNum;
	private GameManager GM;
    public AudioSource sound;  
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		GM = FindObjectOfType<GameManager> ();
        sound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        sound.Play();

	}

	void OnMouseUp(){
		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
		GM.ButtonPressed (thisButtonNum);
        sound.Stop();
	}
}
