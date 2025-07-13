using UnityEngine;


public interface IHorizontalMovment
{
    enum Direction { Left = -1, Right = 1}

    Direction CurrentDirection { get; }

    bool CanMove();
    void Stop();
    void Continue();
    void ChangeDirection(Direction direction);
}
public class CharacterMovment : MonoBehaviour, IHorizontalMovment
{
    [SerializeField] float normalSpeed;

    public float SpeedMultiplier { get; set; } = 1;

    public float Speed => normalSpeed * SpeedMultiplier;

    public IHorizontalMovment.Direction CurrentDirection { get; private set; }

    bool canMove;

    public bool CanMove() => canMove;
    public void ChangeDirection(IHorizontalMovment.Direction direction) => CurrentDirection = direction;

    public void Continue() => canMove = true;

    public void Stop() => canMove = false;

    private void Update()
    {
        if (canMove)
            transform.Translate((int)CurrentDirection * Speed * Time.deltaTime, 0, 0);
    }
}


public class Stat
{
    [SerializeField] float normalValue;
    [SerializeField] float normalMultiplier = 1;

}