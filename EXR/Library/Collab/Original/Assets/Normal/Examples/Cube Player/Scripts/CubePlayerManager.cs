using System;
using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples {
    public class CubePlayerManager : MonoBehaviour {
        private Realtime _realtime;
        public GameObject cube1;
        public GameObject cube2;
        public static int no_of_clients = 0;
        private void Awake() {
            // Get the Realtime component on this game object
            _realtime = GetComponent<Realtime>();
            cube1.SetActive(false);
            cube2.SetActive(false);
            // Notify us when Realtime successfully connects to the room
            _realtime.didConnectToRoom += DidConnectToRoom;
        }

        private void DidConnectToRoom(Realtime realtime)
        {
            no_of_clients = no_of_clients + 1;
            print("Connected"+no_of_clients);
            
            // Instantiate the CubePlayer for this client once we've successfully connected to the room
            Realtime.Instantiate("CubePlayer",                 // Prefab name
                                position: cube1.transform.position,          // Start 1 meter in the air
                                rotation: Quaternion.identity, // No rotation
                           ownedByClient: true,                // Make sure the RealtimeView on this prefab is owned by this client
                preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                             useInstance: realtime);           // Use the instance of Realtime that fired the didConnectToRoom event.
            
            if (no_of_clients == 1)
            {
                cube1.SetActive(true);
                print("yahan aaya");
            }
            else if (no_of_clients == 2)
            {
//                cube1.SetActive(false);
                cube2.SetActive(true);
                print("doosri baar aaaya");
            }
//            Realtime.Instantiate("Sphere",
//                position: Vector3.up,          // Start 1 meter in the air
//                rotation: Quaternion.identity, // No rotation
//                ownedByClient: true,                // Make sure the RealtimeView on this prefab is owned by this client
//                preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
//                useInstance: realtime);
//                
            
        }
    }
}
