using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

    public int sizeX;
    public int sizeZ;

    public float terDetail;
    public float terHeight;
    int seed;

    public GameObject[] blocks;


	void Start () {
        seed = Random.Range(100000, 999999);
        GenerateTerrain();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateTerrain()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                int y = (int)(Mathf.PerlinNoise((x / 2 + seed) / terDetail, (z / 2 + seed) / terDetail) * terHeight);
                GameObject Ground = Instantiate(blocks[0], new Vector3(x, y, z), Quaternion.identity) as GameObject;
                Ground.transform.SetParent(GameObject.FindGameObjectWithTag("Environment").transform);
            }
        }
    }

}
