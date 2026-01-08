T_MH: Menu Handler Task
   1- FPSReader (FPS display handler)
        * Displays real-time FPS using TextMeshPro
        * Uses Time.unscaledDeltaTime to calculate accurate FPS
        * Smooths FPS value to avoid flickering
        * Updates FPS text every 0.1 seconds
        * Automatically gets TMP_Text component on the same GameObject
    2- MenuHandler (Main UI controller for wave system)
        * Controls all UI buttons related to wave management
        * Displays:
            * Current wave number
            * Total enemy count
        * Handles wave flow through UI buttons:
            * Start → starts the first wave
            * Stop → pauses enemy spawning
            * Resume → resumes enemy spawning
            * Next Wave → manually starts the next wave
            * Destroy Wave → disables all enemies and resets wave state
        * Automatically enables/disables buttons based on wave state
        * Keeps UI values updated in real time
        * Communicates directly with WaveManager