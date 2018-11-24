using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlallingPlat : MonoBehaviour {
    public Rigidbody2D r2;                                              //* Biến tham chiếu đến Rigiedbody2D của đối tượng        
    public float timedelay;
	// Use this for initialization
	void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();                    //* Tham chiếu đến đối tượng
	}

    private void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    // * V : NHẬN BIẾT VA CHẠM GIỮA NHÂN VẬT VÀ THỀM (nếu va chạm sẽ cho thềm đi xuống)
    private void OnCollisionEnter2D(Collision2D col)                     //Nhận biết va chạm giữa 2 conlider mà cả 2 đều không phải Itrigger->thực hiện nếu có va chạm
    {
        if (col.collider.CompareTag("Mario"))
        {
            StartCoroutine(fall());                                      //Gọi hàm IEnumerator
        }
    }

    // * V : DELAY MỘT KHOẢNG THỜI GIAN PHÙ HỢP RỒI THỰC CHO THỀM CHỊU TÁC ĐỘNG VẬT LÝ (STATIC ->DYNAMIC) -> THỀM BỊ RƠI XUỐNG
    IEnumerator fall()                                                  //Sử dụng hàm để delay thời gian, thay đổi từ trạng thái không bị tác động static-> Dynmaic(chịu tác động của vật lý)
    {
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
