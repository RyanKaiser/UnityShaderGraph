using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{ 
    /*    
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
            Dofade(0,1,fadeTime);
        }
        else
        {
            _renderer.material = mtrlPhase;
            Dofade( 0 , 2, fadeTime);
        }
    }

    void Dofade(float start, float dest, float time)
    {
        iTween.ValueTo( gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "TweenOnUpdate", "oncomplte", "TweenOnComplte",
            "easetype", iTween.EaseType.easeInOutCubic ));
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat( "_SpiltValue", value);
    }

    void TweenOnComplte()
    {
        _renderer.material = mtrlOrg;
    }
    */    
}
