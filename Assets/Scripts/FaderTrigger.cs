using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderTrigger : MonoBehaviour
{
    public Fader end;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            end.EndScene();
        }
    }

}
