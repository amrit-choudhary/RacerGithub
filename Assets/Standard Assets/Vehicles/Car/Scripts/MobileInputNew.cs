using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class MobileInputNew : MonoBehaviour
    {

        public float h = 0;
        public float v = 0;
        public float handbrake = 0.0f;

        public SelectableExtended right;
        public SelectableExtended left;
        public SelectableExtended accelerate;
        public SelectableExtended brake;

        void Update() {
            if (right.IfIsPressed()) {
                h = 1.0f;
            }

            if (left.IfIsPressed()) {
                h = -1.0f;
            }

            if (!right.IfIsPressed() && !left.IfIsPressed()) {
                h = 0.0f;
            }

            if (accelerate.IfIsPressed()) {
                v = 1.0f;
            }

            if (brake.IfIsPressed()) {
                v = -1.0f;
            }

            if (!accelerate.IfIsPressed() && !brake.IfIsPressed()) {
                v = 0.0f;
            }

        }

    }
}
