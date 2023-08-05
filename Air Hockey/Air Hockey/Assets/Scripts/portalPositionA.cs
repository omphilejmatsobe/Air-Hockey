using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalPositionA: MonoBehaviour
{
    float x, y;

    // Start is called before the first frame update
    private void Start()
    {
        // Randomizes the position of the portal around one side of the board

        x = Random.Range(-2.3f, 2.3f);
        y = Random.Range(1.50f, 3.92f);

        transform.position = new Vector2(x, y);
    }

}
