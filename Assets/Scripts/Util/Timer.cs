using UnityEngine;

public class Timer : MonoBehaviour 
{
    private float cooltime = 0.3f;
    private float phase = 0f;

    void Update() 
    {
        phase += Time.deltaTime;
    }

    public void Init(float time) {
        cooltime = time;
        Reset();
    }

    public bool IsReady() => (phase >= cooltime);

    public void Reset() => phase = 0f;
}
