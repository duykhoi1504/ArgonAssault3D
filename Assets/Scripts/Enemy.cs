using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnParticleCollision(GameObject other) {
    if(other.gameObject.CompareTag("Enemy"))
    Debug.Log($"{this.name} + {other.gameObject.name}");
      this.gameObject.SetActive(false);
    }

}
