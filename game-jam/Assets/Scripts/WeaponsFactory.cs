using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsFactory : MonoBehaviour
{
    public class Gun : Weapon
    {
        public override float Hitpoints => 10.0f;
        public override float BulletSpeed => 1000.0f;
    }

    public class Melee : Weapon
    {
        public override float Hitpoints => 20.0f;
        public override float BulletSpeed => 1000.0f;
    }

    public class InvalidWeaponException : Exception
    {
    }

    private static IDictionary<string, System.Type> WeaponsByTags { get; } = new Dictionary<string, System.Type>();

    static WeaponsFactory()
    {
        WeaponsByTags.Add("bullet", typeof(Gun));
        WeaponsByTags.Add("melee", typeof(Melee));
    }

    public static Weapon GetByTag(string Tag)
    {
        if (WeaponsByTags.ContainsKey(Tag))
            return (Weapon)System.Activator.CreateInstance(WeaponsByTags[Tag]);
        else
            throw new InvalidWeaponException();
    }

    public static bool TagSupported(string Tag)
    {
        return WeaponsByTags.ContainsKey(Tag);
    }
}

public abstract class Weapon
{
    public abstract float Hitpoints { get; }
    public abstract float BulletSpeed { get; }


}