using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandStack;
    private Stack<ICommand> undoStack;

    private ICommand reservedCommand;

    void Start()
    {
        commandStack = new Stack<ICommand>();
        undoStack = new Stack<ICommand>();
    }

    ICommand CreateCreateCommand(string path)
    {
        ICommand newCommand = new CreateCommand(path);
        ExecuteCommand(newCommand);
        return newCommand;
    }

    ICommand CreateRemoveCommand()
    {
        ICommand newCommand = new RemoveCommand(BlockManager.Instance.SelectedCharacter);
        ExecuteCommand(newCommand);
        return newCommand;
    }

    ICommand CreateMoveCommand(Direction direction)
    {
        ICommand newCommand = new MoveCommand(direction, BlockManager.Instance.SelectedCharacter);
        ExecuteCommand(newCommand);
        return newCommand;
    }

    void ExecuteCommand(ICommand command)
    {
        commandStack.Push(command);
        reservedCommand = command;
        ClearUnDoStack();
    }

    void UnDo()
    {
        if (commandStack.Count <= 0)
            return;

        ICommand undoCommand = commandStack.Pop();
        undoCommand.Undo();
        undoStack.Push(undoCommand);
    }

    void ReDo()
    {
        if (undoStack.Count <= 0)
            return;

        ICommand redoCommand = undoStack.Pop();
        redoCommand.Redo();
        commandStack.Push(redoCommand);
    }

    void ClearUnDoStack()
    {
        if (undoStack.Count > 0)
        {
            undoStack.Clear();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) CreateCreateCommand("Character");
        else if (Input.GetKeyDown(KeyCode.K)) CreateRemoveCommand();
        else if (Input.GetKeyDown(KeyCode.A)) CreateMoveCommand(Direction.Left);
        else if (Input.GetKeyDown(KeyCode.S)) CreateMoveCommand(Direction.Back);
        else if (Input.GetKeyDown(KeyCode.D)) CreateMoveCommand(Direction.Right);
        else if (Input.GetKeyDown(KeyCode.W)) CreateMoveCommand(Direction.Front);
        else if (Input.GetKeyDown(KeyCode.N)) UnDo();
        else if (Input.GetKeyDown(KeyCode.M)) ReDo();

        if (reservedCommand != null)
        {
            reservedCommand.Execute();
            reservedCommand = null;
        }

    }
}