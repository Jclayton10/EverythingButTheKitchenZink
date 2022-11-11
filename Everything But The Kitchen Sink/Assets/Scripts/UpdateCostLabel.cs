using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCostLabel : MonoBehaviour
{
    private void Update()
    {
        GetComponent<TextMeshPro>().text = GameObject.Find("Global Stats").GetComponent<GlobalStats>().costForRoom + " Gold";
    }
}
