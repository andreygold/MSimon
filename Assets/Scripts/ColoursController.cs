using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoursController : MonoBehaviour {

	private SpriteRenderer sprite;
	public int thisButtonNum;
	private GameManager GM;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		GM = FindObjectOfType<GameManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
	}

	void OnMouseUp(){
		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
		GM.ButtonPressed (thisButtonNum);
	}
}
