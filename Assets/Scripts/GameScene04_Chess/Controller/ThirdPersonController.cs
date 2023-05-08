using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace ChessScene
{
    public class ThirdPersonController : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Animator animator;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if(Physics.Raycast(ray, out raycastHit))
                {
                    navMeshAgent.SetDestination(raycastHit.point);
                }
            }

            if(navMeshAgent.velocity != Vector3.zero)
            {
                animator.SetBool("isWalking", true);
            }
            else if(navMeshAgent.velocity == Vector3.zero)
            {
                animator.SetBool("isWalking", false);
            }
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {

        }
    }
}