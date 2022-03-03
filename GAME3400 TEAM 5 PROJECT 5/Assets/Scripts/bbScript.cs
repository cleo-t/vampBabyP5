using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbScript : MonoBehaviour
{
    [SerializeField]
    private List<bbStep> steps;
    [SerializeField]
    private Vector2 offsetFromStep;
    [SerializeField]
    private float speed = 2;

    private int reachedSteps;
    private int targetStep;

    void Start()
    {
        this.reachedSteps = 0;
        this.targetStep = -1;
    }

    void Update()
    {
        this.UpdateTargetStep();
        this.MoveToNextTarget();
    }

    private void UpdateTargetStep()
    {
        if (this.targetStep < this.steps.Count - 1)
        {
            if (this.steps[this.targetStep + 1].SafeToAdvance())
            {
                this.targetStep++;
            }   
        }
    }

    private void MoveToNextTarget()
    {
        int nextStepIndex = this.NextStep();
        if (nextStepIndex == -1)
        {
            return;
        }
        bbStep nextStep = this.steps[nextStepIndex];
        Vector3 nextStepPos = nextStep.transform.position + new Vector3(this.offsetFromStep.x, 0, this.offsetFromStep.y);
        this.transform.position = Vector3.MoveTowards(this.transform.position, nextStepPos, this.speed * Time.deltaTime);
        if (nextStepIndex == this.reachedSteps && Vector3.Distance(this.transform.position, nextStepPos) < 0.001f)
        {
            this.reachedSteps++;
        }
    }

    private int NextStep()
    {
        return Mathf.Min(this.targetStep, this.reachedSteps);
    }
}
