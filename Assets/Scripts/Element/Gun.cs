using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGame
{
    [RequireComponent(typeof(LineRenderer))]
    public class Gun : MonoBehaviour
    {
        [Range(10, 100)] public float SpeedBullet = 10;
        // private Camera _cam;
        private LineRenderer _lr;
        public Transform LazerPoint;

        private void Awake()
        {
            // _cam = Camera.main;
            _lr = GetComponent<LineRenderer>();
        }


        private void Update()
        {
            Ray ray = new Ray(LazerPoint.position,LazerPoint.transform.forward); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                _lr.SetPosition(0, LazerPoint.position);
                _lr.SetPosition(1, hit.point);
            }
            else
            {
                _lr.SetPosition(0, LazerPoint.position);
                _lr.SetPosition(1, LazerPoint.position);
            }
            
 
        }

      public  void Fire()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = "bullet";
            obj.layer = 10;
            obj.AddComponent<Bullet>();
            obj.transform.localScale = Vector3.one * .2f;
            obj.transform.rotation = LazerPoint.rotation;
            obj.transform.position = LazerPoint.position;

            var _rigid = obj.AddComponent<Rigidbody>();
            _rigid.AddForce(obj.transform.forward * SpeedBullet, ForceMode.Impulse);
            
        }
    }
}