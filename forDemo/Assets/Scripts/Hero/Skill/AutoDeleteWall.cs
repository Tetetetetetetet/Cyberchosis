using UnityEngine;

public class AutoDeleteWall : MonoBehaviour
{
    // Start is called before the first frame update
    public float Mytime;
    void Start()
    {
        Mytime=SkillWall.Existingtime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("uuppdd");
        if(Mytime>0.0f) Mytime-=Time.deltaTime;
        else{
            Destroy(this.gameObject);
        }
    }
}
