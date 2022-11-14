using System.Collections.Generic;
using UnityEngine;

public class ZombertSkinChange : MonoBehaviour
{
    public List<Material> zombertSkins;
    public Material selectedMaterial;
    void Start()
    {
        int selectedIndex = Mathf.FloorToInt(Random.Range(0f, (float)zombertSkins.Count));
        selectedMaterial = zombertSkins[selectedIndex];
        gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    
}
