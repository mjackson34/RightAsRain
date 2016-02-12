using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnTiles : MonoBehaviour {
    //ZERO is newGroundTile
    //ONE is newGroundTileTiltedUp
    //Two is newGroundTileTiltedDown
    public GameObject[] prefabs;
    public GameObject lastBlockPlaced;
    public float delay = 0.0f;
    public bool active = true;
    public float offset = 100;

    public GameObject player;
    public Camera camera;

    private float offscreenX = 0f;
    private List<Vector2> boxDimensions = new List<Vector2>();
    private Vector2 lastBlockPosition;
    private float lastPlayerPosition;
    private int lastBlockPlacedNumber;
    //private List<float> boxHeight = new List<float>();

	void Start () {
        lastPlayerPosition = player.transform.position.x;
        lastBlockPosition = new Vector2(lastBlockPlaced.transform.position.x, lastBlockPlaced.transform.position.y);
        getBoxDimensions();
        //StartCoroutine(TileGenerator());
        Spawn(10);

	}

    void Update()
    {
        float currentPlayerPosition = player.transform.position.x;
        if (Mathf.Abs(currentPlayerPosition) - Mathf.Abs(lastPlayerPosition) > 6)
        {
            lastPlayerPosition = currentPlayerPosition;
            Spawn();
        }
        
    }
    //x = width, y = height
    public void getBoxDimensions()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            boxDimensions.Add(prefabs[i].GetComponent<Renderer>().bounds.size);
        }
    }

    public void Spawn(int numberOfBlocks)
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            //Debug.Log(new Vector2(lastBlockPlaced.transform.position.x + boxDimensions[0].x, lastBlockPlaced.transform.position.y));
            GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[0], new Vector2(lastBlockPosition.x + boxDimensions[0].x, lastBlockPosition.y), Quaternion.identity);
            lastBlockPlaced = newPlatform;
            lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
            lastBlockPlacedNumber = 0;
        }
    }

    public void Spawn()
    {
        int randomBlock = Random.Range(0, prefabs.Length);
        //float currentPlayerPosition = player.transform.position.x;
        //Debug.Log(randomBlock);
        //offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + 50;
        offscreenX = (Screen.width) / 2 + 50;
        var cameraPosition = camera.transform.position.x;
        //Debug.Log("offscrenX: " + offscreenX + ", " + "lastblockplaced: " + lastBlockPlaced.transform.position.x);
        //GameObject newPlatform = (GameObject)Instantiate(prefabs[randomBlock], new Vector2(lastBlockPlaced.transform.position.x + boxDimensions[0].x, lastBlockPlaced.transform.position.y), Quaternion.identity);
        //lastBlockPlaced = newPlatform;
        //Debug.Log("player position: " + (currentPlayerPosition - lastPlayerPosition) + "offscreenX: " + offscreenX);
        //if ((currentPlayerPosition - lastPlayerPosition) > cameraPosition)
        //{
        for (int i = 0; i < 1; i++)
        {
            //newGroundTile
            if (randomBlock == 0)
            {
                if (lastBlockPlacedNumber == 0)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + boxDimensions[0].x, lastBlockPosition.y), Quaternion.identity);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                else if (lastBlockPlacedNumber == 1)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - (boxDimensions[0].x / 8) - 0.5f, lastBlockPlaced.transform.position.y + (boxDimensions[lastBlockPlacedNumber].y / 8)- 0.155f), Quaternion.identity);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                else if (lastBlockPlacedNumber == 2)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - (boxDimensions[0].x / 8), lastBlockPosition.y - (boxDimensions[lastBlockPlacedNumber].y / 8)), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }

                lastBlockPlacedNumber = randomBlock;
            }
            ///newGroundTileTiltedUp
            else if (randomBlock == 1)
            {
                if (lastBlockPlacedNumber == 0)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + boxDimensions[0].x, lastBlockPlaced.transform.position.y + (boxDimensions[lastBlockPlacedNumber].y / 4) - 1f), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                else if (lastBlockPlacedNumber == 1)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - (boxDimensions[0].x / 8), lastBlockPosition.y + (boxDimensions[lastBlockPlacedNumber].y / 4) - 0.01f), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                    //downtile
                else if (lastBlockPlacedNumber == 2)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - (boxDimensions[0].x / 8), lastBlockPosition.y - (boxDimensions[lastBlockPlacedNumber].y / 8)), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }

                lastBlockPlacedNumber = randomBlock;
            }
                //newGroundTileTiltedDown
            else if (randomBlock == 2)
            {
                if (lastBlockPlacedNumber == 0)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + boxDimensions[0].x - 1f, lastBlockPlaced.transform.position.y - (boxDimensions[lastBlockPlacedNumber].y / 8) - 0.05f), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                else if (lastBlockPlacedNumber == 1)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - 1.0f - (boxDimensions[0].x / 4), lastBlockPosition.y + (boxDimensions[lastBlockPlacedNumber].y / 4) - 2.8f), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }
                else if (lastBlockPlacedNumber == 2)
                {
                    //lastPlayerPosition = currentPlayerPosition;
                    GameObject newPlatform = (GameObject)GameObjectUtil.Instantiate(prefabs[randomBlock], new Vector2(lastBlockPosition.x + (boxDimensions[0].x) - (boxDimensions[0].x / 8), lastBlockPosition.y - (boxDimensions[lastBlockPlacedNumber].y / 4) - 0.01f), prefabs[randomBlock].transform.rotation);
                    lastBlockPlaced = newPlatform;
                    lastBlockPosition = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y);
                }

                lastBlockPlacedNumber = randomBlock;
            }

        }
            
        //}
        
    }
    /*
    IEnumerator TileGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active) {
            int randomBlock = Random.Range(0, prefabs.Length);
            var newTransform = transform;
            //
            //Instantiate(prefabs[randomBlock], newTransform.position, Quaternion.identity);
            Instantiate(prefabs[randomBlock], new Vector2(lastBlockPlaced.transform.position.x + 10f, lastBlockPlaced.transform.position.y), Quaternion.identity);
            lastBlockPlaced = prefabs[randomBlock];
        }

        StartCoroutine(TileGenerator());
    }*/

}
