using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Back,
    Left,
    Front,
    Right,
    Max,
}

public class Character : MonoBehaviour
{
    public void Move(Direction direction)
    {
        Vector3 moveVector;

        switch (direction)
        {
            case Direction.Back:
                moveVector = new Vector3(0, 0, -1);
                break;
            case Direction.Front:
                moveVector = new Vector3(0, 0, 1);
                break;
            case Direction.Left:
                moveVector = new Vector3(-1, 0, 0);
                break;
            case Direction.Right:
                moveVector = new Vector3(1, 0, 0);
                break;
            default:
                moveVector = new Vector3(0, 0, 0);
                break;
        }

        this.transform.Translate(moveVector);
    }
}