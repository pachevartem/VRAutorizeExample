using System;
using UnityEngine;
using UnityEngine.AI;

namespace VRGame
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        public bool isDrawGizmo;
        public float RadiusAttack = 1;
        public float RadiusAgro = 10;
        private NavMeshAgent _agent;
        private Animator _anim;

        public LayerMask playerLayer;
        
        
        [Header("Укажи имя главного персонажа")]
        public string namePlayer;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
        }


        private void Update() // TODO: Change
        {
            var AttackZone = Physics.OverlapSphere(transform.position, RadiusAttack, playerLayer); // 1<<8
            var AgroZone = Physics.OverlapSphere(transform.position, RadiusAgro, playerLayer);

            if (AgroZone.Length > 0) // TODO: Change
            {
                _agent.SetDestination(AgroZone[0].transform.position);
                _anim.SetFloat("speed", _agent.velocity.magnitude);
            }

            if (AttackZone.Length > 0) // TODO: Change
            {
                _anim.SetBool("isAttack", true);
            }
            else
            {
                _anim.SetBool("isAttack", false);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "bullet") // TODO: Change
            {
                Destroy(gameObject); // отнимаются жизни у врага
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if (other.gameObject.name == namePlayer) //TODO: change
            {
                GameManager.HP -= 20;
                Debug.LogWarning("DAMAGE");
            }
        }

        private void OnDrawGizmos()
        {
            if (isDrawGizmo)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, RadiusAttack);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, RadiusAgro);
            }
        }
    }
}