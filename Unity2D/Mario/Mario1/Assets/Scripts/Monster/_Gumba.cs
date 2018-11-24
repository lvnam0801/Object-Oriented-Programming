using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Gumba : MonoBehaviour {
    // * X : NHẬN BIẾT VA CHẠM VÀ GÂY SÁT THƯƠNG
    public MarioController Mario;
    private bool collide = false;                                 //Tạo biến nhận biết đã va chạm với monster
    private BoxCollider2D myCollider;                           //Tham chiếu conlider để nhân vật có thể nhấp nháy khong bị sát thương

    // * X : ĐƯA NHÂN GUMBA DI CHUYỂN ĐƯỢC
    public Rigidbody2D myBody;
    public float  maxSpeed;
    private float speed = 0, changedDirection = -1;
    public float powUp;

    // * X : TẠO HIỆU ỨNG KHI CHẾT
    public Animator anim;

    // * XV : TẠO ÂM THANH CHO PAUSE
    public SoundSManeger sounds;
    // * KHỞI TẠO GIÁ TRỊ BAN ĐẦU CHO CÁC BIẾN
    // Use this for initialization
    void Start () {
        Mario = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>();
        myCollider = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundSManeger>();
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x - Mario.transform.position.x <= 15)
        {
            speed = 50f;
        }
        // ! CHƯA LÀM ĐƯỢC
        // * X : TẠO HIỆU ỨNG NHẤP NHÁY VÀ CHO NHÂN VẬT KHÔNG CHẾT
        if (collide)
        {
            collide = false;
            StartCoroutine(Collide());
        }
    }

    // * X : UPDATE GIÁ TRỊ VẬN TỐC 
    private void FixedUpdate()
    {
        if (Mario.playSounds)
        {
            speed = 0;
        }
        myBody.AddForce((Vector2.right) * speed * changedDirection);

        if(myBody.velocity.x > maxSpeed)
        {
            myBody.velocity = new Vector2(maxSpeed, myBody.velocity.y);
        }
        if(myBody.velocity.x < -maxSpeed)
        {
            myBody.velocity = new Vector2(-maxSpeed, myBody.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // * X : NẾU GẶP NHÂN VẬT THÌ GÂY SÁT THƯƠNG
        if (collision.collider.CompareTag("Mario"))
        {
            Mario.Damage(1);                                                //Gây sát thương cho nhân vật (-1 numOfLife của lớp MarioController)
            Mario.Knocback(-50f);                                             //Đẩy lùi nhân vật để tránh gây sát thương liên tục
            Mario.anim.SetBool("Blink", true);
            collide = true;
        }
        // * X : NHẬN BIẾT VA CHẠM VỚI ỐNG NƯỚC THÌ ĐẢO CHIỀU
        if (collision.collider.CompareTag("Barrier") || collision.collider.CompareTag("monster"))
        {
            changedDirection = -changedDirection;
        }
        // * X : GẶP ARM THÌ DESTROY THIS GAMEOBJECT
        if (collision.collider.CompareTag("Arm"))
        {
            sounds.PlaySound("destroy");
            Destroy(gameObject);
        }
    }
    // * X : DELAY TIME NẾU NHÂN VẬT ĐANG NHẤP NHÁY
    IEnumerator Collide()
    {
        yield return new WaitForSeconds(3);
        Mario.anim.SetBool("Blink", false);
    }
    // * X : BỊ MARIO ĐẠP LÊN THÌ CHẾT
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mario")
        {
            sounds.PlaySound("bump");
            anim.SetBool("Died", true);
            Mario.KnocUp(0.7f);
            myBody.velocity = new Vector2(0, 0);
            myBody.AddForce(Vector2.up * powUp*0.5f);
            myCollider.isTrigger = true;
        }
    }
}
