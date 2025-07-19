
using Game.Character.Stats;
using UnityEngine;

public interface IStateableHolder
{
}

public class CharacterStatsHolder : MonoBehaviour
{
    [SerializeField] CharacterStatLimited movemnt;

    public CharacterStat MovmentSpeed => movemnt;
}