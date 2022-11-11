using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public int costForRoom = 0;

    /// <summary>
    /// Increases cost for unlocking new room
    /// </summary>
    /// <param name="increaseAmt">Amount to Increase By</param>
    public void increaseCost(int increaseAmt)
    {
        costForRoom += increaseAmt;
    }
}
