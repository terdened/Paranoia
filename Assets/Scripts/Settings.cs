using UnityEngine;
using System.Collections;

public enum StateCode
{
    Normal = 1,
    ClassA = 2,
    ClassB = 3,
    ClassC = 4
}

public static class Settings {

    public static float MouseSensetive = 5f;
    public static float Gravity = 9.8f;

    public static float PlayerMaxHealth = 100f;
    public static float PlayerMaxStamina = 100f;

    public static float PlayerMaxHealthBoosted = 500f;
    public static float PlayerMaxStaminaBoosted = 1000f;

    public static float PlayerHealthRecoverySpeed = 0.1f;
    public static float PlayerStaminaRecoverySpeed = 0.1f;

    public static float PlayerHealthRecoverySpeedBoosted = 0.5f;
    public static float PlayerStaminaRecoverySpeedBoosted = 1f;
    
    public static float PlayerRunBooster = 1.5f;
    public static float PlayerRunBoosterBoosted = 2.5f;

    public static float PlayerJumpPower = 5f;
    public static float PlayerJumpPowerBoosted = 10f;
}
