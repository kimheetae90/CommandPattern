using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCommand : ICommand
{
    private Character character = null;

    public RemoveCommand(Character character)
    {
        this.character = character;
    }

    public void Dispose()
    {
        character = null;
    }

    public void Execute()
    {
        character.gameObject.SetActive(false);
    }

    public void Undo()
    {
        character.gameObject.SetActive(true);
    }

    public void Redo()
    {
        character.gameObject.SetActive(false);
    }
}