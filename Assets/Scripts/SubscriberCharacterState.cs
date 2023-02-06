public interface SubscriberCharacterState
{
    void Subscribe(PubCharacterState publisher);
    void Unsubscribe(PubCharacterState publisher);
}


