using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField]
    private string targetScene = "EndOfLevel";
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private AudioClip portalEnterClip;

    private bool open;

    private void Start()
    {
        this.open = false;
        FoodCollider.OnFoodCollected += this.OnFoodCollected;
    }

    private void OnFoodCollected()
    {
        this.open = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.open && other.CompareTag(this.playerTag))
        {
            AudioSource.PlayClipAtPoint(this.portalEnterClip, this.transform.position);
            ManageScenes.instance.SwitchScene(this.targetScene);
        }
    }
}
