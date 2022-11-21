using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rbody;
    GameManager _gamemanager;
    public int addScore;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(randomForce(), ForceMode.Impulse);
        rbody.AddTorque(randomTorque());
        transform.position = new Vector3(Random.Range(-4, 4), -4);

        _gamemanager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
    }
    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }
    Vector3 randomTorque()
    {
        return new Vector3 (Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }

    private void OnMouseDown()
    {
        if(!_gamemanager.gameOver)
        {
            Destroy(gameObject);
            _gamemanager.UpdateScore(addScore);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!other.CompareTag("Bad"))
        {
            _gamemanager.GameOver();
            _gamemanager.gameOver = true;
        }
    }
}
