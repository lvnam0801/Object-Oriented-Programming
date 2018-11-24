using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              // * THAY ĐỔI MÀN CỦA NGƯỜI CHƠI, VỀ LẠI MÀN CHƠI ĐANG ĐỨNG

public class PauseMenu : MonoBehaviour {
    // * VII : NHẬN BIẾT NẾU NGƯỜI CHƠI ẤN ESCAPE
    public bool pause = false, start = true;
    // * VII : TẠO ĐỐI TƯỢNG MUỐN DỪNG (thực chất là cho hiện lên menu hay không) thuộc cavans
    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject buttonControl;
    public bool pauseButton = false;
    public bool pauseTime = false;
    public SoundSManeger sounds;
    // Use this for initialization
    void Start () {
        // * VII : KHI MỚI VÀO GAME CHƯA CHO MENU PAUSE HIỆN LÊN
        pauseMenu.SetActive(false);
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
	}
 
    // * PAUSE BẰNG BUTTON
	
    // Update is called once per frame
	void Update () {
        // * VII : KHI CÓ INNPUT LÀ ESCAPE THỰC HIỆN THAY ĐỔI GIÁ TRỊ PAUSE
        if (pauseButton)
        {
            pause = !pause;
            pauseButton = false;
            sounds.PlaySound("pause");

        }
        if (pause || start)                                      // Hàm dừng màn hình nếu pause = true
        {
            // * ẨN ĐI BUTTON CONTROL
            buttonControl.SetActive(false);
            // * HIỆN THỊ PUASE MENU
            if (pause) pauseMenu.SetActive(true);
            // * HIỆN THỊ START MENU
            else startMenu.SetActive(true);

            Time.timeScale = 0;
            sounds.audioSource.Pause();
        }
        else                           // Mở màn hình lại nếu người chơi ấn escape một lần nữa
        {
            // * HIỆN THỊ BUTTON CONTROL
            if (pauseTime)
            {
                buttonControl.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                buttonControl.SetActive(true);
                Time.timeScale = 1;
               
            }
            // * ẨN PAUSEMENU VÀ STARTMENU
            pauseMenu.SetActive(false);
            startMenu.SetActive(false);
            
        }
	}
    public void PauseButton()
    {
        pauseButton = true;
    }
    //* HÀM THỰC HIỆN GÁN GIÁ TRỊ CHO CÁC NÚT BOTTON CỦA PAUSEMENU
    public void Resume()                                // Nếu vào thì người chơi sẽ chơi tiếp (vì pause trước đố bằng true) -> quay lại hàm update
    {
        pause = false;
        sounds.audioSource.Play();
    }
    public void Restart()                                // Thực hiện lệnh load lại màn chơi nếu ngươi chơi chon botton này
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // *    THOÁT RA MÀN HÌNH MENU CHÍNH
    public void Quit()                                    
    {
        Application.Quit();
    }

    // * HÀM THỰC HIỆN GÁN GIÁ TRỊ ĐỂ THỰC THI 

    public void StartGame()
    {
        start = false;
        sounds.PlaySound("background");
    }
    // * ! YÊU CẦU UPDATE THÊM HÀM CHỌN LEVEL
}
