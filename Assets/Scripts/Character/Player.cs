using UnityEngine;
using System.Collections;

public enum PlayerState {
    IDLE,
    MOVE,
    ACTION,
    EVENT,
    LOADING,
    DIE,
}

public class Player : MonoBehaviour {

    private PlayerState _currentState = PlayerState.IDLE;

    private Transform _pivot;
    private Vector2 _direction = Vector2.zero;

    private BoxCollider2D _collision;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Inventory _inventory;

    private string _currentArea;

    public PlayerState currentState {
        get {
            return _currentState;
        }

        set {
            _currentState = value;
            //if (inventory.activeSelf)
            //    return;

            switch (_currentState) {
                case PlayerState.IDLE:
                    break;
                case PlayerState.MOVE:
                    StartCoroutine(IEMove());
                    break;
                case PlayerState.ACTION:
                    Explore();
                    break;
                case PlayerState.EVENT:
                    break;
                case PlayerState.DIE:
                    break;
            }
        }
    }

    public string currentArea {
        get {
            return _currentArea;
        }

        set {
            _currentArea = value;
        }
    }

    private void Start() {
        _pivot = transform.FindChild("Pivot");

        _collision = (BoxCollider2D)GetComponent(typeof(BoxCollider2D));

        _spriteRenderer = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        _animator = (Animator)GetComponent(typeof(Animator));
    }

    #region Move
    public void Move(Vector2 direction) {
        _direction = direction;
    }

    private IEnumerator IEMove() {
        _animator.SetInteger("State", (int)PlayerState.MOVE);

        while (_currentState == PlayerState.MOVE) {
            Vector3 startPosition = _pivot.position;        // 움직이는 시작 위치 (피벗 기준)
            Vector3 direction = _direction;                 // 캐릭터가 움직여야할 방향
            RaycastHit2D hitInfo = Physics2D.Linecast(startPosition, startPosition + direction.normalized, 1 << LayerMask.NameToLayer("FixedObject"));

            // 앞에 장애물이 있으면 움직이지 않는다.
            if (hitInfo.transform != null) {
                direction = Vector2.zero;
            }

            transform.Translate(direction * Time.deltaTime);

            if (_direction.x > 0) {
                _spriteRenderer.flipX = true;
            } else {
                _spriteRenderer.flipX = false;
            }

            _animator.SetFloat("DirectionX", Mathf.Clamp(_direction.x, -1.0f, 1.0f));
            _animator.SetFloat("DirectionY", Mathf.Clamp(_direction.y, -1.0f, 1.0f));

            yield return null;
        }

        _animator.SetInteger("State", (int)PlayerState.IDLE);
    }
    #endregion

    public void Explore() {
        _collision.enabled = false;
        _animator.SetInteger("State", (int)PlayerState.ACTION);

        Vector3 direction = _direction.normalized;
        RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, transform.position + direction, 1 << LayerMask.NameToLayer("FixedObject"));
        if (hitInfo.transform != null) {
            Item item = ((FixedObject)hitInfo.transform.GetComponent(typeof(FixedObject))).item;
            if (item != null && item.isEnable) {
                Item newItem = (Item)item.Clone();
                _inventory.Add(newItem);
                item.isEnable = false;
            }
        }

        _collision.enabled = true;
        _animator.SetInteger("State", (int)PlayerState.IDLE);
        _currentState = PlayerState.IDLE;
    }

    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    public void ChangeState(PlayerState state) {
        currentState = state;
    }

    public void SetInventory(Inventory inventory) {
        _inventory = inventory;
    }
}
