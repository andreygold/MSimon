using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public SpriteRenderer[] colours;
	private int colourSelect;
	public float stayLit;
	private float stayLitCounter;
	public float waitBetweenLights;
	private float waitBetweenCounter;

	private bool shouldBeLit;
	private bool shouldBeDark;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldBeLit) {
			stayLitCounter -= Time.deltaTime;
			if (stayLitCounter < 0) {
				colours [colourSelect].color = new Color (colours [colourSelect].color.r, colours [colourSelect].color.g, colours [colourSelect].color.b, 0.5f);
				shouldBeLit = false;
			}
		}
	}

	public void StartGame(){
		colourSelect = Random.Range (0, colours.Length);
		colours[colourSelect].color = new Color(colours[colourSelect].color.r, colours[colourSelect].color.g, colours[colourSelect].color.b, 1f);
		stayLitCounter = stayLit;
		shouldBeLit = true;
	}

	public void ButtonPressed(int buttonPressed){
		if (colourSelect == buttonPressed) {
			Debug.Log("Correct");
		}else{
			Debug.Log("Wrong");
		}
	}

}
