# Pupilica Unity Bootcamp — Hands-On Çalışmalar

Bu repo, Unity Oyun Geliştirme Bootcamp süresince yapılan haftalık ödevleri ve pratik uygulamaları içerir.

## Proje Yapısı

Ana Unity projesi [`Bootcamp3D/`](./Bootcamp3D) klasörü altındadır. Her ödev kendi klasörü ve sahnesi (`Scene`) ile izole edilmiştir:

- **Ödev 1 — Raycast Hedef Vurma (`Bootcamp3D/Assets/Odev1_raycast`)**
  - Fare tıklaması ile `Camera.main.ScreenPointToRay` üzerinden `Physics.Raycast` atılır.
  - `TargetSpawner` ile belirli aralıklarla rastgele hedefler üretilir; süre içinde vurulmazsa kendiliğinden yok olur.
  - Vurulan hedefler yok edilir ve skor artırılır.

- **Ödev 2 — Karakter Yürütme & Animasyon (`Bootcamp3D/Assets/Odev2_animasyon`)**
  - Yeni Input System (`WASD` + `Space`) ile 3D kurt karakterinin `Plane` üzerinde hareketi ve `Quaternion.Slerp` ile yönelimi sağlanır.
  - `Animator Controller` (`IsMoving` bool & `Jump` trigger) ile `Idle`, `Run` (`Take 001`) ve manuel keyframe ile oluşturulan `WolfJump` animasyonları arasında geçiş yapılır.
