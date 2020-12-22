using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TankHealth : MonoBehaviour, IDamagable
{

    [SerializeField]protected float MaxHealth = 100f;
    [SerializeField]protected Slider healthSlider;
    [SerializeField]protected Image healthFillImage;
    [SerializeField]protected Color fullHealthColor = Color.green;
    [SerializeField]protected Color lowHealthColor= Color.red;
    [SerializeField]protected GameObject ExplosionPrefab;
    [SerializeField]protected ObjectPool objectPool;

    protected ParticleSystem explosionPrefab;
    protected Coroutine explosionCoroutine=null;

     public AudioSource m_BlastAudio;         
    public AudioClip m_tankExplosionAudioClip;

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    internal float CurrentHealth=100f;
    internal bool IsDead;
 
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected void Awake()
    {
        explosionPrefab = Instantiate(ExplosionPrefab).GetComponent<ParticleSystem>();
        explosionPrefab.gameObject.SetActive(false);

        IsDead=false;
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Update() {
        SetHealthColor();
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    public void TakeDamage(float takeDamage)
    {
        CurrentHealth -=takeDamage;
        SetHealthColor();
        if(CurrentHealth<=0f && !IsDead)
        {
            PlayerDead();
        }
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected void SetHealthColor()
    {
        healthSlider.value=CurrentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,fullHealthColor,CurrentHealth/MaxHealth);
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected virtual void PlayerDead(){
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected IEnumerator playExplosionParticleSystem(){
        explosionPrefab.transform.position=transform.position;
        explosionPrefab.gameObject.SetActive(true);
        explosionPrefab.Play();
        yield return null;
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected IEnumerator playerDeathEffects(){
        
        m_BlastAudio.clip = m_tankExplosionAudioClip;
        m_BlastAudio.Play();
        yield return StartCoroutine(playExplosionParticleSystem());
        gameObject.SetActive(false);
        explosionCoroutine = null;
    }    

}
