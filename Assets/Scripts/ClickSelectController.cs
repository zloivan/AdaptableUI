using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class ClickSelectController : MonoBehaviour
 {
 
     [SerializeField] private Camera mainCamera;
 
     public static event Action<Entity> OnSelectedEntityChanged;
 
     public static Entity SelectedEntity { get; private set; }
 
     // Update is called once per frame
     void Update()
     {
         if (Input.GetButtonDown("Fire1"))
         {
             var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

             Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);

             if (Physics.Raycast(ray, out var hitInfo))
             {
                 var newEntity = hitInfo.collider.GetComponent<Entity>();
                 SelectedEntity = newEntity;

                 OnSelectedEntityChanged?.Invoke(newEntity);
             }
         }

         if (Input.GetKeyDown(KeyCode.Escape))
         {
             SelectedEntity = null;
             OnSelectedEntityChanged?.Invoke(null);
         }

         if (Input.GetKeyDown(KeyCode.A) && SelectedEntity != null)
         {
             SelectedEntity.TakeDamage(10);
         }
     }

     private void Start()
     {
         OnSelectedEntityChanged += OnOnSelectedEntityChangedHandler;
     }

     private void OnOnSelectedEntityChangedHandler(Entity obj)
     {
        
             if (SelectedEntity != null)
             {
                 if (Debug.isDebugBuild) Debug.Log($"<color=purple>Selected: {SelectedEntity.gameObject.name}</color>");
             }
             else
             {
                 if (Debug.isDebugBuild) Debug.Log("<color=purple>Nothing is selected</color>");
             }
     }
 }