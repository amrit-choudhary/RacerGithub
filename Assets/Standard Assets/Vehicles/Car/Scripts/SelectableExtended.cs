using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class SelectableExtended : Selectable
    {

        public bool IfIsPressed() {
            return IsPressed();
        }

    }
}
