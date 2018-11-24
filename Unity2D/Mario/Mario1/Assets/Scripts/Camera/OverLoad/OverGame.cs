using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGame : MonoBehaviour {
    public MarioController Mario;
	// Use this for initialization
	void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();
	}

    // * NẾU GẶP NHÂN VẬT -> ĐƯA NHÂN VẬT VỀ VỊ TRÍ BẮT CỐ ĐỊNH
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            if (Mario.transform.position.x < 90)
            {
                Mario.transform.position = new Vector3(12, -1.4f, Mario.transform.position.z);
            }
            else
            {
                Mario.transform.position = new Vector3(90, -1.4f, Mario.transform.position.z);
            }
            Mario.Damage(1);
        }
    }
    // * NẾU GẶP CÁC MONSTER THÌ SẼ DESTROY CÁC MONSTER.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("monster"))
            Destroy(collision.gameObject);
    }
}
