T_AI: AI Task
    1- EnemyBehaviour (Base abstract class for all enemy AI)
        * Controls enemy movement, targeting, and attack logic
        * Uses NavMeshAgent for pathfinding
        * Automatically starts logic when enabled
        * Finds nearest valid target based on EnemyType
        * Stops and attacks when reaching stopping distance
        * Applies damage to target every ShootDelay seconds
        * Disables itself if no valid target is found
        * All enemy types inherit from this class
    2- Enemy Types (RedAI, GreenAI, BlueAI) (Specific enemy behaviors)
        * Each enemy sets its own EnemyType in Awake()
        * Inherit all movement and attack logic from EnemyBehaviour
        * Used to differentiate which targets they can attack
    3- EnemySelector (Controls which enemy type is active per spawn)
        * Holds all enemy behaviour variants under one prefab
        * Activates only the selected enemy type
        * Assigns nearest valid target when activating an enemy
        * Automatically disables itself after a random lifetime
        * Works with WaveManager object pooling
    4- EnemyTarget (Target that enemies can attack)
        * Holds health and UI health bar
        * Registers itself automatically in TargetHolder
        * Supports multiple enemy types attacking the same target
        * Takes damage and disables itself when health reaches zero
        * Automatically unregisters when disabled
    5- TargetHolder (Global target manager)
        * Singleton that keeps track of all active targets
        * Provides nearest target lookup based on enemy type
        * Ensures enemies always pick the closest valid target
        * Automatically updated as targets enable/disable