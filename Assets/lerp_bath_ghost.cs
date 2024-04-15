using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp_bath_ghost : MonoBehaviour
{
    public GameObject lemon;
    Coroutine smoothMove = null;
    //Coroutine movingBack = null;
    //Vector3 origpos = new Vector3(0.0f, 128.816f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    //https://stackoverflow.com/questions/51127919/unity-2018-npc-smoothly-turning-to-face-the-player-while-within-range
    void BathGhostTurn(){
        float time = 1f; //?
        Vector3 looking = lemon.transform.position;
        looking.y = transform.position.y;
        if (smoothMove != null) StopCoroutine(smoothMove);
        smoothMove = StartCoroutine(RoutineTurn(transform, looking, time));
    }

    IEnumerator RoutineTurn(Transform obj, Vector3 pos, float duration) {
        Quaternion current = obj.rotation;
        Quaternion newrot = Quaternion.LookRotation(pos - obj.position, obj.TransformDirection(Vector3.up));
        float counter = 0;
        while (counter < duration){
            counter += Time.deltaTime;
            obj.rotation = Quaternion.Lerp(current, newrot, counter / duration);
            yield return null;
        }
    }

    /*IEnumerator MoveBack(float duration){
        Quaternion current = transform.rotation;
        Quaternion origq = Quaternion.Euler(0.0f, 128.816f, 0.0f);
        float counter = 0;
        while (transform.rotation.y < origq.y){
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(current, origq, counter / duration);
            yield return null;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //if (movingBack != null) StopCoroutine(movingBack);
        if (Vector3.Distance(lemon.transform.position, transform.position) < 3f) {
            BathGhostTurn();
        }
        //else movingBack = StartCoroutine(MoveBack(0.2f));
    }
}
