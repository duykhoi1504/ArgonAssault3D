using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] GameObject deathVFX;
  [SerializeField] Transform parent;
  // Start is called before the first frame update
  private void OnParticleCollision(GameObject other)
  {
    GameObject vfx= Instantiate(deathVFX, this.transform.position, Quaternion.identity);
    vfx.transform.parent=parent;
    Destroy(this.gameObject);
  }

}
