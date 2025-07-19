using UnityEngine;


public interface IEquipable<T> where T : class
{
    public T CurrentEquipItem { get; }
    public void Equip(T weapon);
    public T UnEquip();
}
public class CharacterHand: IEquipable<Weapon>
{
    public Weapon CurrentEquipItem { get; private set; }

    public void Equip(Weapon weapon)
    {
        CurrentEquipItem = weapon;
    }
    Weapon IEquipable<Weapon>.UnEquip()
    {
        var aux = CurrentEquipItem;
        CurrentEquipItem = null;
        return aux;
    }
}


public class Weapon
{
    public enum AttackForm : byte { Melee, Ranged, Magic }
    public enum AttackTarget : byte { Enemies, Allies, Both }

}
