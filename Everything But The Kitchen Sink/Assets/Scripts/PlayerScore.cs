using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;

    /// <summary>
    /// Increases the player's score
    /// </summary>
    /// <param name="increaseAmt">Amount score is increased by</param>
    public void IncreaseScore(int increaseAmt)
    {
        score += increaseAmt;
        GameObject.Find("Player UI").transform.Find("Points").GetComponent<ScoreCounter>().score = score;
    }
}
