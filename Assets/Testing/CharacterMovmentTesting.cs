using UnityEngine;

public class CharacterMovmentTesting : MonoBehaviour
{
    public CharacterMovmentDeprecated test;
    public IHorizontalMovment.Direction movmentDirection;
    public float speedMultiplier = 1;

    public KeyCode keyToStop = KeyCode.P;
    public KeyCode keyToContinue = KeyCode.R;

    private void Update()
    {
        test.ChangeDirection(movmentDirection);
        test.SpeedMultiplier = speedMultiplier;

        if (Input.GetKeyDown(keyToStop))
            test.Stop();

        if(Input.GetKeyDown(keyToContinue))
            test.Continue();
    }

}
