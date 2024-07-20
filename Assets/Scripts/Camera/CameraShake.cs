using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera mcam;
    private CinemachineBasicMultiChannelPerlin mperlin;
    public float ShakeTime;



    void Start()
    {
        mcam = GetComponent<CinemachineVirtualCamera>();
        mperlin = mcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        StartCoroutine(Vate());
    }

    IEnumerator Vate()
    {
        mperlin.m_AmplitudeGain = 4;
        yield return new WaitForSeconds(ShakeTime);
        mperlin.m_AmplitudeGain = 0;
    }
}
