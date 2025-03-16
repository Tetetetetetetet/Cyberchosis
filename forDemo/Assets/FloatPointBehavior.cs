using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatPointBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position;
    public float damage;
    public TextMeshPro txt;
    void Start()
    {
        Debug.Assert(damage!=0);
        GameObject child=transform.Find("FloatPoint").gameObject;
        txt=child.GetComponent<TextMeshPro>();
        txt.text=damage.ToString();
        Invoke("destroySelf",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition=position;
    }
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
