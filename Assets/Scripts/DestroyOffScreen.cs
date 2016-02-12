using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour {

    public float offset = 100f;
    //public PixelPerfectCamera mainCamera;
    private GameObject camera;

    private bool offscreen;
    private float offscreenX = 0;
    private Rigidbody2D body2D;
    
    public GameObject player;

    private GameObject blocksPlaced;

    void Awake()
    {
        //body2D = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera");
    }

	void Start () {
        
	}

	void Update () {
        //blocksPlaced = SpawnTiles.returnBlocksList(1);
        //offscreenX = camera.transform.position.x + (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2;
        //offscreenX = camera.transform.position.x;
        //var playerposition = player.transform.position.x;
        //Debug.Log(offscreenX);
        //gets the screen width and multiplies it by the scale then divides by 2 to get half and then adds the offset to get it beyond the frame
        //offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
        offscreenX = (Screen.width) / 2 + offset;
        var posX = transform.position.x - camera.transform.position.x;
        //var posX = transform.TransformPoint(transform.position.x, transform.position.y, 1);
        //var dirX = body2D.position.x;
        //Debug.Log(offscreenX + ", " + posX);
        //Debug.Log("posX: " + posX + ", offscreenX: " + offscreenX);
        if (Mathf.Abs(posX) > offscreenX)
        {
            Debug.Log(posX + ", " + -offscreenX);
            if (posX < -offscreenX)
            {
                offscreen = true;
            }
            else
            {
                offscreen = false;
            }
            
        }


        if (offscreen)
        {
            OnOutOfBounds();
        }
	}

    public void OnOutOfBounds()
    {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);
    }
}
