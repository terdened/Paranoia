using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

    private StateCode ActiveState;

    public float Health;
    public float Stamina;

    private float MaxHealth;
    private float MaxStamina;

    private float HealthRecoverySpeed;
    private float StaminaRecoverySpeed;

    private float RunBooster;
    private float JumpPower;


    // Use this for initialization
    void Start () {
        ActiveState = StateCode.Normal;
        MaxHealth = Settings.PlayerMaxHealth;
        MaxStamina = Settings.PlayerMaxStamina;
        Health = MaxHealth;
        Stamina = MaxStamina;
        HealthRecoverySpeed = Settings.PlayerHealthRecoverySpeed;
        StaminaRecoverySpeed = Settings.PlayerStaminaRecoverySpeed;
        RunBooster = Settings.PlayerRunBooster;
        JumpPower = Settings.PlayerJumpPower;
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleStateChange();
        UpdateStats();
    }

    public float GetRunBooster()
    {
        return RunBooster;
    }

    public float GetJumpPower()
    {
        return JumpPower;
    }

    public bool GetStamina(int value)
    {
        if (Stamina < value)
            return false;

        Stamina -= value;
        return true;
    }

    private void UpdateStats()
    {
        if (Health < MaxHealth)
            Health += HealthRecoverySpeed;

        if (Stamina < MaxStamina)
            Stamina += StaminaRecoverySpeed;

        if (Health > MaxHealth)
            Health = MaxHealth;

        if (Stamina > MaxStamina)
            Stamina = MaxStamina;
    }

    private void HandleStateChange()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveState = StateCode.Normal;
            MaxHealth = Settings.PlayerMaxHealth;
            MaxStamina = Settings.PlayerMaxStamina;
            HealthRecoverySpeed = Settings.PlayerHealthRecoverySpeed;
            StaminaRecoverySpeed = Settings.PlayerStaminaRecoverySpeed;
            RunBooster = Settings.PlayerRunBooster;
            JumpPower = Settings.PlayerJumpPower;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveState = StateCode.ClassA;
            MaxHealth = Settings.PlayerMaxHealth;
            MaxStamina = Settings.PlayerMaxStamina;
            HealthRecoverySpeed = Settings.PlayerHealthRecoverySpeed;
            StaminaRecoverySpeed = Settings.PlayerStaminaRecoverySpeed;
            RunBooster = Settings.PlayerRunBooster;
            JumpPower = Settings.PlayerJumpPower;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveState = StateCode.ClassB;
            MaxHealth = Settings.PlayerMaxHealth;
            MaxStamina = Settings.PlayerMaxStaminaBoosted;
            HealthRecoverySpeed = Settings.PlayerHealthRecoverySpeed;
            StaminaRecoverySpeed = Settings.PlayerStaminaRecoverySpeedBoosted;
            RunBooster = Settings.PlayerRunBoosterBoosted;
            JumpPower = Settings.PlayerJumpPowerBoosted;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveState = StateCode.ClassC;
            MaxHealth = Settings.PlayerMaxHealthBoosted;
            MaxStamina = Settings.PlayerMaxStamina;
            HealthRecoverySpeed = Settings.PlayerHealthRecoverySpeedBoosted;
            StaminaRecoverySpeed = Settings.PlayerStaminaRecoverySpeed;
            RunBooster = Settings.PlayerRunBooster;
            JumpPower = Settings.PlayerJumpPower;
        }
    }
}
