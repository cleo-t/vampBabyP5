using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodCollider : MonoBehaviour
{
    public static event Action OnFoodCollected;

    [SerializeField]
    private GameObject foodObject;
    [SerializeField]
    private string bbTag = "Baby";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(this.bbTag))
        {
            Destroy(this.foodObject);
            this.BroadcastFoodCollected();
        }
    }

    private void BroadcastFoodCollected()
    {
        if (OnFoodCollected != null)
        {
            OnFoodCollected.Invoke();
        }
    }
}
