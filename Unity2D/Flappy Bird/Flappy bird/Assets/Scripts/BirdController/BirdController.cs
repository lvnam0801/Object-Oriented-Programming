using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    // ! BÀI 11_3 : TẠO BIẾN DÙNG ĐỂ ĐỒNG BỘ HÓA CÁC BIẾN VÀ CÁC SCRIP VỚI NHAU
    public static BirdController instance;   //tạo biến để tryt cập lớp với các biến và các hàm public


    //! I: TẠO HÀM ADD VẬN TỐC TRONG RIGIDBODY CỦA OBJECT
    public float bounceForce; //Biến lưu trữ giá trị cần dùng để thay đổi vận tốc theo chiều y của đối tượng
    private Rigidbody2D myBody; //Đại lượng vật lý (Lực) thuộc component Rigidbody2D
    private Animator anim; //hoạt hình
    
    //! BÀI 6_2: TẠO BIẾN ÂM THANH ĐỂ XUẤT ÂM THANH TRONG CÁ HÀM
    [SerializeField] //Cho phép Private hiện lên màn hình
    private AudioSource audioSource;
    [SerializeField] //Cho phép thuộc tính Private hiện ra màn hình
    private AudioClip flyClip, pingClip, diedClip, backgoundMusic;
    
    // ! BÀI 7_1: TẠO BUTTON NHẬN INPUT ĐỂ THỰC HIỆN SỰ KIỆN
    private bool isAlive;       //vẫn còn sống(tồn tại), mặc định khi khao báo là giá trị false
    private bool didFlap;       //Flap Bird die

    // ! BÀI 11_1: TẠO MỘT BIẾN CỜ ĐỂ NHẬN BIẾT 
    public float flag = 0;      //Flag : một cái cờ

    // ! BÀI 11_6: TẠO MỘT BIẾN ĐỂ XÓA GAMEOBJEC
    private GameObject spawner;

    public BirdController()
    {
    }


    //* HÀM KHỞI TẠO CÁC GIÁ TRỊ ĐẦU GAME
    void Awake () {
        //Khởi tạo cho Bird còn sống
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    // ! BÀI 11_5: GỌI HÀM MakeInstace ĐỂ KHỞI TẠO GIÁ TRỊ CHO BIẾN
        _MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }
    // ! BÀI 11_4: GẮN GIÁ TRỊ LỚP CHO BIẾN INSTANCE 
    void _MakeInstance(){
        if(instance == null)    instance = this;
    } 
    
    //HÀM ĐƯỢC GỌI KHI TRUYỀN HOẶC THAY ĐỔI CÁC ĐẠI LƯỢNG VẬT LÝ, CÓ SỰ KIỆN (thay đổi các farme của object mà không có tính đều đặn, thường thực hiện khi có sự kiện, update giá trị vật lý)
    void FixedUpdate() {        // Có thể chạy 1 hoặc 0 hoặc một vài lần trên khung hình tùy vào tỉ lệ của các đại lượng vật lý 
        _BirdMoveMent();
	}
    // ! BÀI 7_3: BIRD NHẬN INPUT TỪ BUTTON TỰ TẠO (HOẶC TỪ BÀN PHÍM ĐÃ LÀM Ở BÀI 5)
    //HÀM THỰC HIỆN CÁC SỰ KIỆN CỦA OBJECT
    void _BirdMoveMent() {
        //Khi Bird còn sống và nhận được input từ button thì sẽ thực hiện truyền vận tốc
        if (isAlive) {
            if (didFlap){
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
    // ! BÀI 6_1: GIÚP BIRD XOAY LÊN, XUỐNG PHÙ HỢP
        //Xoay object theo trục z (update giá trị của rolation(z)) khi Bird có vận tốc
        if(myBody.velocity.y > 0) {
            float angel = 0;
            //angel : Góc xoay(tính nội suy theo vận tốc)
            angel = Mathf.Lerp(0, 80, myBody.velocity.y/7);             //Hàm toán nội suy
            transform.rotation = Quaternion.Euler(0, 0, angel);         //Gán giá trị góc vào trong rolation
        }
        
        //Cho object không xoay nếu nó vận tốc = 0
        else if (myBody.velocity.y == 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        //Cho object xoay xuống nếu vận tốc bé hơn 0
        else {  
            float angel = 0;
            angel = Mathf.Lerp(0, -80, -myBody.velocity.y / 7);         //hàm toán nội suy từ 0->-90 tính theo vận tốc (angel)
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    // ! BÀI 7_2: TẠO HÀM ĐỂ NHẬN IPPUT TỪ BUTTON "UT"
    //* ĐƯỢC OBJECT BUTTON ĐỂ GỌI NẾU CLICK VÀO BUTTON 
    public void FlapButton()
    {
        didFlap = true;
    }
    // ! BÀI 6_3: ADD ÂM THANH VÀO KHI CÓ SỰ VA CHẠM
     //*HÀM BẮT VA CHẠM VÀ THỰC HIỆN ÂM THANH (1 TRONG 2 ĐƯỢC CHECK ITRIGGER) 
    void OnTriggerEnter2D(Collider2D target){   //sử dụng conlider2D
        if (target.tag == "PipeHolder"){
            audioSource.PlayOneShot(pingClip);
        }
    }
    
    // ! BÀI 10: VA CHẠM VỚI NỀN ĐẤT HOẶC PIPE THÌ THỰC HIỆN ANIMATION "DIED" + AUDIO "dieClip"(ÂM THANH DIED)
    // *HÀM BẮT VA CHẠM VỚI NỀN ĐẤT (GROUND) (2 không được check itrigger)
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground"){
            
            flag = 1f;            // ! BÀI 11_2: NHẬN BIẾT KHI NÀO VA CHẠM VÀ GẮN CỜ
            Destroy(spawner);
            myBody.gravityScale = 0;
            myBody.velocity = new Vector2(myBody.velocity.x, 0); 

            audioSource.PlayOneShot (diedClip);
            anim.SetTrigger("Died");
        }
    
    }


}
