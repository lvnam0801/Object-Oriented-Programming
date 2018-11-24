using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {
    // * LÀM CHO ĐẠN BẮN ĐƯỢC
    public float speed = 0.5f;
    bool direction ;
    private Vector3 move;


    // * TRUY CẬP ĐẾN NHÂN VẬT -> TÌM HƯỚNG DI CHUYỂN
    public MarioController Mario;
    // * THỰC HIỆN ANIMATIONS
    public Animator anim;
    // * FIX LỖI HÀM PAUSE
    public PauseMenu pausep;
    // * TẠO HIỆU ỨNG
	// Use this for initialization
	void Start () {
        move = transform.position;
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponentInParent<MarioController>();
        direction = Mario.faceright;
        anim = GetComponent<Animator>();
        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }
	
	// Update is called once per frame
	void Update () {
        // * FIX LỖI PAUSE
        if (pausep.pause )
        {
            this.transform.position = this.transform.position;
        }
        // * THỰC HIỆN FLY
        else
        {
            if (direction)
            {
                move.x += speed;
            }
            else
            {
                move.x -= speed;
            }
            transform.position = move;
        }
    }
    private void FixedUpdate()
    {
        // * GIỚI HẠN PHẠM VI FLY
        if (Mathf.Abs(Mario.transform.position.x - this.gameObject.transform.position.x) >= 12)
        {
            Destroy(gameObject);
        }
    }
    // * TẠO HIỆU ỨNG ANIMATION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            speed = 0.1f;
            anim.SetBool("Attack", true);
        }
    }
    // * DESTROY OBJECT
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("monster"))
        {
            Destroy(gameObject);
        }
    }   
}
