using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectScript : MonoBehaviour {
	
	Button button;
	SpriteState spriteState;
	public Sprite Chosen;
	public Sprite notChosen;
	public Sprite ChosenV;
	public Sprite notChosenV;

	// Use this for initialization
	void Start () {
		button = this.gameObject.GetComponent<Button> ();
		spriteState = new SpriteState();
		spriteState = button.spriteState;

	}
	
	// Update is called once per frame
	void Update () {

		if (enabled)
		{
			spriteState.pressedSprite = Chosen;
			spriteState.pressedSprite = ChosenV;
		}
		else
		{
			spriteState.pressedSprite = notChosen;
			spriteState.pressedSprite = notChosenV;
		}
		button.spriteState = spriteState;
		
	}
}
