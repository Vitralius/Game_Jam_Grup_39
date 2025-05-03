using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; } //diger siniflar tarafinda gorulebilir ama degistirilemez
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField] private float _playerAwarenessDistance;
    private Transform _player;
    
    
    void Awake()
    {
        //player tagini kullanan objenin transformunu al
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
