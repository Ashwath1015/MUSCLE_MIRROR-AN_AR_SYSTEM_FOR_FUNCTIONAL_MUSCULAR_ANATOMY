# 🧬 Muscle Mirror

### An Augmented Reality System for Functional Muscular Anatomy

**Muscle Mirror** is an Augmented Reality (AR) based interactive learning system designed to improve the understanding of human muscular anatomy through interactive 3D visualization, audio explanations, exercise animations, and real-time body tracking.

Traditional anatomy learning methods mainly rely on textbooks, static 2D images, and physical models. Muscle Mirror aims to provide a more interactive and immersive way to explore muscle placement, structure, and function.

---

## 📌 Project Overview

Understanding the human muscular system can be challenging when learning only from static diagrams or traditional physical models.

**Muscle Mirror** uses Augmented Reality to visualize anatomical muscle structures in an interactive environment. The system combines AR-based visualization with educational information and exercise-related content to provide an engaging learning experience.

The project is developed using **Unity 3D** and AR technologies, with real-time body tracking capabilities for interactive muscle visualization.

---

## ✨ Features

* 🥽 **Markerless Augmented Reality**

  * Detects surfaces using the device camera.
  * Allows 3D anatomical models to be placed in the real world.

* 💪 **3D Muscle Visualization**

  * Interactive visualization of human muscular anatomy.
  * Helps users understand the position and structure of muscles.

* 🔊 **Text & Audio Explanation**

  * Displays muscle names and anatomical information.
  * Provides audio pronunciation and explanations.

* 🏋️ **Exercise Animations**

  * Provides exercise-related animations associated with muscles.
  * Helps users understand the functional relationship between muscles and movements.

* 🧍 **Real-Time Body Overlay**

  * Uses pose estimation to track body joints.
  * Anatomical muscle models can follow the user's body movement.

* 📱 **Mobile AR Application**

  * Designed for mobile devices using Unity and AR frameworks.

* 🔒 **Privacy-Oriented Design**

  * Camera and pose processing are intended to be performed on-device.
  * The system does not require biometric data transmission.

---

## 🧠 Main Modules

The system is divided into five major modules:

### 1. Plane Detection

Detects horizontal or suitable surfaces through the device camera and AR tracking system.

### 2. Object Placement

Allows users to place and interact with 3D anatomical models within the detected environment.

### 3. Text & Audio Explanation

Provides information about muscles through visual labels, descriptions, and audio pronunciation/explanations.

### 4. Exercise Animation

Provides animated demonstrations related to selected muscles and exercises.

### 5. Real-Time Body Overlay

Uses pose estimation to identify body joints such as:

* Shoulders
* Elbows
* Hips
* Knees

The tracked joint positions are processed frame-by-frame to control the position, rotation, and scaling of anatomical models.

---

## 🛠️ Technologies Used

| Technology              | Purpose                                    |
| ----------------------- | ------------------------------------------ |
| **Unity 3D 2022.3 LTS** | Application development and 3D environment |
| **C#**                  | Application and interaction programming    |
| **AR Foundation 5**     | Cross-platform AR development              |
| **ARCore**              | Android AR support                         |
| **ARKit**               | iOS AR support                             |
| **MediaPipe BlazePose** | Real-time human pose estimation            |
| **FBX 3D Models**       | Rigged anatomical muscle models            |
| **Unity Canvas**        | User interface and information display     |

---

## 🏗️ Project Structure

The repository follows the standard Unity project structure:

```text
MUSCLE_MIRROR-AN_AR_SYSTEM_FOR_FUNCTIONAL_MUSCULAR_ANATOMY/
│
├── .utmp/
│
├── Assets/
│   └── Project assets, scenes, scripts, models,
│       audio, UI and other Unity resources
│
├── Packages/
│   └── Unity package and dependency configuration
│
├── ProjectSettings/
│   └── Unity project configuration and settings
│
├── .gitignore
│   └── Git ignored files and folders
│
├── .vsconfig
│   └── Visual Studio / development environment configuration
│
└── README.md
    └── Project documentation
```

> **Note:** Unity-specific content such as scenes, scripts, models, audio, prefabs, and UI assets are maintained inside the `Assets` directory.

---

## 🚀 Getting Started

### Prerequisites

Before opening the project, install:

* **Unity Hub**
* **Unity 2022.3 LTS**
* Android development support if building for Android
* A compatible AR-supported mobile device

For the best compatibility, use the Unity version specified by the project configuration.

---

## 📥 Installation

Clone the repository:

```bash
git clone https://github.com/ASHWATH009/MUSCLE_MIRROR-AN_AR_SYSTEM_FOR_FUNCTIONAL_MUSCULAR_ANATOMY.git
```

Navigate into the project directory:

```bash
cd MUSCLE_MIRROR-AN_AR_SYSTEM_FOR_FUNCTIONAL_MUSCULAR_ANATOMY
```

Open the project using **Unity Hub**.

### Using Unity Hub

1. Open **Unity Hub**.
2. Select **Add Project**.
3. Select the cloned project folder.
4. Open the project using the compatible Unity version.
5. Allow Unity to import and process the project assets.
6. Open the required scene from the `Assets` folder.
7. Build and run the application on a compatible AR device.

---

## 📱 Target Platform

The project is designed primarily as a **mobile AR application**.

### Android

The Android version uses:

* Unity
* AR Foundation
* Google ARCore

### iOS

The project architecture also supports:

* Unity
* AR Foundation
* Apple ARKit

Actual device compatibility depends on ARCore/ARKit support and the hardware capabilities of the target device.

---

## 🎮 How It Works

The basic workflow of Muscle Mirror is:

```text
        ┌──────────────────────┐
        │      Mobile Camera   │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │   AR Plane Detection │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │   3D Muscle Model    │
        │      Placement       │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │ Muscle Information   │
        │ Text + Audio         │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │ Exercise Animation   │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │  Pose Estimation     │
        │    Body Tracking     │
        └──────────┬───────────┘
                   │
                   ▼
        ┌──────────────────────┐
        │ Real-Time Muscle     │
        │      Overlay         │
        └──────────────────────┘
```

---

## 🎓 Educational Purpose

Muscle Mirror is intended to support learning and understanding of human muscular anatomy.

It can be useful for:

* Anatomy learning
* Fitness education
* Interactive classroom demonstrations
* Self-directed learning
* Understanding muscle locations
* Understanding the relationship between muscles and movement

---

## 📊 User Evaluation

The system was evaluated with **7 respondents** as part of the project study.

For the AR visualization effectiveness:

* **6 out of 7 respondents (85.7%)** gave a rating of **5/5**
* **1 out of 7 respondents (14.3%)** gave a rating of **4/5**
* No respondent gave a rating below 4/5

The evaluation focused on the usefulness of AR visualization for understanding muscular anatomy.

---

## 🔐 Privacy

The project is designed with privacy considerations in mind.

* Camera-based processing is intended for on-device operation.
* No biometric information is intended to be transmitted.
* The application is designed as an educational and fitness-awareness system.

---

## ⚠️ Disclaimer

Muscle Mirror is an **educational and fitness-awareness application**.

It is **not intended for**:

* Medical diagnosis
* Clinical assessment
* Disease detection
* Medical treatment
* Physiotherapy prescription

Exercise recommendations should be reviewed and validated by qualified fitness or healthcare professionals before being used for specific medical or rehabilitation purposes.

---

## 🔮 Future Enhancements

Possible future improvements include:

* Expanded muscle library
* Visualization of deeper and finer muscles
* Real-time muscle contraction and relaxation
* Multilingual audio support
* Physiotherapy and rehabilitation applications
* Optimization for low-end Android devices
* Interactive anatomy quizzes
* Cloud-based content updates
* Improved AR overlay on the user's own body
* User progress tracking
* Haptic feedback
* Muscle search and filtering
* User authentication and profiles
* Enhanced model rotation and zoom
* Collaborative learning features

---

## 📸 Screenshots & Demo

<img width="1045" height="611" alt="Screenshot 2026-01-05 100813" src="https://github.com/user-attachments/assets/fea761b1-3179-459a-9bee-021d13e4e42c" />
<img width="1045" height="611" alt="image" src="https://github.com/user-attachments/assets/c7eca011-2427-4309-b356-200845989833" />
<img width="1045" height="611" alt="image" src="https://github.com/user-attachments/assets/694c4728-25d2-440d-b1f8-a058b5a5c75d" />
<img width="1045" height="611" alt="image" src="https://github.com/user-attachments/assets/c8d06a1c-8f7c-4cb2-b2d8-030b0873569e" />
<img width="1045" height="611" alt="Screenshot 2026-04-26 132716" src="https://github.com/user-attachments/assets/990fcdfc-2437-48f6-a735-2e1b04de20eb" />

---

## 🎓 Academic Project

**Project:** Muscle Mirror – An Augmented Reality System for Functional Muscular Anatomy

**Degree:** Bachelor of Engineering – Computer Science and Engineering

**Institution:** Ramco Institute of Technology, Rajapalayam

**University:** Anna University, Chennai

---

## 📚 Project Documentation

The detailed project report contains the complete description of the system, methodology, implementation, evaluation, and future scope.

The report can be added to this repository as:

```text
MuscleMirror_Report.pdf
```

---

## 📄 License

This project was developed as an academic project.

Please contact the project authors before reusing or redistributing project assets, source code, 3D models, audio, or other project materials.

---

## 👨‍💻 Authors

**Ashwath V**
Computer Science and Engineering

---

⭐ If you find this project interesting, consider giving the repository a star!
