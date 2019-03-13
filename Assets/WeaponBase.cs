using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public enum Faction { player, enemy, neutral };
    [SerializeField] Faction faction = Faction.player;

    public enum WeaponType { bullet, laser, bazooka };
    [SerializeField] WeaponType weaponType = WeaponType.laser;
    [SerializeField] int damage = 1;


    //public class WeaponInfo{
    //    Faction faction;
    //    WeaponType weaponType;
    //    int damage;

    //    WeaponInfo(Faction _faction, WeaponType _weaponType, int _damage) {
    //        faction = _faction;
    //        weaponType = _weaponType;
    //        damage = _damage;
    //    }
    //}

    //static WeaponInfo weaponInfo = new WeaponInfo(faction, weaponType, damage);

    public Faction GetFaction() {
        return faction;
    }

    public WeaponType GetWeaponType() {
        return weaponType;
    }

    public int GetDamage() {
        return damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        //WeaponInfo weaponInfo = new WeaponInfo(faction, weaponType, damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
