using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Sink : MonoBehaviour
{
    public List<Vector3> sinkLocations;
    public List<Vector3> cantUseSinkLocations;
    public int numOfUses;

    private void Start()
    {
        numOfUses = 1;
        foreach(GameObject sinkLocation in GameObject.FindGameObjectsWithTag("Sink Location")){
            cantUseSinkLocations.Add(sinkLocation.transform.position);
        }
        cantUseSinkLocations.Remove(GameObject.Find("Spawn Railing Room(Clone)(Clone)").transform.Find("Sink Location").transform.position);
        sinkLocations.Add(GameObject.Find("Spawn Railing Room(Clone)(Clone)").transform.Find("Sink Location").transform.position);
    }

    public void Teleport()
    {
        if (numOfUses < sinkLocations.Count || cantUseSinkLocations.Count == 0)
        {
            int index = Mathf.RoundToInt(Random.Range(0f, (float)sinkLocations.Count - 1));
            Vector3 newDaddy = sinkLocations[index];
            transform.position = newDaddy;
            numOfUses++;
        }
        else
        {
            transform.position = new Vector3(0f, -100f, 0f);
        }
    }

    public void RespawnItems()
    {
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            GameObject newRoom = PhotonNetwork.Instantiate(room.name.Replace("(Clone)", "") + "(Clone)", room.transform.position, room.transform.rotation);
            if(newRoom.GetComponent<UnlockRoom>())
                newRoom.GetComponent<UnlockRoom>().opened = room.GetComponent<UnlockRoom>().opened;
            newRoom.transform.parent = room.transform.parent;
            PhotonNetwork.Destroy(room);
        }
    }
}
