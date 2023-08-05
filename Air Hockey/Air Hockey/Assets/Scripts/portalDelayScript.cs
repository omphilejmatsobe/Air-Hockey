using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalDelayScript : MonoBehaviour
{
    public GameObject portalA;
    public GameObject portalB;

    // Start is called before the first frame update
    void Start()
    {
        portalA.gameObject.SetActive(false);
        portalB.gameObject.SetActive(false);

        Invoke("portalDelay", Random.Range(120, 125));
        Invoke("portalHide", Random.Range(140, 145));
    }

    private void portalDelay()
    {
        portalA.gameObject.SetActive(true);
        portalB.gameObject.SetActive(true);
    }

    private void portalHide()
    {
        portalA.gameObject.SetActive(false);
        portalB.gameObject.SetActive(false);
    }
}
