using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandle : MonoBehaviour
{
    // Start is called before the first frame update
       private void OnTriggerEnter(Collider other) {
          Debug.Log($"{this.name} +{other.gameObject.name} ");
    }
}
