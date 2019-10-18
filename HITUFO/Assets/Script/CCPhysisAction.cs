using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCPhysisAction : SSAction
{
    public float speedx;

    public override void Start ()
    {
        if (!this.gameObject.GetComponent<Rigidbody>())
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 9.8f * 0.6f, ForceMode.Acceleration);
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(speedx, 0, 0), ForceMode.VelocityChange);
    }

    private CCPhysisAction()
    {
        
    }
    public static CCPhysisAction getAction(float speedx)
    {
        CCPhysisAction action = CreateInstance<CCPhysisAction>();
        action.speedx = speedx;
        return action;
    }

    override public void Update ()
    {
        if (transform.position.y <= 3)
        {
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            destroy = true;
            CallBack.SSActionCallback(this);
        }
    }
}
