using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceTravelled : MonoBehaviour {

    public GameObject player;

    private Text distanceLabel;
    private float playerStartPosition = 0;
    private float playerCurrentPosition = 0;

    private int count = 0;

    void Awake()
    {
        distanceLabel = GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
        playerStartPosition = player.transform.position.x;
        
	}
	
	// Update is called once per frame
	void Update () {
        playerCurrentPosition = player.transform.position.x;
        distanceLabel.text = "Distance: " + (playerCurrentPosition - playerStartPosition);
	}
}
