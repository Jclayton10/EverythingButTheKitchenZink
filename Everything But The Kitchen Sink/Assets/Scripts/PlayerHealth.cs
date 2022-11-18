using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float PushBackStrength;
    PlayerStat playerStats;

    GameObject bloodEffect;
    private void Start()
    {
        bloodEffect = GameObject.Find("Player UI").transform.Find("Blood").gameObject;
        bloodEffect.SetActive(false);
        playerStats = GameObject.Find("Stats").GetComponent<PlayerStat>();
    }

    public float elapsedTime;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(Health < 20 && playerStats.healthRegen < elapsedTime)
        {
            //Heals 1 health a second
            Health += 1 * Time.deltaTime;
            UpdateBlood();
        }
    }

    private void UpdateBlood()
    {
        if (Health < 10)
        {
            bloodEffect.SetActive(true);
            Color newColor = bloodEffect.GetComponent<Image>().color;
            newColor.a = 1 / Health;
            bloodEffect.GetComponent<Image>().color = newColor;
            Debug.Log(newColor.a);
        }
        else
            bloodEffect.SetActive(false);
    }

    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        UpdateBlood();
        elapsedTime = 0;
    }
}
