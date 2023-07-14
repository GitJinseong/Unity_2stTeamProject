using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttach : MonoBehaviour
{
    public Transform parentObject;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = parentObject;
    }

}
