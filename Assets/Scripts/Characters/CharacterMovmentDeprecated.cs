using UnityEngine;


public interface IHorizontalMovment
{
    enum Direction { Left = -1, Right = 1}

    Direction CurrentDirection { get; }
    bool CanMove { get;  }
    void Stop();
    void Continue();
    void ChangeDirection(Direction direction);
}
public class CharacterMovmentDeprecated : MonoBehaviour, IHorizontalMovment
{
    [SerializeField] float normalSpeed;

    public float SpeedMultiplier { get; set; } = 1;

    public float Speed => normalSpeed * SpeedMultiplier;

    public IHorizontalMovment.Direction CurrentDirection { get; private set; }

    public bool CanMove { get; private set; }
    public void ChangeDirection(IHorizontalMovment.Direction direction) => CurrentDirection = direction;

    public void Continue() => CanMove = true;

    public void Stop() => CanMove = false;

    private void Update()
    {
        if (CanMove)
            transform.Translate((int)CurrentDirection * Speed * Time.deltaTime, 0, 0);
    }

}