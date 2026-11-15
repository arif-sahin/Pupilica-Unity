# Unity'de Script Türleri ve Ne Zaman Kullanılır?

Unity'de yazdığımız her C# dosyası `MonoBehaviour` olmak zorunda değildir. Projen büyüdükçe doğru yerde doğru yapıyı seçmek kodun okunabilirliğini, performansını ve bakımını ciddi şekilde iyileştirir.

---

## 1. `MonoBehaviour` (Sahne Bileşenleri)
Unity'de en sık kullanılan script türüdür. Bir `GameObject` üzerine bileşen (Component) olarak eklenebilir.

- **Özellikleri:**
  - `Awake()`, `Start()`, `Update()`, `FixedUpdate()`, `OnTriggerEnter()` gibi Unity yaşam döngüsü (lifecycle) metotlarına sahiptir.
  - `Inspector` üzerinden değişkenleri (`[SerializeField]`) düzenlenebilir.
  - `transform`, `gameObject` gibi sahne referanslarına doğrudan erişir.
- **Ne Zaman Kullanılır?**
  - Sahnede fiziksel veya görsel bir karşılığı olan davranışlarda (Karakter kontrolü, Raycast ateşleme, Spawner, Kapı açma, UI buton kontrolü, Düşman AI).
- **Ne Zaman Kullanılmaz?**
  - Sadece veri tutan yapılar (ör. silah istatistikleri, envanter eşya tanımları) veya saf matematik/yardımcı fonksiyonlar için `MonoBehaviour` kullanmak gereksiz yük oluşturur.

---

## 2. `ScriptableObject` (Veri Kapları / Data Containers)
Sahnede bir `GameObject`'e bağlanmayan, doğrudan **Project (Assets)** klasöründe `.asset` dosyası olarak yaşayan veri şablonlarıdır. *(Bootcamp 7. Hafta konusu)*

- **Özellikleri:**
  - `new` ile veya sahneye sürükleyerek değil, `Create > ...` menüsüyle (`[CreateAssetMenu]`) asset olarak oluşturulur.
  - Oyun çalışırken değişmeyen veya paylaşılan verileri bellekte tek bir kopya olarak tutar (RAM dostudur).
  - Inspector'da düzenlenebilir.
- **Ne Zaman Kullanılır?**
  - Silah özellikleri (hasar, menzil, atış hızı), düşman veri kartları, envanter eşyaları (ItemData), seviye/dalga ayarları, ses/oyun konfigürasyonları.
  - Birden fazla objenin aynı veriyi paylaşması gerektiğinde.

---

## 3. Saf C# Sınıfı (`Plain C# Class` / `Struct`)
Hiçbir Unity sınıfından miras almayan (`: MonoBehaviour` yazmayan) standart C# sınıflarıdır.

- **Özellikleri:**
  - `new SinifAdi()` ile kod içinde oluşturulur.
  - Unity yaşam döngüsü (`Update`, `Start` vb.) yoktur; hafiftir.
  - `[System.Serializable]` attribute'u eklenirse bir `MonoBehaviour` veya `ScriptableObject` içinde Inspector'da görünebilir.
- **Ne Zaman Kullanılır?**
  - Envanterdeki bir slot verisi (`InventorySlot`), kayıt (Save) verisi, diyalog satırı, durum makinesi (State Machine) durumları, oyun içi hesaplama/algoritma sınıfları.

---

## 4. `Static` Sınıflar ve Yardımcı (Utility / Extension) Scriptler
Örneği (instance) oluşturulmayan, her yerden doğrudan `SinifAdi.MetotAdi()` şeklinde çağrılan yapılardır.

- **Özellikleri:**
  - Bellekte tek bir yerde durur, `new` ile üretilmez, sahneye eklenmez.
- **Ne Zaman Kullanılır?**
  - Sabitler (Layer isimleri, Tag isimleri, PlayerPrefs anahtarları).
  - Tekrar eden yardımcı hesaplamalar (ör. mesafe/açı yardımcıları, liste karıştırma `Shuffle` extension metotları).
- **Dikkat:** Oyun durumunu (ör. `Score`, `PlayerHealth`) her yere `static` olarak koymak ileride sahne geçişlerinde sıfırlama sorunlarına ve spagetti koda yol açar.

---

## 5. `Interface` (Arayüzler — Örn. `IDamageable`, `IInteractable`)
Bir davranış sözleşmesi tanımlar; içinde kod gövdesi değil, hangi metotların olması gerektiği yazar. *(Bootcamp 7. Hafta — Polimorfizm)*

- **Ne Zaman Kullanılır?**
  - Farklı türdeki objelerin aynı mesaja kendi yöntemleriyle tepki vermesini istediğinde.
  - Örnek: Raycast bir objeye çarptığında onun `Enemy` mi, `Crate` mi, `Target` mı olduğunu tek tek `GetComponent` ile sormak yerine; hepsine `IDamageable` arayüzü verip `hit.collider.GetComponent<IDamageable>()?.TakeDamage(10)` demek çok temiz bir mimari sağlar.

---

## 6. `Abstract Class` (Soyut Sınıflar)
Doğrudan sahneye eklenemeyen veya `new` yapılamayan, diğer sınıflara ortak temel (miras) sağlayan sınıflardır. *(Bootcamp 7. Hafta — Kalıtım)*

- **Ne Zaman Kullanılır?**
  - Birçok benzer scriptin ortak kodlarını tek yerde toplamak istediğinde.
  - Örnek: `BaseEnemy : MonoBehaviour` (can, hız, ölme mantığı ortak), bundan türeyen `MeleeEnemy : BaseEnemy` ve `RangedEnemy : BaseEnemy`.

---

## 7. `Editor` Scriptleri (`EditorWindow`, `CustomEditor`)
Sadece Unity Editor içinde çalışan, oyunun derlenmiş (Build) haline dahil edilmeyen geliştirici araçlarıdır.

- **Özellikleri:**
  - `UnityEditor` kütüphanesini kullanır.
  - Mutlaka `Assets/Editor/` klasörü altında (veya `#if UNITY_EDITOR` bloğu içinde) olmalıdır; yoksa Build alırken hata verir.
- **Ne Zaman Kullanılır?**
  - Inspector görünümünü özelleştirmek, seviye tasarımını hızlandıran özel editör pencereleri yapmak.

---

## Hızlı Karar Tablosu

| İhtiyacım Ne? | Hangi Yapıyı Seçmeliyim? |
| :--- | :--- |
| Sahnede hareket edecek, çarpışacak veya `Update` kullanacak | `MonoBehaviour` |
| Sabit ayarlar / eşya / düşman / silah verisi saklayacak | `ScriptableObject` |
| Sahneyle işi olmayan sade veri modeli / Save verisi | Saf C# `class` veya `struct` (`[Serializable]`) |
| Farklı objeler aynı eylemi (hasar alma, etkileşim) desteklesin | `Interface` (`IDamageable`, `IInteractable`) |
| Ortak özelliklere sahip alt türler (Düşman türleri, Silah türleri) | `abstract class` |
| Her yerden erişilen sabitler veya yardımcı matematik fonksiyonları | `static class` |
| Sadece Unity Editor içinde işimi kolaylaştıracak araç | `Editor` script (`Assets/Editor/`) |
