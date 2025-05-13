# 🎤 MicMouth

> Your mouth moves when you speak.  

---

## ✨ Features

- 🎙️ Lip animation reacts to real-time microphone input
- 🎛️ Smooth mouth opening with rotation and vertical motion
- 🪟 Frameless, transparent overlay window
- 🖱️ Click-and-drag anywhere to move the window
- ⛅ Runs even in background (when not focused)
- ⌨️ Toggle border on/off with the ESC key

---

## 🚀 Getting Started

### Requirements
- Windows 10/11 (tested)
---

## 🛠 Technical Overview

- Unity (URP) + C#
- Native Windows APIs via `user32.dll`
  - `SetWindowLong`, `SetWindowPos`
  - `SetLayeredWindowAttributes` for transparency
  - `SendMessage` for drag-to-move window behavior

---

## 💡 Use Cases

- VTuber overlay
- Visual mic feedback for streaming
- OBS webcam alternative
- Talk-reactive avatars for chat or games

---

## 📄 License

MIT License  
Feel free to fork it, mod it, or make your own weird talking overlay.

-------------------------------------------------------

# 🎤 MicMouth

> 말하면 입이 벌어집니다. 

---

## ✨ Features

- 🎙️ 마이크 소리에 따라 입이 위아래로 벌어짐
- 🌀 입이 기울어지며 말하는 듯한 애니메이션
- 🪟 테두리 없는 투명 오버레이 창 (Always On Top)
- 🖱️ 마우스로 자유롭게 드래그 가능
- ⛅ 백그라운드에서도 실행 유지
- 🧪 ESC 키로 테두리 ON/OFF 토글

---

## 🚀 Getting Started

### Requirements
- Windows (테스트됨)
---

## 🛠 기술 개요

- Unity URP + C#
- WinAPI (`user32.dll`) 직접 호출
  - `SetWindowLong`, `SetWindowPos`
  - `SetLayeredWindowAttributes`로 투명 창 구현
  - `SendMessage`로 창 드래그 기능 추가

---

## 💡 아이디어

- OBS로 입 모양 연출용
- VTuber 오버레이
- 방송 중 마이크 반응 시각화
- 말할 때 반응하는 채팅 캐릭터 구현용

---

## 📄 License

MIT License  
*Feel free to fork, modify, and make your own weird talking mouth.*

---
