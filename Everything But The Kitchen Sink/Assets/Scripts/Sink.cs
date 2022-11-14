using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public List<Transform> sinkLocations;
    public List<GameObject> cantUseSinkLocations;
    public int numOfUses;

    private void Start()
    {
        numOfUses = 1;
        cantUseSinkLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("Room"));
    }

    public void Teleport()
    {
        if (numOfUses < sinkLocations.Count || cantUseSinkLocations.Count == 0)
        {
            int index = Mathf.RoundToInt(Random.Range(0f, (float)sinkLocations.Count - 1));
            Transform newDaddy = sinkLocations[index];

            transform.parent = newDaddy;
            Debug.Log(sinkLocations.Count + ", " + index + ", " + newDaddy.parent);
            transform.localPosition = new Vector3(0, 0, 0);
            numOfUses++;
        }
        else
        {
            transform.position = new Vector3(0f, -100f, 0f);
        }
    }
}
