using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeDes=2f;
    void Start()
    {
        Destroy(this.gameObject,timeDes);
    }

}
