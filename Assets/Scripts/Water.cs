using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    //constants for springs
    const float springconstant = 0.02f;
    const float damping = 0.04f;
    const float spread = 0.05f;
    const float z = -1f;

    //for mesh positions
    float[] xpositions;
    float[] ypositions;
    float[] velocities;
    float[] accelerations;
    LineRenderer Body;
    GameObject[] meshobjects;
    GameObject[] colliders;
    Mesh[] meshes;

    //dimensions of water
    float baseheight;
    float left;
    float bottom;

    //particle system
    public GameObject splash;

    public Material mat;
    public GameObject watermesh;


	// Use this for initialization
	void Start () {
        //SpawnWater(Camera.main.pixelWidth / 2, Camera.main.pixelWidth, 100, 100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnWater(float left, float width, float top, float bottom)
    {
        //get the edges of the water
        int edgecount = Mathf.RoundToInt(width) * 5;
        int nodecount = edgecount + 1;
        //make nodes
        Body = gameObject.AddComponent<LineRenderer>();
        Body.material = mat;
        Body.material.renderQueue = 1000;
        Body.SetVertexCount(nodecount);
        Body.SetWidth(0.5f, 0.5f);
        //initialize top variables
        xpositions = new float[nodecount];
        ypositions = new float[nodecount];
        velocities = new float[nodecount];
        accelerations = new float[nodecount];

        meshobjects = new GameObject[edgecount];
        meshes = new Mesh[edgecount];
        colliders = new GameObject[edgecount];

        baseheight = top;
        this.bottom = bottom;
        this.left = left;

        //set values to arrays

        for (int i = 0; i < nodecount; i++)
        {
            ypositions[i] = top;
            xpositions[i] = left + width * i / edgecount;
            accelerations[i] = 0;
            velocities[i] = 0;
            Body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));
        }
    }
}
