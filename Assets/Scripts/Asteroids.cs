using UnityEngine;

public class Asteroids : MonoBehaviour {
    public GameObject smallerAsteroidPrefab; 
    public int size; 
    public int scoreValue; 
    public float thrustForce = 10f; 
    public Transform asteroidContainer; 
    public float lifeTime = 300.0f;
    public AudioClip destructionSound;
    private AudioSource audioSource;
    public GameObject explosionParticlePrefab;

    private Rigidbody2D asteroidRb;

    private void Start() {
        
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, lifeTime);
    }

    private void Awake() {
        
        asteroidRb = GetComponent<Rigidbody2D>();
        ApplyRandomMovement();
    }

    private void ApplyRandomMovement() {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        asteroidRb.AddForce(randomDirection * thrustForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D impact) {
        if (impact.gameObject.CompareTag("Bullet")) { 
            
            ProcessCollisionWithBullet(impact);
        }
    }

    private void ProcessCollisionWithBullet(Collision2D impact) {
    
    GameManager.instance.AddScore(scoreValue);
    Destroy(impact.gameObject); 

    
    if (audioSource && destructionSound) {
        audioSource.PlayOneShot(destructionSound);
    }
    // Instancia el sistema de partículas
    if (explosionParticlePrefab) {
        var explosion = Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }

    // Verificar si el tamaño del asteroide es mayor a 1 para dividirlo, si no, destruirlo
    if (size > 1) {
        BreakApart();
    } else {
        // Si el asteroide no se va a dividir, entonces espera a que termine el sonido antes de destruir el objeto
        Destroy(gameObject);
    }
}


    private void BreakApart() {
        // Crear dos fragmentos más pequeños del asteroide
        var fragmentOne = SpawnSmallerAsteroid();
        var fragmentTwo = SpawnSmallerAsteroid();
        ApplyForceToFragment(fragmentOne);
        ApplyForceToFragment(fragmentTwo);
    }

    private GameObject SpawnSmallerAsteroid() {
        // Instanciar un fragmento de asteroide
        return Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)), asteroidContainer);
    }

    private void ApplyForceToFragment(GameObject fragment) {
        // Aplicar una fuerza aleatoria al fragmento de asteroide
        Vector2 randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Rigidbody2D fragmentRb = fragment.GetComponent<Rigidbody2D>();
        fragmentRb.AddForce(randomForce * thrustForce, ForceMode2D.Impulse);
    }
}
