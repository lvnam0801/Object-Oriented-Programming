using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMonster : MonoBehaviour {
    // * IX : VÌ ĐỐI TƯỢNG ẢNH HƯỞNG ĐẾN NHÂN VẬT-> CẦN THAM CHIẾU ĐẾN NHÂN VẬT
    public MarioController Mario;
    private bool blink = false;                                 //Tạo biến nhận biết đã va chạm với monster
    private BoxCollider2D myCollider;                           //Tham chiếu conlider để nhân vật có thể nhấp nháy khong bị sát thương

    public SoundSManeger sounds;
	// Use this for initialization
	void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();
        myCollider = GetComponent<BoxCollider2D>();
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
	}
    void Update()
    {
        // * IX : NẾU XẢY RA VA CHẠM THÌ THỰC HIỆN LỆNH GỌI HÀM : GÂY SÁT THƯƠNG CHO NHÂN VẬT
        if (blink)
        {
            blink = false;
            myCollider.isTrigger = true;
            StartCoroutine(Blink());
        }
    }
    // * IX : HOẠT ĐỘNG KHI CÓ VA CHẠM VỚI 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // * X : NẾU GẶP NHÂN VẬT THÌ GÂY SÁT THƯƠNG
        if (collision.collider.CompareTag("Mario"))
        {
            Mario.Damage(1);                                                //Gây sát thương cho nhân vật (-1 numOfLife của lớp MarioController)
            Mario.Knocback(1.5f);                 //Đẩy lùi nhân vật để tránh gây sát thương liên tục
            blink = true;
        }
        // * X : NẾU GẶP ARM THÌ DESTROY
        if (collision.collider.CompareTag("Arm"))
        {
            sounds.PlaySound("destroy");
            Destroy(gameObject);
        }
    }
    // * IX :  DELAY 1 KHOẢNG THỜI GIAN TRƯỚC KHI CONLIDER CỦA MONSTER NO IS TRIGGER AGAIN
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(3);
        Mario.anim.SetBool("Blink", false);
        myCollider.isTrigger = false;
    }
}
