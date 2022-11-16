using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ItemStats : MonoBehaviour
{
    public int lastPickedUpItem;

    [Tooltip("Order: Weight, Damage, Durability")]
    public List<Vector3> itemValues;

    public void decreaseWeight(float decreaseAmt)
    {
        itemValues[lastPickedUpItem] = new Vector3(itemValues[lastPickedUpItem].x * decreaseAmt, itemValues[lastPickedUpItem].y, itemValues[lastPickedUpItem].z);
        PhotonView.Get(this).RPC("otherPlayerDecreaseWeight", RpcTarget.Others, lastPickedUpItem, decreaseAmt);
    }
    public void increaseDmg(float increaseAmt)
    {
        itemValues[lastPickedUpItem] = new Vector3(itemValues[lastPickedUpItem].x, itemValues[lastPickedUpItem].y + increaseAmt, itemValues[lastPickedUpItem].z);
        PhotonView.Get(this).RPC("otherPlayerIncreaseDmg", RpcTarget.Others, lastPickedUpItem, increaseAmt);
    }
    public void increaseDurability(float increaseAmt)
    {
        itemValues[lastPickedUpItem] = new Vector3(itemValues[lastPickedUpItem].x, itemValues[lastPickedUpItem].y, itemValues[lastPickedUpItem].z + increaseAmt);
        PhotonView.Get(this).RPC("otherPlayerIncreaseDurability", RpcTarget.Others, lastPickedUpItem, increaseAmt);
    }

    [PunRPC]
    public void otherPlayerDecreaseWeight(int itemKey, float amt)
    {
        itemValues[itemKey] = new Vector3(itemValues[itemKey].x * amt, itemValues[itemKey].y, itemValues[itemKey].z);
    }

    [PunRPC]
    public void otherPlayerIncreaseDmg(int itemKey, float amt)
    {
        itemValues[itemKey] = new Vector3(itemValues[itemKey].x, itemValues[itemKey].y * amt, itemValues[itemKey].z);
    }

    [PunRPC]
    public void otherPlayerIncreaseDurability(int itemKey, float amt)
    {
        itemValues[itemKey] = new Vector3(itemValues[itemKey].x, itemValues[itemKey].y, itemValues[itemKey].z * amt);
    }

    public void turnOff()
    {
        GameObject.Find("Sink UI").SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
