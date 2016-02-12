using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {

    public float scrollSpeed;
    public int yAdjustment;
    public GameObject scrollingBackground;
    public GameObject player;

    private float x;
   
    public backgroundScroll(float scrollSpeed, GameObject scrollingBackground ) {
        this.scrollSpeed = scrollSpeed;
        this.scrollingBackground = scrollingBackground;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //float x = Mathf.Repeat(Time.deltaTime * scrollSpeed, 1);
        if (Mathf.Abs(player.GetComponent<CharacterController>().velocity.x) > 0)
        {
             //x = Mathf.Repeat(Time.time * scrollSpeed, 1);
            Vector2 offset = new Vector2(Mathf.Repeat(Time.time * scrollSpeed, 1), 0);
            scrollingBackground.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yAdjustment, scrollingBackground.transform.position.z);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }

        
	}

    public float setScrollSpeed(float scrollSpeed)
    {
        return this.scrollSpeed = scrollSpeed;
    }
}
