using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace MBT
{
    [AddComponentMenu("")]
    //
    [MBTNode(name = "Tasks/MoveTo")]
    public class MovementNode : Leaf
    {
        [SerializeField] private Vector3Reference position = new(VarRefMode.DisableConstant);
        [SerializeField] private bool ObserveVariable;
        private void Start()
        {
            if (ObserveVariable)
            {
                position.GetVariable().AddListener((oldVal, newVal) =>
                {
                    if (runningNodeResult.status == Status.Running)
                    {
                        if(newVal != oldVal)
                        {
                            OnEnter();
                        }
                    }
                });
            }
        }
        public override void OnAllowInterrupt()
        {
            navMeshAgent.SetDestination(position.Value);
        }
        public override void OnEnter()
        {
          
        }
        public override NodeResult Execute()
        {
            if (navMeshAgent.isPathStale) return NodeResult.running;
            return NodeResult.success;
        }
    }
}