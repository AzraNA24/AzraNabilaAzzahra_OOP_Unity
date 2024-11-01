using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerMovement playerMovement;
    public Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        GameObject engineEffect = GameObject.Find("EngineEffect");
        if(engineEffect != null){
            animator = engineEffect.GetComponent<Animator>();
        } else {
            Debug.LogError($"EngineEffect di GameObject tidak ada");
        }
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    
    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
        
    }
}