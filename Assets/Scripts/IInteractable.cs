public interface IInteractable
{
    public string Text { get; }
    
    public void Interact();
    public void Focus() { }
    public void UnFocus() { }
}