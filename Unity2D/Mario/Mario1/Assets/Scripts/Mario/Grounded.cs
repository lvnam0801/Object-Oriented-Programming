
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * VÌ NỀN ĐẤT CHỈ GIAO TIẾP CHỦ YẾU VỚI CAMERA NÊN ADD VÀO NHÂN VẬT LUÔN
// * NHẬN BIẾT VA CHẠM
public class Grounded : MonoBehaviour {
    // * III_ 2 : TẠO MỘT BIẾN ĐỐI TƯỢNG THUỘC KIỂU LỚP MARIOCONTROLLER
    public MarioController Mario;
    // * XX : FIX LỐI MOVING PLAT
    public MovingPlat Move;
    public Vector3 MarioMove;

    // *** KHỞI TẠO GIÁ TRỊ CHO CÁC BIẾN ĐỐI TƯỢNG
    void Start()
    {
        // * III_3 : THAM CHIẾU ĐẾN LỚP MARIOCONTROLLER -> CÓ THỂ THAY ĐỔI GIÁ TRỊ CỦA ĐỐI TƯỢNG THUỘC LỚP ĐÓ
        Mario = gameObject.GetComponentInParent<MarioController>();
        Move = GameObject.FindGameObjectWithTag("MovingPlat").GetComponent<MovingPlat>();
    }
    // * III_4 : NHẬN BIẾT VA CHẠM GIỮA 2 ĐỐI TƯỢNG MÀ ÍT NHẤT MỘT ĐỐI TƯỢNG ĐƯỢC IS TRIGGER
    void OnTriggerEnter2D(Collider2D collision)                             //Khi vừa mới nhận thấy có va chạm (vừa mới xuất hiện trên mặt đất)->grounded = true   
    {
        if(collision.isTrigger == false)
            Mario.grounded = true;

    }
    private void OnTriggerStay2D(Collider2D collision)                      //Vẫn đang trong trạng thái va chạm (vẫn đang đứng trên mặt đất) -> grounded = true
    {
        if (collision.isTrigger == false || collision.CompareTag("Water"))
            Mario.grounded = true;
        // * XX : FIX LỖI MOVING PLAT
        if (collision.CompareTag("MovingPlat"))
        {
            MarioMove = Mario.transform.position;
            MarioMove.x += Move.speed*1.3f;
            Mario.transform.position = MarioMove;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)                      //Khi va chạm vừa kết thúc (nhân vật vừa rời khỏi mặt đất) -> ground = false
    {
        if(collision.isTrigger == false || collision.CompareTag("Water"))
            Mario.grounded = false;                                            
    }
}
