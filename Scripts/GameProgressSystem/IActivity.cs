


public interface IActivity
{
    void SubscribeForControl();
    void SetCompletedTask(string name);
    bool IsActivityCompleted();
}
