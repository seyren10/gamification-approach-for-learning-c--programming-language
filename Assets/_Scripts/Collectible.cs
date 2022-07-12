using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private CollectibleType collectibleType;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ObjectiveEvent.onCollect.Invoke(this);
            Destroy(gameObject);
        }
    }

    public CollectibleType GetCollectibleType()
    {
        return collectibleType;
    }
}
