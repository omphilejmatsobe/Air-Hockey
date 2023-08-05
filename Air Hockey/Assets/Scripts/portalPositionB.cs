using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalPositionB: MonoBehaviour
{
    float u, v;

    // Start is called before the first frame update
    void Start()
    {

        u = Random.Range(-2.3f, 2.3f);
        v = Random.Range(-3.92f, -1.50f);

        transform.position = new Vector2(u, v);

    }

}
