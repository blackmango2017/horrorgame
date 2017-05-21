using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorLock: MonoBehaviour {

    public Text tvPassword1;
    public Text tvPassword2;
    public Text tvPassword3;
    public Text tvPassword4;

    private int password;
    
    void Start () {
        tvPassword1.text = "*";
        tvPassword2.text = "*";
        tvPassword3.text = "*";
        tvPassword4.text = "*";
        password = 0;
    }
	
	void Update () {
        if (password == 1234) {
            Debug.Log("비밀번호 맞음");
            CloseDoorLckPopUp();
        }
        else if (password != 1234 && tvPassword4.text != "*") {
            Debug.Log("비밀번호 틀림");
            CloseDoorLckPopUp();
            //ToDo(부) 틀렸을 떄 패널티
        }
    }

    public void TouchPasswordButton(int num) {
        if(tvPassword1.text == "*") {
            tvPassword1.text = num.ToString();
            password += num * 1000;
        }
        else if(tvPassword2.text == "*") {
            tvPassword2.text = num.ToString();
            password += num * 100;
        }
        else if(tvPassword3.text == "*") {
            tvPassword3.text = num.ToString();
            password += num * 10;
        }
        else if(tvPassword4.text == "*") {
            tvPassword4.text = num.ToString();
            password += num;
        }
    }

    public void OpenDoorLockPopUp() {
        this.gameObject.SetActive(true);
    }
    
    public void CloseDoorLckPopUp() {
        this.gameObject.SetActive(false);
    }
}
