using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

    //! BÀI 3: CHỈNH SỬA BACK GROUND
	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>(); //T sr là biến lấy component của SpriteRenderer cảu BGScaler
        Vector3 tempScale = transform.localScale;       // Lấy scale của transform của BGScaler

        float height = sr.bounds.size.y; //Lấy Size vị trí biên trên của sprite (ảnh nền của mình)//* Lưu ý đây là size không phải scale
        float width = sr.bounds.size.x;
        //Size của camera theo chiều cao là bằng 2*size;
        float worlHeight = Camera.main.orthographicSize * 2f; // Tìm height của camera theo size( không phải theo scale)
        float worlWidth = worlHeight * Screen.width / Screen.height;    //Tìm chiều rộng của camera theo size (không phải theo scale)

        tempScale.y = worlHeight / height; // Độ giãn của background so với ban đầu đúng bằng size của camera
        tempScale.x = worlWidth / width; //Độ giãn của chiều rộng background so với ban đầu đúng bằng size chiều rộng của camera
        transform.localScale = tempScale;
        //Size của background phụ thuộc vào scale của brakground
           
    }
}
