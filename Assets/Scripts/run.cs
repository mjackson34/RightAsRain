using UnityEngine;
using System.Collections;

public class run : MonoBehaviour {

    public float runValue;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(new Vector2(runValue, 0f));
        }
	}
}
