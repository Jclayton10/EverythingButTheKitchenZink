using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    //Default Stats
    public float strength, speed, healthRegen;

    /// <summary>
    /// Increases User Strength
    /// </summary>
    /// <param name="increaseAmt">Amount to Increase By</param>
    public void increaseStrength(float increaseAmt) => strength += increaseAmt;

    /// <summary>
    /// Increases User Speed
    /// </summary>
    /// <param name="increaseAmt">Amount to Increase By</param>
    public void increaseSpeed(float increaseAmt) => speed += increaseAmt;

    /// <summary>
    /// Increases User Health Regen
    /// </summary>
    /// <param name="increaseAmt">Amount to Increase By</param>
    public void increaseRegen(float increaseAmt) => speed += increaseAmt;

    public void turnOff()
    {
        GameObject.Find("Sink UI").SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
