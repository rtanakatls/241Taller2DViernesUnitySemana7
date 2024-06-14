using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static int starterDamage = 1;
    public static float starterShootDelay = 0.5f;
    public static int starterLife = 3;
    public static int damage;
    public static float shootDelay;
    public static int life;

    public static void Reset()
    {
        damage = starterDamage;
        shootDelay = starterShootDelay;
        life = starterLife;
    }
}
