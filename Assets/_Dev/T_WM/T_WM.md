T_WM: Wave Manager Task
    1- WavesDataObj: (Scriptable Object controlling how many enemies are per wavee)
        * Based on equation a + b * c
        * Where a is start value b is wave number and c is amount added between waves
        * Right click -> Create -> T_WM -> WavesData
        * Add the waves and put the parameters for each one and how many waves it will be applied on
        * Last wave values will automatically be applied on remaining

    2- WaveManager (WaveManager Script controlling everything wave related)
        * Reads wave data from WavesDataObj
        * Keeps track of:
            * Current wave number
            * Total enemies required for the wave
            * Currently spawned enemies
        * Spawns enemies in a circle around the WaveManager using spawnRadius
        * Enemies are spawned with a delay using spawnDelay
        * Automatically waits waveDelay seconds before starting the next wave
        * Uses object pooling to reuse enemies instead of instantiating every time
        * Randomly selects enemy type per spawn
        * Automatically starts the next wave when the current one finishes
        * Supports:
            * StartNextWave() → starts the next wave
            * StopWave() → pauses spawning
            * ResumeWave() → resumes spawning
            * DestroyWave() → disables all active enemies and resets counters
            * Draws a gizmo circle in the editor to visualize spawn area