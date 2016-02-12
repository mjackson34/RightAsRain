using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour {

    public GameObject player;

    private Text TimerLabel;
    private float timer = 60;
    private float playerStartPosition = 0;
    private float playerCurrentPosition = 0;
    private float playerDistanceCovered = 1000;

    void Awake()
    {
        TimerLabel = GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
        playerStartPosition = player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

             //if (GUI.Button (Rect (20,40,80,20), "Levels")) {
            //Application.LoadLevel ("MainMenue");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Application.LoadLevel("floorTile1");
            //gamerOver
            
            //string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        if (timer <= 0)
        {

                string sceneName = SceneManager.GetActiveScene().name;

                // load the same scene
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

        }

            playerCurrentPosition = player.transform.position.x;
            if (playerCurrentPosition - playerStartPosition > playerDistanceCovered)
            {
                timer += 60;
                playerStartPosition = playerCurrentPosition;
                playerDistanceCovered += 250;
            }

            TimerLabel.text = "Time Left: " + (timer -= Time.deltaTime);


	}
}
