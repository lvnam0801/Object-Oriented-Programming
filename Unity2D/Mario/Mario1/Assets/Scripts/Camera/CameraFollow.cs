using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//* TẠO CAMERA ĐI THEO NHÂN VẬT GIÚP NHÂN VẬT DI CHUYỂN THEO CAMERA

public class CameraFollow : MonoBehaviour {
    // * VI : TẠO BIẾN DELAY TIME TRONG CAMERA
    private float smoothtimeX, smoothtimeY;                                           //Tạo biến chứa giá trị thười gian delay
    private Vector2 velocity;                                                         //Xác định loại giá trị thay đổi trong hàm Mathf.SmoothDamp
    private GameObject Mario;                                                         //Tạo một gameObject để xác định đối tượng cần theo dõi

    // * VI : GIỚI HẠN CAMERA
    public Vector2 minPos, maxPos;                                                   //Giới hạn vị trí của camera có thể đến được
    public bool bound;                                                               //Cho phép giới hạn hay không                                              
	// Use this for initialization
	void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // * VI : CẬP NHẬT VECTOR TỪ VỊ TRÍ CŨ ĐẾN VỊ TRÍ MỚI (TỪ VỊ TRÍ CỦA CAMERA SANG VỊ TRÍ CỦA NHÂN VÂT)
        float posX = Mathf.SmoothDamp(this.transform.position.x, Mario.transform.position.x, ref velocity.x, smoothtimeX);                  
        float posY = Mathf.SmoothDamp(this.transform.position.y, Mario.transform.position.y, ref velocity.y, smoothtimeY);
        // * VI : CẬP NHẬT VỊ TRÍ VÀO CHO CAMERA
        transform.position = new Vector3(posX, posY, transform.position.z);
        
        // * VI : GIỚI HẠN CAMERA (NHẬP GIỚI HẠN TỪ DISPLAY UNITY) 
        if (bound)
        {
               transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),                                      // Mathf.Clamp(x, y ,z) Trả về giá trị x luôn nằm giữa y, z (x bị giới hạn bởi y và z) Clamp là bị treo giữa
               Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
               Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}
