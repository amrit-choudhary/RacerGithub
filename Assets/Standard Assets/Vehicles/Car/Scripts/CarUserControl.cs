using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public MobileInputNew mobileInput;

        private void Awake() {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate() {
#if UNITY_ANDROID
            float h1 = mobileInput.h;
            float v1 = mobileInput.v;
            float handbrake1 = mobileInput.handbrake;
            m_Car.Move(h1, v1, v1, 0);
            return;
#endif
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
