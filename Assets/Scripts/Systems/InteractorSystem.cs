using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Interfaces;
using Atrabile.Singletons;
using Atrabile.ScriptableObjects;


namespace Atrabile.Systems {

[RequireComponent(typeof(InteractorArchetype))]
/// <summary> Handles interactables findings. </summary>
public sealed class InteractorSystem : System<InteractorArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const int MAX_COLLISION_COUNT = 32;

        private Vector3 root => this.archetype
            .collider
            .bounds
            .center - this.archetype
                .collider
                .bounds
                .extents
                .YConstraint();


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused)
                this.ScanInteractables();
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void ScanInteractables() {

            Collider[] colliders = new Collider[InteractorSystem.MAX_COLLISION_COUNT];
            int overlapCount = Physics.OverlapBoxNonAlloc(
                this.archetype.collider.bounds.center,
                this.archetype.collider.bounds.extents * 0.5f,
                colliders,
                this.transform.rotation,
                Generic.INTERACTABLE_LAYER_MASK,
                QueryTriggerInteraction.UseGlobal
            ); // OverlapBoxNonAlloc()


            if (this.archetype.data.interactables.Count > 0)
                this.archetype.data.interactables.Clear();


            this.archetype.data.currentAction.SetNone();
            for (int i = 0; i < overlapCount; i++)
                foreach (IInteractable interactable in colliders[i].GetComponents(typeof(IInteractable))) {

                    if (colliders[i].isTrigger) interactable.Interact();
                    else {

                        if (interactable.action.ActionType >= ((Interactable)this.archetype.data.currentAction).ActionType)
                            this.archetype.data.currentAction.SetSome(interactable.action);
                        
                        this.archetype
                            .data
                            .interactables
                            .Add(interactable);
                    } // if ..
                } // foreach ..
        } // void ..
}} // namespace ..
