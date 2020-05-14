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
        private Camera _cam;
        private LineRenderer _lr;

        private void Awake()
        {
            _cam = Camera.main;
            _lr = GetComponent<LineRenderer>();
        }


        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                _lr.SetPosition(0, transform.position);
                _lr.SetPosition(1, hit.point);
            }
            else
            {
                _lr.SetPosition(0, transform.position);
                _lr.SetPosition(1, transform.position);
            }

            transform.LookAt(hit.point);

            if (Input.GetMouseButtonDown(0))
            {
                var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                obj.name = "bullet";
                obj.layer = 10;
                obj.AddComponent<Bullet>();
                obj.transform.localScale = Vector3.one * .2f;
                obj.transform.rotation = transform.rotation;
                obj.transform.position = transform.position;

                var _rigid = obj.AddComponent<Rigidbody>();
                _rigid.AddForce(obj.transform.forward * SpeedBullet, ForceMode.Impulse);
            }
        }
    }
}