using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(EnemyAction))]
public class MoveHorizonal : MonoBehaviour
{
    public float distance = 1f;

    private Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(distance, 1f).SetRelative());
        sequence.Append(transform.DOMoveX(-distance, 1f).SetRelative());
        sequence.SetLoops(-1);
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
