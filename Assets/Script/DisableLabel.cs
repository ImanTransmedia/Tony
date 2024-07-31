using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableLabel : MonoBehaviour
{
    [SerializeField]
    GameObject label;

    private void OnCollisionExit(Collision collision)
    {
        if (label.activeSelf)
            label.SetActive(false);

    }
}
