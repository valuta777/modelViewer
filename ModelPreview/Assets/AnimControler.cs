using UnityEngine;
using System.Collections;

public class AnimControler : MonoBehaviour {


    public void StopPlay()
    {
        if (transform.childCount > 0)
        {
            GameObject curentModel = transform.GetChild(0).gameObject;
            if (curentModel != null)
            {
                Animator anim = curentModel.GetComponent<Animator>();
                if (anim.enabled)
                {
                    anim.enabled = false;
                }
                else
                {
                    anim.enabled = true;
                }
            }
        }
    }
}
