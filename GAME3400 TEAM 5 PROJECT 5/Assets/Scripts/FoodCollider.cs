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

    private bool hit;

    private void Start()
    {
        this.hit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.hit && other.CompareTag(this.bbTag))
        {
            this.hit = true;
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
