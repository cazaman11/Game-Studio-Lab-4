using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLoader : MonoBehaviour {

    [SerializeField]
    private GameObject block;
    [SerializeField]
    private float blockSize;
    [SerializeField]
    private int blockNum;
    [SerializeField]
    private int layers;
    [SerializeField]
    private Vector3 startPos;
    private Vector3 currPos;

	// Use this for initialization
	void Start () { 
        for (int i = 0; i < layers; i++) {
            currPos = startPos + i*(Vector3.down * blockSize);
            for (int j = 0; j < blockNum; j++) {
                Instantiate(block, currPos, Quaternion.identity);
                currPos += (Vector3.right * blockSize);
            }
        }
	}
	
}
