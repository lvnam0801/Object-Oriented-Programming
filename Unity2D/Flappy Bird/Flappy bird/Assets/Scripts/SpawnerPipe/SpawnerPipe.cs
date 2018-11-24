using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    //Sinh ra đối tượng nào thì khai báo đối tượng đó
    [SerializeField]
    private GameObject pipeHolder;


    // ! BÀI 9_1: TỰ SINH RA PIPE_HODER
    // Use this for initialization
    void Start(){
        StartCoroutine(_Spawner()); //Gọi hàm có kiểu trả về là Coroutine
    }
    // IEnumerator: DELAY 1 KHOẢNG THỜI GIAN NÀO ĐÓ RỒI MỚI THỰC HIỆN (KHÁC HÀM UPDATE LÀ THỰC HIỆN MỘT CÁC LIÊN TỤC, HÀM FIXEDUPDATE THỰU HIỆN KHI CÓ SỰ KIÊN)
    // Hàm tự sinh thêm các pipeHolder
    IEnumerator _Spawner(){   
        //*LỆNH THỰC HIỆN DELAY TRONG 1S
        yield return new WaitForSeconds(1.1f); //Chờ trong khoảng 1 giây
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);         //hàm Random trong C#
        //*TẠO RA BẢN SAO CỦA MỘT ĐỐI TƯỢNG (ĐỐI TƯỢNG, VỊ TRÍ, XOAY HAY KHÔNG)
        Instantiate(pipeHolder, temp, Quaternion.identity); //identity: cố định -->Quaternion.indentity:Xoay cố định
        StartCoroutine(_Spawner());  //Gọi đệ quy hàm sinh ra object, vô hạn
    }
}
