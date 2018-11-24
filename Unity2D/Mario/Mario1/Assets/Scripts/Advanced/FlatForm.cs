using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// * NHÂN VẬT CÓ THỂ LÊN XUÔNG THỀM LINH HOẠT
public class FlatForm : MonoBehaviour {

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mario"))
        {
            // NẾU NGƯỜI CHƠI ẤN NÚT XUỐNG THÌ CHO XUỐNG
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                Invoke("ReStore",1.5f);
            }
        }
    }

    void ReStore()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
