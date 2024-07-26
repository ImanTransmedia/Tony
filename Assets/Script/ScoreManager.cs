using Oculus.Interaction;
using Oculus.Interaction.Samples;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    GameObject particles;

    [SerializeField]
    private int hambre = 10;

    PointableUnityEventWrapper respawner;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = hambre;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        particles.SetActive(true);
        slider.value --;
        other.gameObject.SetActive(false);
    }
}
