using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Building : MonoBehaviour
{
    [SerializeField]
    GameObject last_ground;
    
    void Start()
    {
        for(int i = 1; i <= 15; i++)
        {
            Create_Ground();
        }
    }

       void Update()
    {
        
    }
    public void Create_Ground()
    {
        Vector3 direction;
        if(Random.Range(0,2) == 0) // 0 yada 1
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.back;
        }
           

        last_ground = Instantiate(last_ground, last_ground.transform.position + direction, last_ground.transform.rotation);//ayný zeminden oluþturarak dümdüz gitmesi için gereken kod (vector3.back ): 1 birim eklemek demek
    }
}
