using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour {
    // * V : TẠO BIẾN VẬN TỐC ẢO CHO THỀM
    public float speed = 0.05f, changedDirection = -1;
    // * V : TẠO VECTOR THAY ĐỔI POSITION CỦA THỀM->CÓ THỂ CHUYỂN ĐỘNG
    Vector3 Move;                                                                  

    public PauseMenu pausep;
	
    
    // Use this for initialization
	void Start () {
        // * V : GÁN GIÁ TRỊ CỦA POSITION CHO VECTOR VỪA TẠO
        Move = transform.position;


        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

	
	// Update is called once per frame
	void Update () {
        // * VII : NẾU NHƯ NGƯỜI CHƠI PAUSE THÌ THỀM GIỮ NGUYÊN POSITION
        if (pausep.pause)
        {
            this.transform.position = this.transform.position;
        }
        //* V : NẾU KHÔNG PAUSE THỀM SẼ DI CHUYỂN QUA LẠI
        else
        {
            Move.x += speed;
            this.transform.position = Move;
        }
       
	}


    // * V : NHẬN BIẾT VA CHẠM GIỮA THỀM VÀ NỀN ĐỂ ĐẢO CHIỀU ->  THỀM CHỈ DI CHUYỂN TRONG KHU VỰC GIỚI HẠN
    private void OnCollisionEnter2D(Collision2D col)                            
    {
        if (col.collider.CompareTag("Ground"))
            speed *= changedDirection;
       
    }
}
