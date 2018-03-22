using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerator : MonoBehaviour {

    public GameObject dotPrefab;
    public int rn;

	// Use this for initialization
	void Start () {

        rn = Random.Range(0, 9);

        if (rn > 2)
        {
            GameObject dot = (GameObject)Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
