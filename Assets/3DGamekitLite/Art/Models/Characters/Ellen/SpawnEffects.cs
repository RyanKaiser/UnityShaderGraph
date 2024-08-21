using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material mtrlOrg;
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private Material mtrlPhase;
    [SerializeField] private float fadeTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 50)
        {
            _renderer.material = mtrlDissolve;
            DoFade(0, 1, fadeTime);
        }
        else
        {
            _renderer.material = mtrlPhase;
            DoFade(0, 2, fadeTime);
        }    
    }

    // Update is called once per frame
    void DoFade(float start, float dest, float time)
    {
        float value = start;
        DOTween.To(
            () => value, x => value = x, dest, time)
        .OnUpdate(() => {
            _renderer.material.SetFloat("_Split_Value", value);
        });
    }
}
