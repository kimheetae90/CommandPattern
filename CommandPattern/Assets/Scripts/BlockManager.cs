using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance = new BlockManager();

    public Character SelectedCharacter { get; private set; }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreateCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveSelectCharacter(Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveSelectCharacter(Direction.Back);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveSelectCharacter(Direction.Right);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            MoveSelectCharacter(Direction.Front);
        }
    }
*/
    public Character CreateCharacter()
    {
        GameObject prefab = Instantiate(Resources.Load("Character") as GameObject) as GameObject;
        Select(prefab.GetComponent<Character>());
        return SelectedCharacter;
    }

    public void Select(Character character)
    {
        SelectedCharacter = character;
    }

    public void RemoveCharacter()
    {
        SelectedCharacter.gameObject.SetActive(false);
    }

    public void MoveSelectCharacter(Direction direction)
    {
        SelectedCharacter.Move(direction);
    }
}