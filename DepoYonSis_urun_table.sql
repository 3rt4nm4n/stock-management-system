CREATE TABLE IF NOT EXISTS urun(
	stokkodu SERIAL PRIMARY KEY NOT NULL,
	tur VARCHAR(50) NOT NULL,
	malzemeadi VARCHAR(50) NOT NULL,
	barkod BIGINT NOT NULL,
	birim VARCHAR(50),
	adet INT,
	tedarikci VARCHAR(100)
);

INSERT INTO urun(tur,malzemeadi,barkod,birim,adet,tedarikci)
VALUES('Temizlik','Bulaşık Deterjanı',8754364251673778,'750 Ml',550,'Avansas'),
('Gıda','Türk Kahvesi',4555677214531923,'100 Gr',56,'Ünal Kuruyemiş'),
('Kırtasiye','Tükenmez Kalem',4649937505886045,'1 Tane',1000,'Avansas'),
('Kırtasiye','A4 Kağıt',5279906165952927,'80 Tane',100,'Yılmazlar Kırtasiye'),
('Gıda','Maden Suyu',3070372847250098,'200 Ml',240,'Sarıkaya Pazarlama'),
('Temizlik','Peçete',8180673173583725,'100 Tane',50,'Avansas');

SELECT * FROM urun ORDER BY stokkodu ASC;

