public interface ICommand
{
    void Execute();
    void Undo();
    void Dispose();
    void Redo();
}