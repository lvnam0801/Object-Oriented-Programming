using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// * XIV : CHUYỂN SANG LEVEL MỚI ĐỒNG THỜI LƯU LẠI SỐ ĐIỂM Ở LAVEL CŨ 
public class Door : MonoBehaviour
{

    // * XIV : BIẾN CHỌN LEVEL TIẾP THEO
    public int Leveload = 1;                // Chọn màn chơi
    public GameMaster gameMaster;           // Tham chiếu đến lớp GamsMaser
    public GameObject Start_Door;
    public GameObject buttonControl;
    // * TẠO BIẾN PAUSE MENU ĐỂ CÁC LỚP KHÁC TRUY CẬP ĐẾN : MARIOCONTROLL, DOOR
    public PauseMenu pauseMenu;
    // Use this for initialization
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PauseMenu>();

    }
    // * XIV : NẾU MỚI GẶP NHÂN VẬT->HIỆN THỊ HƯỚNG DẪN
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {

            saveCore();
            pauseMenu.pauseTime = true;
            gameMaster.InputText.text = ("--YOU WIN--\nPRESS BUTTON TO RESTAR");
            Start_Door.SetActive(true);


        }

    }
    // * XIV : LOAD LEVEL KẾ TIẾP NẾU NGƯỜI CHƠI ĐỒNG Ý
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            if (Input.GetKey(KeyCode.N))
            {
                Start_Door.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    // * XIV : XÓA INPUTTEXT ĐỂ NGƯỜI CHƠI TIẾP TỤC
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            gameMaster.InputText.text = ("");
            pauseMenu.pauseTime = false;                        // Trả lại trạng thái bình thường cho pause menu
        }
    }
    // * XIII : CẬP NHẬT SỐ ĐIỂM CỦA NHÂN VẬT GIỮ LẠI VÀO MÀN CHƠI KẾ TIẾP
    void saveCore()
    {
        PlayerPrefs.SetInt("points", gameMaster.points);
    }
}
