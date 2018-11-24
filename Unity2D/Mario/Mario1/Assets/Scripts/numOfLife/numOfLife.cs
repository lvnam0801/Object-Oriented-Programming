using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//* CHỈ DÙNG ĐỂ HIỆN THỊ SỐ MẠNG SỐNG CỦA NHÂN VẬT
public class numOfLife : MonoBehaviour {
    // * VIII : MẢNG DANH SÁNH CÁCH SPRITE CỦA TỪNG SỐ MẠNG SỐNG 1
    public Sprite[] LifeSprite;                        

    // * VIII : VÌ SỐ MẠNG SỐNG THUỘC NHÂN VẬT NÊN PHẢI THAM CHIẾU NHÂN VẬT ĐỂ TRUY CẬP SỐ MẠNG CÒN LẠI
    public MarioController Mario;                        
    // * VIII : TẠO BIẾN THAM CHIẾU ĐẾN INMAGE CỦA CANVAS -> THAY ĐỔI HÌNH ẢNH TRÊN CONPONENT INMAGE
    public Image numOfLifeUI;
	// Use this for initialization
	void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();                  // Tham chiếu đến đối tượng nhân vật->truy cập đến biến numOfLife
      
    }

	
	// Update is called once per frame
	void Update () {
        // * VII : HIỆN THỊ ẢNH PHÙ HỢP, ĐÚNG THEO SỐ MẠNG SỐNG ĐANG CÒN LẠI CỦA NHÂN VẬT
        if(Mario.numOfLife > 0)                             // Nếu số mạng sống > 0 tính cả mạng đang sử dụng thì hiện thị Image thích hợp
        numOfLifeUI.sprite = LifeSprite[Mario.numOfLife - 1];
	}
}
