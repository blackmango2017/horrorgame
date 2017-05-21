using UnityEngine;
using System.Collections;

public class TouchPad :MonoBehaviour {
    public UIManager uiManager;

    private enum Direction {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }
    private Direction direction = Direction.NONE;

    public Player player;
    private Vector2 vector;

    void Update() {
        //if (player.useTouchPad) {
        //    if (direction == Direction.NONE) {
        //        return;
        //    }

        //    for (int i = 0; i < Input.touchCount; i++) {
        //        switch (Input.GetTouch(0).phase) {
        //            case TouchPhase.Began:
        //            case TouchPhase.Stationary:
        //                switch (direction) {
        //                    case Direction.UP:
        //                        vector = new Vector2(0, 1);
        //                        break;
        //                    case Direction.DOWN:
        //                        vector = new Vector2(0, -1);
        //                        break;
        //                    case Direction.LEFT:
        //                        vector = new Vector2(-1, 0);
        //                        break;
        //                    case Direction.RIGHT:
        //                        vector = new Vector2(1, 0);
        //                        break;
        //                    case Direction.NONE:
        //                    default:
        //                        break;
        //                }
        //               //  player.updatePlayer(vector, true);
        //                break;
        //            case TouchPhase.Ended:
        //                if (direction != Direction.NONE) {
        //                    direction = Direction.NONE;
        //                    // player.updatePlayer(vector, false);
        //                }
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //}
    }

    public void clickTouchPad(int direction) {
        switch (direction) {
            case 0:
                this.direction = Direction.UP;
                break;
            case 1:
                this.direction = Direction.DOWN;
                break;
            case 2:
                this.direction = Direction.LEFT;
                break;
            case 3:
                this.direction = Direction.RIGHT;
                break;
        }
    }
}