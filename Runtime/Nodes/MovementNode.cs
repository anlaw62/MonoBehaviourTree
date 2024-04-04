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
        [SerializeField] private Vector3Variable position;
        public override void OnEnter()
        {
            navMeshAgent.SetDestination(position.Value);
        }
        public override NodeResult Execute()
        {
            if (!navMeshAgent.isStopped) return NodeResult.running;
            else if (
                navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid
                ||
                navMeshAgent.pathStatus == NavMeshPathStatus.PathPartial) return NodeResult.failure;
            return NodeResult.success;
        }
    }
}