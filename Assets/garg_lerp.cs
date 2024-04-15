using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garg_lerp : MonoBehaviour
{
    //https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
    float scaleMax = 1.1f;
    float scaleMin = 0.9f;
    float scaleMod = 1f;
    float lerpTime = 0.15f;
    float amp = 3f;
    public GameObject lemon;
    Vector3 blankVect = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Breathe(scaleMod, scaleMax, lerpTime));
    }

    IEnumerator Breathe(float startVal, float endVal, float duration){
        float time = 0;
        while (time < duration){
            scaleMod = Mathf.Lerp(startVal, endVal, (time / duration));
            transform.localScale = blankVect * scaleMod;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = blankVect * endVal;
        scaleMod = endVal;
    }

    // Update is called once per frame
    void Update()
    {
        //if (scaleMod > scaleMax) scaleMod = scaleMax;
        //if (scaleMod < scaleMin) scaleMod = scaleMin;
        //If lemon is close to the gargoyle
        if (Vector3.Distance(lemon.transform.position, transform.position) < 5.5f) {
            if (scaleMod == scaleMax) StartCoroutine(Breathe(scaleMax, scaleMin, lerpTime));
            else if (scaleMod == scaleMin) StartCoroutine(Breathe(scaleMin, scaleMax, lerpTime));
        //Otherwise
        }else{
            if (scaleMod == scaleMax) StartCoroutine(Breathe(scaleMax, scaleMin, lerpTime*amp));
            else if (scaleMod == scaleMin) StartCoroutine(Breathe(scaleMin, scaleMax, lerpTime*amp));
        }
    }
}
