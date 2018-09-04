using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    NoDirection = 0,
    Right,
    Left,
    Up,
    Down
}
public class BoardField: MonoBehaviour {
    public Direction direction;
    
    void OnTriggerEnter(Collider other)
    {
        string _tag = other.tag;
        switch(_tag)
        {
            case "Start":
                this.tag = "StartField";
                break;
            case "Finish":
                gameObject.tag = "FinishField";
                break;
            case "Arrow":
                gameObject.tag = "ArrowField";
                break;
            case "Barrier":
                gameObject.tag = "BarrierField";
                break;
        }
        if(_tag=="Start" || _tag == "Arrow")
        {
            gameObject.transform.rotation = other.transform.rotation;
            float localRotation_y = gameObject.transform.localRotation.eulerAngles.y;
            if (localRotation_y >= 340 || localRotation_y <= 20)
                direction = Direction.Up;
            else if (localRotation_y >= 250 && localRotation_y <= 290)
                direction = Direction.Left;
            else if (localRotation_y >= 160 && localRotation_y <= 200)
                direction = Direction.Down;
            else if (localRotation_y >= 70 && localRotation_y <= 110)
                direction = Direction.Right;
        }
    }
    void OnTriggerExit(Collider other)
    {
        this.tag = "BoardField";
        direction = Direction.NoDirection;
    }
}
