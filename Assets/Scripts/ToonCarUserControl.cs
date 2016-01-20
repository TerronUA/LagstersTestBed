using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Lagsters.Car
{
    [RequireComponent(typeof (ToonCarController))]
    public class ToonCarUserControl : MonoBehaviour
    {
        private ToonCarController m_Car; // the car controller we want to use

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<ToonCarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
