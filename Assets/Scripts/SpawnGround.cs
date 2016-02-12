using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGround : MonoBehaviour {

    public GameObject platform;
    public GameObject platform2;

    public GameObject platform3;
    public GameObject platform4;
    public int maxObjects;
    public BoxCollider2D platformCollider;
    public BoxCollider2D platform2Collider;
    
    //public GameObject platform;
    //public Camera camera;
    //private Random rand;
    private Vector2 originPosition;
    public GameObject player;

    private int originalCharacterPosition = 5;
    private int newCharacterPosition;
    private int numberOfBlocks = 0;
    private int previousNumberOfBlocks = 0;
    private float originalPlayerPosition;
    private float currentPlayerPosition = 0;
    private float oldPlayerPosition = 0f;

    private List<string> blocks = new List<string>();
    //private List<string> blocksToDestroy = new List<string>();

    private float platformWidth;
    private float platformHeight;

    private float platform2Width;
    private float platform2Height;

    private float platform3Width;
    private float platform3Height;

    private float platform4Width;
    private float platform4Height;

    private int lastBlockPlaced = 1;

    private GameObject lastBlock;

	// Use this for initialization
	void Start () {
        //platform3 = GameObject.Find("PurpleGround (1)");
        //originPosition = new Vector2(0.47f, -5.07f);
        //get the original position of the purple ground block and transfers it to world position
        originPosition = new Vector2(platform.transform.position.x, platform.transform.position.y);
        Vector2 worldPosition = platform.transform.TransformPoint(originPosition);

        //getting height and width of boxes
        platformWidth = platform.GetComponent<Renderer>().bounds.size.x;
        platformHeight = platform.GetComponent<Renderer>().bounds.size.y;

        platform3Width = platform3.GetComponent<Renderer>().bounds.size.x;
        platform3Height = platform3.GetComponent<Renderer>().bounds.size.y;

        platform4Width = platform4.GetComponent<Renderer>().bounds.size.x;
        platform4Height = platform4.GetComponent<Renderer>().bounds.size.y;

        Spawn(10);

	}

    void Update()
    {
        //this works in the if statement, but it is creating too many blocks
        //Mathf.Abs(player.transform.position.x) > Mathf.Abs(originalCharacterPosition)+5

        //I am getting an error because I am modifying a list while it is being iterated through
        currentPlayerPosition = Mathf.Abs(player.transform.position.x);
        //Debug.Log(currentPlayerPosition - oldPlayerPosition);
        if (Mathf.Abs(currentPlayerPosition) - Mathf.Abs(oldPlayerPosition) > 2 )
        {
            Spawn();
            oldPlayerPosition = currentPlayerPosition;
            //Debug.Log("current player position: " + currentPlayerPosition);
            destroySpawn(currentPlayerPosition);
            //Debug.Log("number of elements in blocks: " + blocks.Count);
            
        }

    }


    void Spawn()
    {
        //picks a random number
        int pickBlock = Random.Range(1, 4);
        //gets the last block that was created
        lastBlock = GameObject.Find(blocks[blocks.Count - 1].ToString());
        Vector2 lastBlockPosition = lastBlock.transform.right;

        for (int i = 0; i < maxObjects; i++ )
        {
            if (lastBlockPlaced == 1)
            {
                instantiateBlock(pickBlock, lastBlockPosition, platformWidth, platformHeight, lastBlock);
            }
            else if (lastBlockPlaced == 2)
            {
                //int pickBlock = Random.Range(1, 2);
                //lastBlockPosition += new Vector2(platform3Width, 0);
                //Debug.Log("lastBlockPosition: " + lastBlockPosition);
                instantiateBlock(pickBlock, lastBlockPosition, platform3Width, platform3Height, lastBlock);
                Debug.Log("Spawned block 3.");
            }
            else if (lastBlockPlaced == 3)
            {
                //int pickBlock = Random.Range(1, 2);
                //lastBlockPosition += new Vector2(platform4Width, 0);
                //Debug.Log("lastBlockPosition: " + lastBlockPosition);
                instantiateBlock(pickBlock, lastBlockPosition, platform4Width, platform4Height, lastBlock);
                Debug.Log("Spawned block 4.");
            }
            else
            {
                //int pickBlock = Random.Range(1, 2);
                instantiateBlock(pickBlock);
                Debug.Log("Spawned block leftover.");
            }
        
        }
    }//end Spawn() method

    void Spawn(int numberOfObjects)
    {
        for (int i = 0; i < numberOfObjects ; i++)
        {
            Vector2 nextBlock = originPosition + new Vector2(2.5f, 0f);
            GameObject newPlatform = (GameObject)Instantiate(platform, nextBlock, Quaternion.identity);
            originPosition = nextBlock;
            newPlatform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
        }
    }//end Overloaded Spawn() method

    //creates a block based on the number that is fed in through pickBlock
    //if nothing matches, it just creates a preset block in the else statement
    public void instantiateBlock(int pickBlock)
    {
        if (pickBlock == 1)
        {
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            Instantiate(platform, nextBlock, Quaternion.identity);
            originPosition = nextBlock;
            platform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString() + "(Clone)");
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
        else if (pickBlock == 2)
        {
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            Instantiate(platform3, nextBlock, platform3.transform.rotation);
            originPosition = nextBlock;
            platform3.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString() + "(Clone)");
            numberOfBlocks += 1;
            lastBlockPlaced = 2;
        }
        else
        {
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            Instantiate(platform, nextBlock, Quaternion.identity);
            originPosition = nextBlock;
            platform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString() + "(Clone)");
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
    }//end instantiateBlock() method

    public void instantiateBlock(int pickBlock, Vector2 vector, float width, float height, GameObject lastBlock)
    {
        //FOR PLATFORM****************************************************************************************
        if (pickBlock == 1)
        {
            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth, lastBlock.transform.position.y), Quaternion.identity);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth - 0.2f, lastBlock.transform.position.y + (lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y) / 6), Quaternion.identity);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth - 0.2f, lastBlock.transform.position.y - platform.transform.position.x + 0.3f), Quaternion.identity);
                newPlatform.name = numberOfBlocks.ToString();
            }

            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
        //FOR PLATFORM3****************************************************************************************
        else if (pickBlock == 2)
        {
            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + platformWidth - 0.1f, lastBlock.transform.position.y + platformHeight  * 0.25f), platform3.transform.rotation);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x, lastBlock.transform.position.y), platform3.transform.rotation);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + platform4Width / 1.5f, lastBlock.transform.position.y), platform3.transform.rotation);
                //FOR X COORDINATE - lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 1f
                newPlatform.name = numberOfBlocks.ToString();
            }
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 2;
        }
        //FOR PLATFORM4****************************************************************************************
        else if (pickBlock == 3)
        {
            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + platformWidth, lastBlock.transform.position.y - platformHeight * 0.25f), platform4.transform.rotation);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 0.93f, lastBlock.transform.position.y + platform3.transform.position.x + platform3.transform.position.y + 0.38f), platform4.transform.rotation);
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 1f, lastBlock.transform.position.y - platform4Height / 2.93f), platform4.transform.rotation);
                newPlatform.name = numberOfBlocks.ToString();
            }
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 3;
        }
        else
        {
            //Vector2 nextBlock = originPosition + vector;
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            GameObject newPlatform = (GameObject)Instantiate(platform, nextBlock, Quaternion.identity);
            originPosition = nextBlock;
            newPlatform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
    }//end instantiateBlock() method

    /*
    //THIS IS WORKING DO NOT MESS WITH.  IT IS ROUGH, BUT WORKS
    public void instantiateBlock(int pickBlock, Vector2 vector, float width, float height, GameObject lastBlock)
    {
        //FOR PLATFORM****************************************************************************************
        if (pickBlock == 1)
        {
            //Debug.Log("vector.x: " + vector.x + " vector.y: " + vector.y);
            //Vector2 nextBlock = originPosition + new Vector2(vector.x * width, 0);
            //Vector2 nextBlock = new Vector2();
            //nextBlock.Set(originPosition.x + vector.x, originPosition.y + vector.y);
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            //Debug.Log("nextBlock: " + nextBlock);
            //THIS WORKS DON"T MESS IT UP
            //THIS WORKS FOR platform to platform blocks
            //GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth, lastBlock.transform.position.y), Quaternion.identity);
            //THIS WORKS PRETTY WELL
            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth, lastBlock.transform.position.y), Quaternion.identity);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth - 0.2f, lastBlock.transform.position.y + (lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y)/6), Quaternion.identity);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + platformWidth - 0.2f, lastBlock.transform.position.y - platform.transform.position.x + 0.3f), Quaternion.identity);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            
            //GameObject newPlatform = (GameObject)Instantiate(platform, nextBlock, Quaternion.identity);
            //GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x), lastBlock.transform.position.y + ((lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y)) / 10), Quaternion.identity);
            //originPosition = nextBlock;
            //newPlatform.name = numberOfBlocks.ToString();
            //newPlatform.transform.position = new Vector2 (vector.x * width, 0);
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
            //FOR PLATFORM3****************************************************************************************
        else if (pickBlock == 2)
        {
            //Vector2 nextBlock = originPosition + vector;
            //Vector2 nextBlock = originPosition + new Vector2(vector.x * width, vector.y * height);
            Vector2 nextBlock = originPosition + new Vector2(platform3Width/2, platform3Height-3.2f);
            //GameObject newPlatform = (GameObject)Instantiate(platform3, nextBlock, platform3.transform.rotation);
            //This works for platform to platform3
            //GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x), lastBlock.transform.position.y + ((lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y))/4), platform3.transform.rotation);
            //GameObject newPlatform = (GameObject)Instantiate(platform3, lastBlock.transform.TransformPoint(lastBlock.transform.right), platform3.transform.rotation);

            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 0.2f, lastBlock.transform.position.y + ((lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y)) / 4), platform3.transform.rotation);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 1f, lastBlock.transform.position.y+platform3Height/2.93f), platform3.transform.rotation);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform3, new Vector2(lastBlock.transform.position.x + platform4Width/1.5f, lastBlock.transform.position.y), platform3.transform.rotation);
                //FOR X COORDINATE - lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 1f
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            
            //originPosition = nextBlock;
            //newPlatform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 2;
        }
        //FOR PLATFORM4****************************************************************************************
        else if (pickBlock == 3) {
            //Vector2 nextBlock = originPosition + vector;
            Vector2 nextBlock = originPosition + new Vector2(platform4Width/2, (platform4Height-3f) *-1);
            //GameObject newPlatform = (GameObject)Instantiate(platform4, nextBlock, platform4.transform.rotation);
            if (lastBlockPlaced == 1)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 0.2f, lastBlock.transform.position.y - ((lastBlock.GetComponent<Renderer>().bounds.max.y - lastBlock.GetComponent<Renderer>().bounds.min.y)) / 4), platform4.transform.rotation);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 2)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 0.93f, lastBlock.transform.position.y + platform3.transform.position.x + platform3.transform.position.y+0.38f), platform4.transform.rotation);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            else if (lastBlockPlaced == 3)
            {
                GameObject newPlatform = (GameObject)Instantiate(platform4, new Vector2(lastBlock.transform.position.x + (lastBlock.GetComponent<Renderer>().bounds.max.x - lastBlock.GetComponent<Renderer>().bounds.min.x) - 1f, lastBlock.transform.position.y - platform4Height / 2.93f), platform4.transform.rotation);
                originPosition = nextBlock;
                newPlatform.name = numberOfBlocks.ToString();
            }
            //originPosition = nextBlock;
            //newPlatform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 3;
        }
        else
        {
            //Vector2 nextBlock = originPosition + vector;
            Vector2 nextBlock = originPosition + new Vector2(platformWidth, 0f);
            GameObject newPlatform = (GameObject)Instantiate(platform, nextBlock, Quaternion.identity);
            originPosition = nextBlock;
            newPlatform.name = numberOfBlocks.ToString();
            blocks.Add(numberOfBlocks.ToString());
            numberOfBlocks += 1;
            lastBlockPlaced = 1;
        }
    }//end instantiateBlock() method
    */

    void destroySpawn(float currentPlayerPosition)
    {
        //cycles through the blocks list, and if the current position minus the blocks position is greater than 10, it destroys the block
        //foreach (string value in blocks)
        for (int i = 0; i < blocks.Count - 1; i++)
        {
            string value = blocks[i].ToString();
            //Debug.Log(value);
            //checks to see if the block exists, if it does, then checks the position verses the players position, if it is greater than 10, destroys the blocks
            if (GameObject.Find(value) != null)
            {
                //gets the blocks position
                float objectPosition = GameObject.Find(value).transform.position.x;
                if (Mathf.Abs(currentPlayerPosition) - Mathf.Abs(objectPosition) > 10)
                {
                    Destroy(GameObject.Find(value));
                    //this is giving an invalidoperationexpection, moving something from the list while it is working on it
                    blocks.Remove(value);
                    //blocks.Sort();
                    //blocksToDestroy.Add(value);
                    previousNumberOfBlocks++;
                }
            }

        }
        //goes through the list of blocksToDestroy, and removes them from the blocks List
        //THIS KIND OF WORKS
        //foreach (string value in blocksToDestroy)
        //{
        //    blocks.Remove(value);
        //}
        //clears the blocks after destroying them
        //blocksToDestroy.Clear();

            /*
            for (int i = 0; i < numberOfBlocks; i++)
            {
                float objectPosition = GameObject.Find(i.ToString() + "(Clone)").transform.position.x;
                //Debug.Log("ground block position: " + objectPosition + " currentPlayerPosition: " + Mathf.Abs(currentPlayerPosition));
                //this works ok, but eventually it catches up destroying beneth the player
                //(i) < Mathf.Abs(player.transform.position.x)
                if (Mathf.Abs(currentPlayerPosition) - objectPosition > 10)
                {
                    Destroy(GameObject.Find(i.ToString() + "(Clone)"));
                    string blockName = i.ToString() + "(Clone)";
                    //int index = blocks.IndexOf(blockName);
                    blocks.Remove(blockName);
                    previousNumberOfBlocks++;
                    //Debug.Log(i);
                    
                }
            }
            */
        
    }
    //gets the camera bounds
    /*
    public static Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
    */
}
