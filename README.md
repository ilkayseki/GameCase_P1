# Proje Adı: Grid Oyun Projesi

## Proje Açıklaması
Bu proje, Unity kullanılarak oluşturulmuş bir grid oyunudur. Proje, iki bağımsız bölümden oluşan bir challenge'ın ilk kısmını kapsamaktadır. Bu kısımda, n x n'lik bir grid oluşturulmuş ve grid üzerindeki hücrelere tıklanıldığında X işaretleri eklenmiştir. Yatay veya dikey olarak komşu olan en az 3 X işareti oluştuğunda, bu X'ler yok edilmektedir. 

## Görev Tanımı
Bu proje, bir görev olarak verilmiş ve belirli gereksinimlere göre geliştirilmiştir. Aşağıda, görevde belirtilen istekler ve bu projede nasıl uygulandıkları açıklanmaktadır:

### Genel Gereksinimler
- **Unity Versiyonu:** Proje, Unity 2020.3.x veya 2021.3.x versiyonlarından biri kullanılarak geliştirilmiştir.
- **Versiyon Kontrol:** Proje en baştan itibaren git ile versiyonlanmış ve düzenli commitler gerçekleştirilmiştir.
- **Public Repository:** Proje, GitHub/Bitbucket gibi bir platforma public olarak yüklenmiştir.
- **Bonus Görevler:** İlgili bonus maddeleri uygulanmıştır.
- **SOLID Prensipleri:** Kodlar SOLID prensiplerine uygun olarak yazılmıştır.
- **Dependency Injection:** Herhangi bir Dependency Injection framework'ü kullanılmıştır (BONUS).
- **Kod Kalitesi:** Kod okunaklı ve belirli bir coding convention'a bağlı olarak yazılmıştır.

### Proje Gereksinimleri
1. **n x n'lik Grid:** Editör'de veya Runtime'da düzenlenebilir olan bir integer ("n") ile n x n'lik bir grid oluşturulmuştur.
2. **X İşareti Ekleme:** Grid üzerindeki herhangi bir hücreye dokunulduğunda ya da tıklandığında ilgili hücreye bir X işareti yerleştirilir.
3. **X'lerin Yok Edilmesi:** Oluşan X'lerden en az 3 tanesi birbirine yatay veya dikey olarak komşu hale geldiğinde ilgili X'ler yok edilir.
4. **Kazanma/Kaybetme Mekaniği:** Oyun bir kazanma ya da kaybetme mekaniğine sahip değildir.
5. **Ekrana Sığma:** Oluşturulan grid daima ekrana sığmalıdır.
6. **Canvas Kullanımı (BONUS):** Grid için canvas kullanılmamıştır.


## Özellikler
- **n x n'lik Grid:** Editör veya runtime'da belirlenebilen n değeri ile grid oluşturulabilir.
- **X İşareti Ekleme:** Grid üzerindeki herhangi bir hücreye tıklanıldığında o hücreye X işareti eklenir.
- **X'lerin Yok Edilmesi:** Yatay veya dikey olarak komşu olan en az 3 X işareti otomatik olarak yok edilir.
- **Ekrana Sığma:** Oluşturulan grid daima ekrana sığar.
- **Canvas Kullanılmaması (BONUS):** Grid, canvas kullanılmadan oluşturulmuştur.

## Bonus Özellikler
- **Dependency Injection:** Proje içerisinde Zenject kullanılmıştır.
- **SOLID Prensipleri:** Proje kodları SOLID prensiplerine uygun olarak yazılmıştır.

## Kullanılan Teknolojiler
- Unity 2021.3.x
- C#
- Git
- Zenject
- Textmesh Pro
