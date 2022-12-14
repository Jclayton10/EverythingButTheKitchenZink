using Photon.Pun;
using UnityEngine;
using TMPro;

public class UnlockRoom : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public bool opened = false;

    private void Start()
    {
        if (opened)
            SetValues();
    }

    public void unlock()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        photonView.RPC("SetValues", RpcTarget.All);
    }

    [PunRPC]
    public void SetValues()
    {
        JointLimits leftDoorJoint = LeftDoor.GetComponent<HingeJoint>().limits;
        leftDoorJoint.max = 90;
        LeftDoor.GetComponent<HingeJoint>().limits = leftDoorJoint;
        JointLimits rightDoorJoint = RightDoor.GetComponent<HingeJoint>().limits;
        rightDoorJoint.min = -90;
        RightDoor.GetComponent<HingeJoint>().limits = rightDoorJoint;

        foreach (RectangleSpawn spawner in transform.GetComponentsInChildren<RectangleSpawn>())
        {
            spawner.enabled = true;
        }

        TextMeshPro.Destroy(transform.GetChild(0).gameObject);
        if (!opened)
        {
            GameObject.Find("Sink(Clone)").GetComponent<Sink>().sinkLocations.Add(transform.Find("Sink Location").position);
            GameObject.Find("Sink(Clone)").GetComponent<Sink>().cantUseSinkLocations.Remove(transform.Find("Sink Location").position);

            if (GameObject.Find("Sink(Clone)").transform.position == new Vector3(0f, -100f, 0f))
                GameObject.Find("Sink(Clone)").GetComponent<Sink>().Teleport();
        }
        opened = true;
    }
}
