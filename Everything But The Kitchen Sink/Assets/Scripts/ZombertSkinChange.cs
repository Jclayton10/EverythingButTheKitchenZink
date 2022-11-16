using System.Collections.Generic;
using UnityEngine;

public class ZombertSkinChange : MonoBehaviour
{
    public List<Texture> zombertSkins;
    public Texture selectedTexture;
    void Start()
    {
        int selectedIndex = Mathf.FloorToInt(Random.Range(0f, (float)zombertSkins.Count));
        selectedTexture = zombertSkins[selectedIndex];
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", selectedTexture);
    }

    
}
