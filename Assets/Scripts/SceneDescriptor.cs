using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDescriptor : MonoBehaviour
{

    [Tooltip("A prefab of a player object that will be spawned when the scene is loaded")] public GameObject player;
    [Tooltip("A Transform object inside the scene where the player will be spawned in.")] public Transform playerSpawn;
    [Tooltip("An AudioClip to be used as the backing music for the scene.")] public AudioClip music;
}
