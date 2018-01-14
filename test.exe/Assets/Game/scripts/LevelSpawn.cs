using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour {

    public GameObject[] groundBlocks;
    public Vector3 spawnValues;

	void Start ()
    {
        LevelGeneration();
	}

	void Update () {
		
	}

    void LevelGeneration ()
    {
        int i = 0;

        while (i <= spawnValues.x * spawnValues.y * spawnValues.z)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(groundBlocks[0], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            i++;
        }
    }
}
