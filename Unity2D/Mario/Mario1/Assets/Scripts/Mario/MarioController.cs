using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioController : MonoBehaviour {
    // ! II_1 : TẠO BIẾN TRUYỀN VẬN TỐC GIÚP NHÂN VẬT DI CHUYỂN TRÁI PHẢI, jumPow : NHÂN VẬT CÓ THỂ NHẢY LÊN
    public float speed = 80f, maxSpeedX = 3, jumpPow = 220f,  maxSpeddY = 4;
    
    // ! II_2 : TẠO BIẾN KIỂM TRA NHÂN VẬT QUAY BÊN NÀO ĐỂ THỰC HIỆN XOAY
    public bool faceright = true;
    
    // ! III : KIỂM TRA NHÂN VẬT CÓ NẰM Ở TRÊN MẶT ĐẤT HAY KHÔNG, DOUBLEJUMP GIÚP NHÂN VẬT NHẢY 2 LẦN LIÊN TIẾP
    public bool grounded = true, doubleJump = false;
   
    
    // * VIII : TẠO HỆ THỐNG MẠNG SỐNG VÀ POWER CHO NHÂN VẬT VÀ SỐ MẠNG SÔNG TỐI ĐA CHO NHÂN VẬT (ĐƯỢC LỚP numOfLife truy cập đến)
    public int numOfLife = 1;

    // * XIII: TÍNH ĐIỂM NHÂN VẬT (ĐỐI TƯỢNG QUẢN LÝ THÔNG SỐ TIỀN TRONG GAME)
    public GameMaster gameMaster;
    // * XV :   KHỜI TẠO ÂM THANH CHO GAME
    public SoundSManeger sounds;

    // *** TẠO BIẾN ĐỐI TƯỢNG ĐỂ KIỂM SOÁT VẬN TỐC, TRẠNG THÁI CỦA NHÂN VẬT
    public Rigidbody2D r2;
    // *** TẠO BIẾN ANIMATOR ĐỂ KIỂM SOÁT CÁC HOẠT ẢNH CHO PHÙ HỢP VỚI TỪNG TRẠNG THÁI
    public Animator anim;
    
    // * NHẬN GIÁ TRị INPUT
    private float h = 0;
    public bool jump = false;
    // * TRUY CẬP ĐỐI TƯỢNG RESTART ĐỂ BẮT ĐẦU LẠI GAME
    public PauseMenu pauseMenu;                     //  Truy cập biến để dừng màn hình lại
    // * HIỆN THỊ BUTTON RESTART ĐỂ BẮT ĐẦU GAME
    public GameObject Restart;
    public bool playSounds = false;
    
    
    
    // *** KHỞI TẠO GIÁ TRỊ BAN ĐẦU CHO CÁC THÔNG SỐ
    private void Awake()
    {
        numOfLife = 4;                                              //Khởi tạo số mạng ban đầu cho nhân vật là 4
    }
    // *** KHỞI TẠO GIÁ TRỊ BAN ĐẦU CHO CÁC ĐẠI LƯỢNG VẬT LÝ

    void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();                //Khởi tạo giá trị cho biến đối tượng Rigidbody2D
        anim = gameObject.GetComponent<Animator>();                 //Khởi tạo giá trị cho biến đối tượng animator
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponentInParent<GameMaster>();         // Tham chiếu đền đối tượng GameMaster
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
        pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PauseMenu>();

    }
	
	// *** UPDATE TRẠNG THÁI MỘT CÁCH ĐỀU ĐẶN VÀ LIÊN TỤC 
	void FixedUpdate () {
        
        // * II_3 : THỰC HIỆN CÁC ANIMATION CHO PHÙ HỢP VỚI TRẠNG THÁI CỦA NHÂN VẬT (dựa vào các biến điều kiện đã tạo trong animator)
        anim.SetBool("Grounded", grounded);                         //Lấy giá trị biến grounded cập nhật cho biến Ground của animator
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));           //Gán giá ABS(của vận tốc đối tượng) cho biến speed của animator
        
        // * II_1 : LÀM CHO NHÂN VẬT NHẢY LÊN
        if (jump)                        //Khi nhận input là nút space
        {
            if (grounded)                                           //Kiể tra giá trị của biến grounded (có ở trên mặt đất hay không)
            {
                r2.AddForce(Vector2.up * jumpPow);                  // Truyền lực theo hướng UP để đối tượng nhảy lên
                grounded = false;                                   //Đang không ở trên mặt đất nên grounded = false
                doubleJump = true;                                  //Xác nhận đã jump lần 1 
                sounds.PlaySound("jumpSmall");                       //Âm thanh nhảy
            }
           
            // * II_1 : KHI NHẬN SPACE LẦN THỨ 2 KIỂN TRA NẾU VẪN ĐANG Ở TRÊN KHÔNG (ground == false) và double vẫn chưa được thực hiện thì thực hiện double => chỉ được nhảy tối đa 2 lần            
            else if (doubleJump)                                       
            {
                StartCoroutine(DoubleJump());
            }
            
        }
	}
    // CHƯA SỬA ĐƯƠC LỖI
    // ! * FIX LỖI DOUBLEJUM
 
    public IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(0.3f);
        if (doubleJump && jump)
        {
            doubleJump = false;
            r2.velocity = new Vector2(r2.velocity.x, 0);
            r2.AddForce(Vector2.up * jumpPow * 1.8f);
            sounds.PlaySound("jumpSmall");
        }
        
    }
    // * XXIII: JUMP CHO MARIO
    public void Jump(bool ButtonJump)
    {
        jump = ButtonJump;
    }

    // * XXIII : BUTTON CHO PHONE
    public void Move(float ButtonInput)
    {
        h = ButtonInput;
    }




    // *** UPDATE TRẠNG THÁI LIÊN TỤC, KHI CÓ SỰ KIỆN XẢY RA, HÀM THAY ĐỔI CÁC ĐẠI LƯỢNG VẬT LÝ 7/(lặp đi lặp lại mỗi 0.2s)
    void Update()
    {
        // * XXIII : NHẬN INPUT TỪ BUTTON
        Move(h);


        // * II_1 : TẠO MỘT BIẾN NHẬN INPUT TỪ HORIONTOL (<- : -1 và -> : 1)
        //h = Input.GetAxis("Horizontal");                                      //Input là 2 nút mũi tên thực hiện truyền vận tốc cho Rigidbody2D

        // * II_1 : TRUYỀN MỘT LỰC THEO HƯỚNG NGANG (1, 0) OR (-1, 0) NHÂN VẬT 
        r2.AddForce((Vector2.right) * speed * h);                                   // Vector2.ringht có nghĩa là vector(1, 0) chỉ bị tác động theo chiều ngang

        // * II_1: GIỚI HẠN VẬN TỐC CHO NHÂN VẬT <TRÁNH TRƯỜNG HỢP BỊ TĂNG TỐC LIÊN TỤC>
        if (r2.velocity.x > maxSpeedX)                                                //Giới hạn vận tốc theo chiều bên phải
        {
            r2.velocity = new Vector2(maxSpeedX, r2.velocity.y);
        }
        if (r2.velocity.x < -maxSpeedX)                                                 //Giới hạn vận tốc theo chiều trái   
        {
            r2.velocity = new Vector2(-maxSpeedX, r2.velocity.y);                             
        }
            //*GIỚI HẠN VẬN TỐC Y       
        if(r2.velocity.y > maxSpeddY)                                                  //Giới hạn vận tốc theo chiều lên             
        {
            r2.velocity = new Vector2(r2.velocity.x, maxSpeddY);                    
        }
        if (r2.velocity.y < -maxSpeddY)
        {
            r2.velocity = new Vector2(r2.velocity.x, -maxSpeddY);                       //Giới hạn vận tốc theo chiều xuống
        }
        
        
     // * II_2 : HIỆU CHỈNH XOAY NHÂN VẬT
        if(h > 0 && !faceright)                                                   //Nếu nhân vật đang đi bên phải và mặt quay sang trái thì thực hiện xoay đối tượng
        {
            Flip();
        }
        if (h < 0 && faceright)                                                   //Nếu nhân vật đang đi sang trái và mặt quay sang phải thì thực hiện xoay nhân vật   
        {
            Flip();
        }
        

        // * IV: TẠO MA SÁT ẢO CHO NHÂN VẬT (KHI ĐANG Ở TRÊN MẶT ĐẤT)
        if (grounded)                                                              
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);     //Giảm dần vận tốc cho nhân vật(ma sát ảo) theo chiều ngang
        }


        if(numOfLife <= 0)
        { 
           
            Death();
        }
    }

    // * II_2 : HÀM XOAY NHÂN VẬT
    public void Flip()                                                             //Hàm thực hiện xoay nhân vật bằng cách phủ đinh scale
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void Death()                                                                 //Khi nhân vật hết mạng chơi thì thực hiện hàm
    {
        // * HIỆN THỊ DÒNG CHỮ GAME OVER
        gameMaster.InputText.text = ("--GAME OVER--\nPRESS BUTTON TO RESTAR");
        pauseMenu.buttonControl.SetActive(false);            
        if (playSounds == false)
        {
            sounds.audioSource.Stop();                                                      //  Dừng âm thanh lại     
            sounds.PlaySound("gameOver");
            sounds.audioSource.Play();
            playSounds = true;
        }
        StartCoroutine(Delay());
        // * XIII : LƯU LẠI GIÁ TRỊ CAO NHẤT TRONG SÓ ĐIỂM KHI CHẾT
        {
            if (PlayerPrefs.GetInt("hightScore") < gameMaster.points)
                PlayerPrefs.SetInt("hightScore", gameMaster.points);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        pauseMenu.pauseTime = true;                                                     // Dừng màn hình game lại
        Restart.SetActive(true);                                                         // HIỆN THỊ BUTTON ĐỂ RESTART
    }


    // * IX : NHẬN SÁT THƯƠNG TỪ MONSTER (ĐƯỢC GỌI TRONG LỚP MONSTER)
    public void Damage(int damage)
    {
        numOfLife -= damage;
        anim.SetBool("Blink", true);
    }
    // * IX : ĐẨY LÙI VA CHẠM VỚI MONSTER
    public void Knocback(float h)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(Vector2.right*speed*h);
    }

    // * IX : TẠO HIỆU ỨNG NHẢY KHI GẶP MONSTER
    public void KnocUp(float h)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(Vector2.up * jumpPow * h);
    }


    // * XIII : TĂNG ĐIỂM (COINS) NẾU NGƯỜI CHƠI ĂN TIỀN
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            sounds.PlaySound("coins");
            Destroy(collision.gameObject);
            gameMaster.points++;
        }
    }

}
