using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAttack : MonoBehaviour {
    // * XI : TẠO BIẾN NHẬN BIẾT CÓ TẤN CÔNG HAY KHÔNG
    public float attackdelay = 0.5f;
    public bool attacking = false;                          //Cho phép người chơi tấn công 1 lần


    public SpawerArm Attack;
    private Animator anim;
    public SoundSManeger sounds;
    // * XI : CHẠY NGHAY CA KHI ĐỐI TƯỢNG KHÔNG ĐƯỢC ENABLE
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
    }

    // Update is called once per frame
    void Update () {
        // * XI : TẤN CÔNG KHI CÓ LỆNH GỌI HÀM
		if(Input.GetKeyDown(KeyCode.R) && !attacking)
        {
            attacking = true;                           //Tạo giá trị cho biến tấn côn;
            attackdelay = 0.5f;                         // Cập nhật thời gian delay
            Attack.Arms();                              //Thực hiện sinh ra Arm để tấn công
            sounds.PlaySound("arm");
        }
        if (attacking)
        {
            if(attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;                          // * Biến chạy theo thời gian thực, cho tấn công trong thời gian nhất định
            }
            else
            {
                attacking = false;
            }
        }
        // * XI : THỰC HIỆN ANIMATON ATTACKING
        anim.SetBool("Attacking", attacking);
       
	}
}
