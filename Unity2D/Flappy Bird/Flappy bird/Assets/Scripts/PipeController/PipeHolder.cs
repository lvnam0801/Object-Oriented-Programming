using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour {
    //Tạo biến truyền tốc độ
    public float speed;



    // Update is called once per frame
    //* THỰC HIỆN HÀM MỘT CÁCH LIÊN TỤC - ĐỀU ĐẶN VÀ THƯỜNG THEO CHU TRÌNH
    void Update () {
    // ! BÀI 11_4: XÓA SCRIPT CỦA PIPE_HOLDER (ALL SCRIPT NÀY) 
        if(BirdController.instance != null){
            if(BirdController.instance.flag == 1){
                Destroy(GetComponent<PipeHolder>());
            }
        }
    // ! BÀI 8_2: THỰC HIỆN DUY CHUYỂN PIPE_HOLDER
        _PipeMoveMent();
	}

    // ! BÀI 8_1: TẠO HÀM DI CHUYỂN PIPE_HOLDER KHI TRUYỀN THAY ĐỔI THÔNG SỐ THEO BIẾN Y
    //HÀM DI CHUYỂN PIPE(OBJECT) THEO VẬN TỐC
    void _PipeMoveMent(){
        Vector3 temp = transform.position;      //Lấy vị trí của PipeHolder
        temp.x -= speed*Time.deltaTime;       //Có 1 thanh slider thời gian(giúp mượt hơn), sẽ trừ từ từ xuống theo đúng thời gian
        transform.position = temp;

    }
    //HÀM BẮT VA CHẠM GIỮA 2 ĐỐI TƯỢNG(0 đối tượng nào có isTrigger)
    /*void OnCollisionEnter2D(Collision2D target){    //OnCollision -> (Collision)
        
    }*/
    // ! BÀI 9_2: TẠO MỘT EMPTY_OBJECT CÓ CONLIDER ĐỂ XÓA PIPE_HOLDER BẰNG HÀM SAU
    //HÀM BẮT VA CHẠM 2 (1 trong 2 đối tượng có isTrigger)
    void OnTriggerEnter2D(Collider2D target){       //Ontrigger -> (Collider)
        if(target.tag == "Destroy"){
            Destroy(gameObject);            //Destroy đối tượng chứa hàm
        }
    }

}
