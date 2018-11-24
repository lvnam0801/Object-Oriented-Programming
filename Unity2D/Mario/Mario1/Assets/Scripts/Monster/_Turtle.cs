using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Turtle : MonoBehaviour {
    public int Health = 100;                //HP của quái vật
                                            // Use this for initialization

    public SoundSManeger sounds;
    // Use this for initialization
    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
    }
    // Update is called once per frame
    void Update() {
        if (Health <= 0)
        {
            sounds.PlaySound("destroy");
            Destroy(gameObject);
        }
    }

    // * X : TẠO HÀM BỊ TẤN CÔNG TỪ NHÂN VẬT
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arm"))
        {
            sounds.PlaySound("armAtt");
            Health -= 20;
        }
    }
}
