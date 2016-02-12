using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstructionsOff : MonoBehaviour {

    public CharacterController player;
    public Text text;

    private float originalCharacterPosition;
    private float currentCharacterPosition;
	// Use this for initialization
	void Start () {
        originalCharacterPosition = player.transform.position.x;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        currentCharacterPosition = player.transform.position.x;
        if (currentCharacterPosition - originalCharacterPosition > 100)
        {
            text.enabled = false;
        }
	}
}
