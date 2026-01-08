Overview:
This project is structured into separate tasks/modules, where each task contains its own README explaining its purpose, setup, and usage in detail.

📁 Project Structure:

  _Dev/
  Contains all development-related content:
    * Gameplay systems
    * Scripts
    * Managers
    * Scene logic
  👉 Scene to run: Assets/_Dev/Final
  This is the main and only required scene to run the project.
  
  _Art/
  Contains all art-related content:
    * Materials
    * Textures
    * Models
    * Baked lightmaps
    * Lighting and visual data
  This folder is data-only and does not contain gameplay logic.

📦 Task-Based Architecture
The project is divided into tasks/modules such as:
  * T_WM – Wave Manager
  * T_AI – Enemy AI
  * T_MH – Menu Handler
Each task:
  * Is self-contained
  * Has its own README
  * Can be understood independently
Interacts with other tasks through clear responsibilities

▶️ How to Run
  1- Open the project in Unity
  2- Load the scene: _Dev/Final
  3- Press Play

Notes:
  * All gameplay logic lives inside _Dev
  * All visuals and baked lighting live inside _Art
  * No additional setup is required beyond opening the Final scene
