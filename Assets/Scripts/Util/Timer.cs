using UnityEngine;

public class Timer : MonoBehaviour 
{
    private float cooltime = 0.3f;
    private float phase = 0f;

    void Update() 
    {
        phase += Time.deltaTime;
    }

    public Timer Init(float time) {
        cooltime = time;
        Reset();
        return this;
    }

    public bool IsReady() => (phase >= cooltime);

    public void Reset() => phase = 0f;

    public float Now => Mathf.Clamp(phase, 0f, cooltime);
    public float Timeout => cooltime;
}
