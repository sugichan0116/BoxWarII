using DG.Tweening;
using UnityEngine;

public class MoveShake : MonoBehaviour
{
    public float distance = 1f;

    private Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = transform.position;

        sequence = DOTween.Sequence();
        sequence.Append(transform
            .DOShakeScale(0.5f)
            //.SetRelative()
            .SetDelay(3)
            );
        sequence.SetLoops(-1);
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
