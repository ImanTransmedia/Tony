using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Samples;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject visual;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeVisible()
    {
        if (!visual.activeSelf)
        {
            visual.SetActive(true);
        }
    }
}
