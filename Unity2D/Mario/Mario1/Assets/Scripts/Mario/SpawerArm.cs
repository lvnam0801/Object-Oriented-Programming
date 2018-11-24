using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerArm : MonoBehaviour {
    [SerializeField]
    private GameObject Arm;

    // * TỰ SINH RA DẠN 
    public void Arms() {
        Instantiate(Arm, this.gameObject.transform.position, Quaternion.identity);
    }


}
