using UnityEngine ;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticle : MonoBehaviour
{
	void Start () {
		ParticleSystem partcleSystem = GetComponent<ParticleSystem>() ;
		//Delete object after duration.
		Destroy(gameObject, (float)partcleSystem.main.duration ) ;
	}
}
