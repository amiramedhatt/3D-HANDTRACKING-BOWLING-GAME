# 3D Live Bowling Game with Hand Tracking

A real-time 3D bowling game built in **Unity**, powered by **Python + MediaPipe** for hand tracking, and connected via **UDP** for low-latency communication. The game allows players to control interactions using natural hand gestures instead of traditional input devices.

---
## Game Assets
Bowling Club Asset:
https://skfb.ly/oPoAC
## Video Demo & Download Game
https://drive.google.com/drive/folders/1zi7_qJDGjR55wqXR1r35WsD_TuLcWH5Y?usp=drive_link


## How to Run

### Requirements
- Python 3.8+
- A webcam (built-in or external)

### Install Dependencies
```
pip install mediapipe cvzone opencv-python
```

### Steps
1. Run `python main.py` in your terminal
2. Open the `3D HANDTRACKING BOWLING GAME` folder
3. Run `HCIFINALPROJECT.exe`
## Features

- Real-time hand tracking using MediaPipe
- Gesture-based control (no keyboard/mouse required)
- 3D bowling gameplay built in Unity
- 3 rounds per game, 2 attempts per round
- Live score tracking system
- Communication using UDP
- Smooth real-time data transfer between Python and Unity

---
## Tech Stack

- **Unity** – 3D game engine and rendering
- **C# (Unity scripting)** – game logic
- **Python** – hand tracking pipeline
- **MediaPipe** – real-time hand landmark detection
- **UDP Sockets** – fast communication between Python and Unity

---

## System Architecture

1. Camera captures real-time hand movement
2. Python processes frames using MediaPipe
3. Hand landmarks are extracted and converted into game controls
4. Data is sent to Unity via UDP
5. Unity updates player actions in real-time

---

## Gameplay

- The game consists of **3 rounds**
- Each round allows **2 attempts**
- Player scores are updated instantly after each throw
- The goal is to knock down as many pins as possible using hand gestures
