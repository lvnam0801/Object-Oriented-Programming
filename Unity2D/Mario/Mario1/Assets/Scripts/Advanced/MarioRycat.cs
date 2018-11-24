using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// * XXI : PLAYRYCAT (NHẬN BIẾT VỊ TRÍ CỦA MOUSE TRONG MÀN HÌNH)
public class MarioRycat : MonoBehaviour {
    public float shootDelay = 0;
    public LayerMask WhatToHit;                         // DANH SÁCH MỤC TIÊU ĐỐI TƯỢNG VA CHẠM
    public Transform firePoint;                         // Vị trí ban đầu 
	// Use this for initialization
	void Start () {
        firePoint = transform.Find("ShootPoint");       // VỊ TRÍ BAN ĐẦU
	}
	
	// Update is called once per frame
	void Update () {
        // * XXI : THỰC HIỆN DELAY SHOOT
        shootDelay += Time.deltaTime;                       // * DELAY TIME CLICK MOUSE

        if(shootDelay >= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))       
            {
                shootDelay = 0;
                Shot();
            }
        }

	}

    void Shot()
    {
        Vector2 mousePos = new Vector2                                       // * XXI : VỊ TRÍ CON TRỎ CHUỘT   (VỊ TRÍ ĐÍCH)              
                (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,     // * XXI : DỊCH VỊ TRÍ TỪ CAMERA
                 Camera.main.ScreenToWorldPoint(Input.mousePosition).y);    // * XXI : LẤY VỊ TRÍ X, Y CỦA CON TRỎ CHUỘT TỪ CAMERA THẾ GIỚI

        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);                 // Gám vị trí ban đầu cho biến

        RaycastHit2D hit = Physics2D.Raycast(firePointPos, (mousePos - firePointPos), 10, WhatToHit);                                // Tạo đường (vị trí ban đầu, hướng di chuyển, những lier thuộc đối tơngjw)
        Debug.DrawLine(firePointPos, (mousePos - firePointPos)*100, Color.blue);                                    // Kiểm tra xem đã hiện chưua
            
        if(hit.collider != null)                                    // NẾU CÓ VA CHẠM
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);               // Tên colider mà va chạm
            hit.collider.SendMessageUpwards("Destroy", 3);          // TEST
        }
    }
}
