# TestCase_RPG
# Karakter Yaratma
Case'de random 10 karakter yaratılır.
Bu karakterleri yaratma işlemi "HeroCreator" scriptinde sağlanır.
Karakterde olması gereken 3 özellik vardır.
Bunlar;şekil,renk ve size.
Bu veriler ScriptableObject'te tutulur.Her bir karakter startta 100 hp ve 10 ap puanına sahiptir.
Özelliklerine göre puanlamada değişiklikler olmaktadır. Bu değişikliklerde eklenilmesi gereken puanlar "ShapeData","SizeData"ve"ColorData" scripleri ile ScriptableObject'te tutulmuştur.
# Karakter Seçme 
3 tane karakter seçilir. Bu karakterleri seçme işlemi "HeroSelector" scriptinde yer almaktadır.Ve seçilen karakterin doğru sayıya erişimi "HeroSelectManager"scritinde kontrol edilmiştir. Seçilen 3 karakter hero prefabı ile yaratılır.Karttaki seçilen heroların bilgileri yaratılan herolara eşitlenir.Bir de enemy prefabı vardır. O da belirlenen pozisyonda yaratılır. Karakterlerin yaratılma işlemlerinin hepsi "HeroCreator"scriptinde tutulur.
# Karakter Atak ve Hasar
Seçilen üç karakter ve düşman hem atak yapabileği ve hem de hasar verebileceği için "IAttackable" ve "IDamageble" scritlerinde interface kullanılmıştır. Karakterlerde bu işlemleri zorunlu kılmak için bu şekilde oluşturulmuştur."HeroCombatAbility"scriptinde Attak ve hasar kontrol edilmiştir. "HeroCombat Controller"scriptinde ise karaketlerin gidecekleri pozisyonlar ve atak anı burada belirlenmiştir. 
# Karakter HP ve AP Kontrol
Tüm karakterlerin üzerinde "Hero" scripti bulunmaktadır.Karakterin özellikleri burada tutulur."HeroStats" scriptinde ise karakterin HP ve AP puanları tutulur. Bu verilen değiştirildiği yer "Health" scripti ve "IDamage" scriptidir.
# Oyun Sonuç
"GameManager" scriptinde oyun aşaması kontrol edilir. Düşman HP bittiyse oyun kazanılır. 3 hero HP bitti ise oyun kaybedilir.
NOT: ScriptableObject kullanmamın sebebi karakter sayısında değişiklik yapıldığında verilerin kolay bir şekilde değişmesini sağlamak ve ekstra karakter özelliği eklemeyi kolaylaştırmak için kullanılmıştır.

