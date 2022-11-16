using UnityEngine;
using TMPro;

public class UpdateCostLabel : MonoBehaviour
{
    private int currentCost, prevCost = -1;
    public GameObject GlobalStats;

	private void Awake()
	{
        GlobalStats = GameObject.Find("Global Stats");
    }
	private void Update()
    {
        currentCost = GlobalStats.GetComponent<GlobalStats>().costForRoom;
        if (currentCost != prevCost)
		{
            GetComponent<TextMeshPro>().text = currentCost + " Gold";
            prevCost = currentCost;
        }
    }
}
