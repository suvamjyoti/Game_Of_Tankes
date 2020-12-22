using System.Collections;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects,layer should be set to "Players".
    public float m_MaxDamage = 25f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

    public float m_MaxLifeTime = 10f;


    public ParticleSystem m_ExplosionParticles;         
    public AudioSource m_ExplosionAudio;
    
    private IEnumerator shell_ExplosionCoroutine;

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Start() {
        
    }

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void OnTriggerEnter (Collider other)
    {

        Collider[] collider = Physics.OverlapSphere (transform.position, m_ExplosionRadius);

        for (int i = 0; i < collider.Length; i++){

            IDamagable damagableObject = collider[i].GetComponent<IDamagable> ();
            Rigidbody targetRigidbody = collider[i].GetComponent<Rigidbody>();
            

            if(damagableObject!=null){
            
                float damage = CalculateDamage (targetRigidbody.position);
                damagableObject.TakeDamage(damage);
            }
        }

        if(shell_ExplosionCoroutine==null){

            shell_ExplosionCoroutine = shell_Explosion();
            StartCoroutine(shell_ExplosionCoroutine);
        }

    }

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private float CalculateDamage (Vector3 targetPosition)
    {
        
        Vector3 explosionToTarget = targetPosition - transform.position;                        // Create a vector from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;                                  // Calculate the distance from the shell to the target.
        float relativeDistance = (m_ExplosionRadius - explosionDistance)                        // Calculate the proportion of the maximum distance 
                                 / m_ExplosionRadius;                                                   
        float damage = relativeDistance * m_MaxDamage;                                          // Calculate damage in ratio to maximum possible damage.

        damage = Mathf.Max (0f, damage);                                                        // Make sure that the minimum damage is always 0 not -ve.
        return damage;
    }

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator shell_Explosion(){
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        yield return new WaitForSeconds(m_ExplosionParticles.duration);
        gameObject.SetActive(false);
        shell_ExplosionCoroutine=null;  
    }

    private IEnumerator shell_lifetime(){

        yield return new WaitForSeconds(m_MaxLifeTime);
        gameObject.SetActive(false); 
        shell_ExplosionCoroutine=null;
    }


}