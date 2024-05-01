using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AchvimentController : MonoBehaviour
{
    public Animator anim;

    public void On(string text)
    {
        anim.SetTrigger("act");

        Task.Run(() => {
            Thread.Sleep(500);
            anim.ResetTrigger("act");
            Debug.Log(text);
        });
    }
}
