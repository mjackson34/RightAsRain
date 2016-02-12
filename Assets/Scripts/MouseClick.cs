using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

    public float test;
    public GameObject prefab;

    private GameObject player;
    private Ray ray;
    private RaycastHit hit;
    private int blockCount = 1;

    void Awake()
    {
        player = GameObject.Find("player");
    }

	void Start () {
	
	}
	
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKey(KeyCode.Mouse0)) {
                if (blockCount == 1)
                {
                    GameObject obj = (GameObject)Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, player.transform.position.z), Quaternion.identity);
                    obj.name = "playerPlacedBlock";
                    blockCount--;
                    Debug.Log(blockCount);
                }
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                if (blockCount == 0)
                {
                    Destroy(GameObject.Find("playerPlacedBlock"));
                    blockCount++;
                    Debug.Log(blockCount);
                }

            }
        }
	}
}
