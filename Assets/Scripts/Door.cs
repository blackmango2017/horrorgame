using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private string _name;
    public Transform link;

    public void Open() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            collision.transform.position = link.position;
        }
    }
}
