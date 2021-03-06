using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EnableParticlesWhenNear : MonoBehaviour
{
    [SerializeField]
    private float radius = 8;
    [SerializeField]
    private string playerTag = "Player";

    private ParticleSystem ps;
    private GameObject player;
    private float maxRate;
    private float maxSize;

    private bool foodCollected;

    void Start()
    {
        this.ps = this.GetComponent<ParticleSystem>();
        this.player = GameObject.FindGameObjectWithTag(this.playerTag);
        this.maxRate = this.ps.emission.rateOverTime.constant;
        this.maxSize = this.ps.main.startSize.constant;

        this.foodCollected = false;
        FoodCollider.OnFoodCollected += this.FoodCollected;
    }

    void Update()
    {
        ParticleSystem.EmissionModule em = this.ps.emission;
        em.enabled = this.DistanceToPlayer() <= this.radius;
        em.rateOverTime = this.maxRate * this.DistanceCoeff();

        ParticleSystem.MainModule mm = this.ps.main;
        mm.startSize = this.maxSize * this.DistanceCoeff();
    }

    private float DistanceCoeff()
    {
        return this.foodCollected ? Mathf.Sqrt(Mathf.Max(0, 1 - ((this.DistanceToPlayer() / this.radius)))) : 0;
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(this.player.transform.position, this.transform.position);
    }

    private void FoodCollected()
    {
        this.foodCollected = true;
    }
}
