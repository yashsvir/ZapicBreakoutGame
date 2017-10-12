using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    private float _initalVelocity = 0;
    private Rigidbody _rb;
    private float _initialBallAngle;
    private ParticleSystem[] _ps;
    private CanvasManager _cm;
    private LevelLoader _ll;

    void Awake()
    {
        _initalVelocity = GameSettings.initalBallVelocity;
        _rb = GetComponent<Rigidbody>();
        _initialBallAngle = UnityEngine.Random.Range(0, 360);
        _ps = (Resources.LoadAll("Particles", typeof(ParticleSystem))).Cast<ParticleSystem>().ToArray();
        _cm = GameObject.Find("ScriptObject").GetComponent<CanvasManager>();
        //StartCoroutine(BeginGame());
        
    }

    public void Reset(){
        _ll = GameObject.Find("ScriptObject").GetComponent<LevelLoader>();
        _ll.Reset();
        _cm.Reset();

        _rb.velocity = new Vector3(0,0,0);
        transform.position = new Vector3(0, 0, 0);
        _initialBallAngle = UnityEngine.Random.Range(0, 360);
        StartCoroutine(BeginGame());

    }

    IEnumerator BeginGame(){

        while (GameSettings.gameState != EnumTypes.GameState.PlayMode)
        {
            yield return null;
        }
        StartCoroutine(FireBall());
        StartCoroutine(CheckForGameOver());

    }

    private IEnumerator CheckForGameOver()
    {
        while (Vector3.Distance(gameObject.transform.position, new Vector3(0, 0, 0)) < GameSettings.gameRange)
        {
            yield return new WaitForSeconds(GameSettings.checkForRangeTime);
        }

        GameOver();
    }

    private void GameOver()
    {
        _cm.GameOver();
    }

    private IEnumerator FireBall()
    {
        yield return new WaitForSeconds(GameSettings.initalWait);

        _rb.isKinematic = false;
        _rb.AddForce(new Vector3(_initalVelocity*Mathf.Sin(_initialBallAngle *Mathf.Deg2Rad), _initalVelocity * Mathf.Cos(_initialBallAngle * Mathf.Deg2Rad), 0));

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Brick")
        {
            Instantiate(_ps[0], col.transform.position, transform.rotation);
            Destroy(col.gameObject);
            _cm.AddScore();
            
        }
    }

    
    void Update() {

        
    }
}
