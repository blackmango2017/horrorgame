using UnityEngine;

public class Joystick : MonoBehaviour {
    public bool touch = false;

    private Transform _stick;

    private Vector2 _startPosition;
    private float _radius;
    public float sensitivity = 0.07f;       // 스틱 민감도

    private Player _player;

    // Use this for initialization
    void Start () {
        _stick = transform.FindChild("Ball");

        _startPosition = _stick.position;
        _radius = _stick.GetComponent<RectTransform>().sizeDelta.x / 2;     // 스틱의 최대 반경.

        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnBeginDrag() {
        _player.currentState = PlayerState.MOVE;
    }

    public void OnDrag() {
        Vector2 pos = Vector2.zero;
        if (!touch) {
            pos = Input.mousePosition;
        } else {
            pos = Input.GetTouch(0).position;
        }
         
        // pos = Input.GetTouch(0).position;

        float delta = Vector2.Distance(pos, _startPosition);     // 스틱이 중심에서 멀어진 거리.

        delta = delta > _radius ? _radius : delta;                // 스틱이 최대 반경을 넘어가지 않게 한다.
        Vector2 dir = (pos - _startPosition).normalized * delta;

        _stick.position = _startPosition + dir;           // 스틱 이동.

        // 캐릭터를 이동시킨다.
        _player.Move(dir * sensitivity);
    }

    public void OnEndDrag() {
        _stick.position = _startPosition;
        _player.currentState = PlayerState.IDLE;
    }
}
