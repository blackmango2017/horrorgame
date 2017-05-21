using UnityEngine;
using System.Collections;

public class Player2 :MonoBehaviour {
    
    public float speed = 3;

    protected Animator animator;
    protected SpriteRenderer sprite;
    private Vector2 direction;

    // NOTE: 컴퓨터에서 테스트 하기 위해 방향키로 조작하기 위해서는 false, 모바일에서 터치패드 이용 가능하게 하려면 true.
    public bool useTouchPad = false;

    void Start() {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (!useTouchPad) {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        /*플레이어 방향에 따라 캐릭터 회전*/

        if (direction.x > 0 && direction.y > 0) { //Right-Back
            sprite.flipX = true; //좌우 반전
            animator.SetFloat("DirectionX", 1.0f);
            animator.SetFloat("DirectionY", 1.0f);
        }
        else if (direction.x > 0 && direction.y < 0) { //Right-Front
            sprite.flipX = true; // 좌우반전
            animator.SetFloat("DirectionX", 1.0f);
            animator.SetFloat("DirectionY", -1.0f);
        }
        else if (direction.x < 0 && direction.y > 0) { //Left-Back
            sprite.flipX = false;
            animator.SetFloat("DirectionX", -1.0f);
            animator.SetFloat("DirectionY", 1.0f);
        }
        else if(direction.x < 0 && direction.y < 0) { //Left-Front
            sprite.flipX = false;
            animator.SetFloat("DirectionX", -1.0f);
            animator.SetFloat("DirectionY", -1.0f);
        }

        /*플레이어 애니메이션 처리*/
        if(direction.x != 0 || direction.y != 0) { //플레이어 캐릭터 이동중 
            animator.SetBool("Walking", true);
        }
        else {                                     //플레이어 캐릭터 대기중
            animator.SetBool("Walking", false);
        }

        transform.Translate(direction * Time.deltaTime);//플레이어 캐릭터 이동
    }

    public void setDirection(Vector2 dir)  {
        direction = dir;
    }

    public Vector2 getDirection() {
        return direction;
    }

    public Vector3 getPosition() {
        return transform.position;
    }
}
