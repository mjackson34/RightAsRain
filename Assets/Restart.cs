using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

    void OnGUI()
    {
        if (GUILayout.Button("Restart"))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
