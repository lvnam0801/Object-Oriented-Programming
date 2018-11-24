using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mus : MonoBehaviour {
    public MarioController Mario;
	// Use this for initialization
	void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            Mario.numOfLife = 4;
            Destroy(gameObject);
        }
    }


}
