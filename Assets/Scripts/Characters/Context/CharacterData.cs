using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "CharacterData", order = 0)]
public class CharacterData : ScriptableObject
{

    [Header("Movment")]
    [SerializeField] float movmentSpeed;

    public float MovmentSpeed => movmentSpeed;

}
