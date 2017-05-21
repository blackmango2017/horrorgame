using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour {

    private Player _player;

    private void Start() {
        _player = (Player)(GameObject.Find("Player").GetComponent(typeof(Player)));
    }

    public void OnButtonDown() {
        if (_player.currentState == PlayerState.IDLE) {
            _player.currentState = PlayerState.ACTION;
        }
    }
}
