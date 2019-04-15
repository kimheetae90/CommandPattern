using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCommand : ICommand
{
    GameObject prefab = null;
    Character instance = null;

    public CreateCommand(string path)
    {
        prefab = Resources.Load(path) as GameObject;
    }

    public void Dispose()
    {
        prefab = null;
    }

    public void Execute()
    {
        GameObject go = GameObject.Instantiate(Resources.Load("Character") as GameObject) as GameObject;
        instance = go.GetComponent<Character>();
        BlockManager.Instance.Select(instance);
    }

    public void Undo()
    {
        instance.gameObject.SetActive(false);
    }

    public void Redo()
    {
        instance.gameObject.SetActive(true);
        BlockManager.Instance.Select(instance);
    }
}