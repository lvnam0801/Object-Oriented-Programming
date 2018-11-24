using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    // *TRUY CẬP ĐẾN GAMEMASTER
    public GameMaster gameMaster;
	// Use this for initialization
	void Start () {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponentInParent<GameMaster>();
        GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>().PlaySound("coins");
        gameMaster.points++;
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
