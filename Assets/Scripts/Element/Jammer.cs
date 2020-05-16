using System;
using UnityEngine;

namespace VRGame
{
    [RequireComponent(typeof(LineRenderer))]
    public class Jammer : MonoBehaviour
    {
        private LineRenderer _lr;
        public Transform aim;

        private void Awake()
        {
            _lr = GetComponent<LineRenderer>();
        }


        private JummerButton _lastButton;

        void Update()
        {
            Ray ray = new Ray(aim.position, aim.forward); //TODO: Починить
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("TagretJ"))
                {
                    _lr.SetPosition(0, aim.position);
                    _lr.SetPosition(1, hit.point);
                    _lastButton = hit.collider.GetComponent<JummerButton>();
                    _lastButton.Fz.SetActive(false);
                }
                else
                {
                    _lr.SetPosition(0, aim.position);
                    _lr.SetPosition(1, aim.position);

                    if (_lastButton != null)
                    {
                        _lastButton.Fz.SetActive(true);
                    }
                }
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(aim.position, aim.forward * 100);
        }
    }
}