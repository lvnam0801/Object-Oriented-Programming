using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// * XIII : ĂN VÀNG, LƯU ĐIỂM
public class GameMaster : MonoBehaviour
{ 
    // * XIII : TẠO BIẾN LƯU TRỮ ĐIỂM NGƯỜI CHƠI
    public int points = 0;
    public int hightScore = 0;

    // * XIII : BIẾN DISPLAY RA MÀN HÌNH GIÁ TRỊ CỦA TỪNG BIẾN
    public Text PointText;
    public Text HightText;
    public Text InputText;
    // Use this for initialization
    void Start()
    {
        // * XIII : HIỆN THỊ SỐ ĐIỂM CAO NHẤT CỦA NGƯỜI CHƠI
        HightText.text = ("HightScore : " + PlayerPrefs.GetInt("hightScore"));
        hightScore = PlayerPrefs.GetInt("hightScore", 0);
        // * XIII : LƯU LẠI ĐIỂM KHI ĐI QUA MÀN MỚI
        if (PlayerPrefs.HasKey("points"))                       //Nếu biến đã được khởi tạo -> địa chỉ của biến đã có giá trị
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            // * XIII : TRẢ VỀ GIÁ TRỊ 0 NẾU LÀ MÀN ĐẦU TIÊN
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");                // Xóa giá trị của địa chỉ points
                points = 0;                                      //Gán lại giá trị ban đầu cho người chơi bằng 0
            }
            //  XIII : GIỮ LẠI GIÁ TRỊ ĐIỂM NẾU KHÔNG PHẢI MÀN ĐẦU TIÊN
            else
                points = PlayerPrefs.GetInt("points");
        }
    }



    // Update is called once per frame
    void Update () {
        // * XIII : LIÊN TỤC CẬP NHẬT DISPAY VỚI SỐ ĐIỂM ĐANG CÓ
        PointText.text = ("Point : " + points);
	}
}
