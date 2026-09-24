
/// <summary>
/// Defines the common interface for game activity systems, including progress control, task completion, and completion state.
/// </summary>

public interface IActivity
{
    void SubscribeForControl();
    void SetCompletedTask(string name);
    bool IsActivityCompleted();
}
