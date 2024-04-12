using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] GameObject deathVFX;
  [SerializeField] GameObject hitVFX;
  GameObject parentGameObject;
  [SerializeField] int scorePerHit = 15;
  [SerializeField] int hitPoints = 2;

  ScoreBoard score;
  void Start()
  {
    score = FindObjectOfType<ScoreBoard>();
    parentGameObject=GameObject.FindWithTag("SpawnAtRunTime");
  }

  // Start is called before the first frame update
  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
    if (hitPoints < 1)
      KillEnemy();
  }


 

  void ProcessHit()
  {
    GameObject hitvfx = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
    hitvfx.transform.parent = parentGameObject.transform;
    hitPoints--;
    
  }
  void KillEnemy()
  {
    score.ScoreIncrease(scorePerHit);
    GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
    vfx.transform.parent = parentGameObject.transform;
    Destroy(this.gameObject);
  }


}
