using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


	public SpriteRenderer[] colours;
    public AudioSource[] buttonSounds;
	private int colourSelect;
	public float stayLit;
	private float stayLitCounter;
	public float waitBetweenLights;
	private float waitBetweenCounter;

	private bool shouldBeLit;
	private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence;
    public AudioSource correct;
    public AudioSource incorrect;

    public Text scoreText;

    // Use this for initialization
    void Start () {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        scoreText.text = "Score: 0 \n Best: " + PlayerPrefs.GetInt("HighScore");
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldBeLit) {
			stayLitCounter -= Time.deltaTime;
			if (stayLitCounter < 0) {
				colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r, colours [activeSequence[positionInSequence]].color.g, colours [activeSequence[positionInSequence]].color.b, 0.5f);
                buttonSounds[activeSequence[positionInSequence]].Stop();
				
                shouldBeLit = false;
                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                positionInSequence++;
            }
		}
        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else
            {
                if (waitBetweenCounter < 0)
                {
                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
                    buttonSounds[activeSequence[positionInSequence]].Play();

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }
	}

	public void StartGame(){
        activeSequence.Clear();
        positionInSequence = 0;
        inputInSequence = 0;
		colourSelect = Random.Range (0, colours.Length);
        activeSequence.Add(colourSelect);
		colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
        buttonSounds[activeSequence[positionInSequence]].Play();
        stayLitCounter = stayLit;
		shouldBeLit = true;

        scoreText.text = "Score: 0 \n Best: " + PlayerPrefs.GetInt("HighScore");
    }

	public void ButtonPressed(int buttonPressed){
        if (gameActive)
        {
            if (activeSequence[inputInSequence] == buttonPressed)
            {
                Debug.Log("Correct");
                inputInSequence++;
                if(inputInSequence >= activeSequence.Count)
                {
                    if(activeSequence.Count > PlayerPrefs.GetInt("HighScore"))
                    {
                        PlayerPrefs.SetInt("HighScore", activeSequence.Count);
                    }
                    scoreText.text = "Score: " + activeSequence.Count + "\n" + "Best: " + PlayerPrefs.GetInt("HighScore");
                    positionInSequence = 0;
                    inputInSequence = 0;
                    colourSelect = Random.Range(0, colours.Length);
                    activeSequence.Add(colourSelect);
                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f);
                    buttonSounds[activeSequence[positionInSequence]].Play();

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    gameActive = false;
                    correct.Play();
                    
                }
            }
            else
            {
                Debug.Log("Wrong");
                incorrect.Play();
                gameActive = false;
            }
        }
	}

}
