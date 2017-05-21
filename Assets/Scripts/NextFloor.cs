using UnityEngine;
using System.Collections;

public class NextFloor : MonoBehaviour {

    public bool up;
    public bool isEnable = true;

    public Transform link;

    private void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (!isEnable)
                return;

            if (up) {
                SceneController.instance.ChangeScene(Channel.C1);
            } else {
                SceneController.instance.ChangeScene(Channel.C2);
            }

            collision.gameObject.SendMessage("SetPosition", link.position);
            collision.gameObject.SendMessage("ChangeState", PlayerState.IDLE);
        }
    }
}
