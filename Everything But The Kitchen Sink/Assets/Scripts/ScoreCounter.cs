using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    PlayerStats stats;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        stats = transform.parent.parent.GetComponent<PlayerStats>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Gold: "+stats.score;
    }
}
