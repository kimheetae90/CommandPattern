using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Direction direction;
    private Character character;

    public MoveCommand(Direction direction, Character character)
    {
        this.direction = direction;
        this.character = character;
    }

    public void Dispose()
    {
        character = null;
    }

    public void Execute()
    {
        character.Move(direction);
    }

    public void Undo()
    {
        int opposition = ((int)direction + 2) % (int)Direction.Max;
        character.Move((Direction)opposition);
    }

    public void Redo()
    {
        character.Move(direction);
    }
}