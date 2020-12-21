using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private Transform[] m_SpawnPoints;                         
    [SerializeField]private GameObject m_EnemyPrefab;

    [SerializeField]private float m_proximityRadius = 40f;                          



    private void Update() {

        if(EnemyManager.No_OfActiveEnemy<3){

           foreach (var _location in m_SpawnPoints){

                Collider[] _colliders = Physics.OverlapSphere (_location.position,m_proximityRadius);

                    int _tanks=0;

                    foreach(var _object in _colliders){
                        if(_object.tag == "Tanks"){
                            _tanks++;
                        }
                    }

                    if(_tanks==0){
                        SpawnEnemy(_location);
                        return;
                    }  
           } 
           
        }

    }


    private void SpawnEnemy(Transform _spawnPoint){
        Instantiate(m_EnemyPrefab,_spawnPoint);
    }

}
