using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// * XVIII : SCOLL BACKGROUND BẰNG CAMERA 3D
public class Background : MonoBehaviour {

    // * XVIII: CHỌN ĐỐI TƯỢNG ĐỂ CHUYỂN ĐỘNG THEO TỐC ĐỘ NHÂN VẬT
    public MarioController Mario;
	// Use this for initialization
	void Start () { 
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();          // Lấy vị trí của camera3D
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // * XVIII : VECTOR NHẬN GIÁ TRỊ HIỆN TẠI CỦA BACKGROUND
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        // * XVIII : LẤY VỊ TRÍ CỦA NHÂN VẬT MỖI 0.2S 
        offset.x = Mario.transform.position.x;                                                                          // Tìm vị trí của nhân vật
        // * XVIII : THAY ĐỔI VỊ TRÍ CỦA BACKGROUND (Ở ĐÂY SỬ DỤNG 3D-> XOAY VỚI VẬN TỐC PHÙ HỢP TÍNH THEO THỜI GIAN THỰC)
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset*Time.deltaTime/0.8f;                        // Thay đỏi vị trí theo thời gian thực
	}
}
