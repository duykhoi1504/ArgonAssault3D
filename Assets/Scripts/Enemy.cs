using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] GameObject deathVFX;
  [SerializeField] Transform parent;

  ScoreBoard score;
  private void Start() {
    score=FindObjectOfType<ScoreBoard>();
  }
  [SerializeField] int amountToIncrease=15;
  // Start is called before the first frame update
  private void OnParticleCollision(GameObject other)
  {
    score.ScoreIncrease(amountToIncrease);
    GameObject vfx= Instantiate(deathVFX, this.transform.position, Quaternion.identity);
    vfx.transform.parent=parent;
    Destroy(this.gameObject);
  }

}
