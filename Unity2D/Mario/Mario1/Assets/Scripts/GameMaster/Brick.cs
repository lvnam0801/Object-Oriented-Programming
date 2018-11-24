using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public GameMaster gameMaster;
    public Rigidbody2D myBody;
    public GameObject coins;
    public Animator anim;
    public float posY = 0.8f;
    private bool destroy = true, flatForm = false ;
    private float defaultY;
    // Use this for initialization
    void Start () {
        // XXV : TRUY CẬP CÁC THÀNH PHẦN CẦN THIẾT
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        defaultY = transform.position.y;
	}
    private void FixedUpdate()
    {
        if (transform.position.y > posY) transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        // * XXV : KHI NHÂN VẬT ĐẨY VIÊN GẠCH
        if (transform.position.y - defaultY > 0.05f)
        {
            if(destroy) coins.SetActive(true);
            anim.SetBool("Die", true);
            flatForm = true;
            destroy = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // XXV : KHI ĂN VÀNG THÌ KHÔNG CHUYỂN ĐỘNG NỮA
        if(flatForm && collision.collider.CompareTag("PlatForm"))
        {
            myBody.bodyType = RigidbodyType2D.Static;
           
        }
        
    }
}
