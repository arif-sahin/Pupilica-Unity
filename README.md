# Pupilica Unity Bootcamp — Hands-On Çalışmalar

Bu repo, Unity Oyun Geliştirme Bootcamp süresince yapılan haftalık ödevleri ve pratik uygulamaları içerir.

## Proje Yapısı

Ana Unity projesi [`Bootcamp3D/`](./Bootcamp3D) klasörü altındadır. Her ödev kendi klasörü ve sahnesi (`Scene`) ile izole edilmiştir:

- **Ödev 1 — Raycast Hedef Vurma (`Bootcamp3D/Assets/Odev1_raycast`)**
  - Fare tıklaması ile `Camera.main.ScreenPointToRay` üzerinden `Physics.Raycast` atılır.
  - `TargetSpawner` ile belirli aralıklarla rastgele hedefler üretilir; süre içinde vurulmazsa kendiliğinden yok olur.
  - Vurulan hedefler yok edilir ve skor artırılır.

## Notlar

- [Unity_Script_Turleri.md](./Unity_Script_Turleri.md): Unity'de `MonoBehaviour`, `ScriptableObject`, saf C# sınıfları, `Interface` ve `Abstract Class` kullanım rehberi.
