#### This stock management system was made in C# for the company I worked for during my internship. 
#### First of all it is fully made in C# & XAML and database was run on PostgreSQL.

#### Since it is in Turkish, I will provide translations of everything and a guide in English.

# User Guide in English

![AnaEkranDepoYönSis](https://user-images.githubusercontent.com/46112568/129474279-e4d291b8-e8ff-4908-938b-b397fe875a03.png)

* MainWindow has a data grid which imports data from the PostgreSQL database using the query below: 
```
SELECT * FROM urun ORDER BY stokkodu ASC;
```
* Above the data grid there is a button which can actually be considered as a simple enterprise resource planning (ERP) widget.

![canesisvar](https://user-images.githubusercontent.com/46112568/129474483-3dc0a47c-f115-4205-99ad-218cf66d5a18.png)

* The label on this button changes to "Bildiriminiz Var (You have notifications)" if there are products with number less than 10 or equal to zero, this happens by using the query below:
```
SELECT CASE WHEN EXISTS (SELECT malzemeadi FROM urun WHERE adet=0 OR adet<10) THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END;
```
![popup](https://user-images.githubusercontent.com/46112568/129474414-86623485-0010-46d1-a480-f5ce652a1e94.png)

* The button will pop up a new window which tells which products decreased below 10 or ran out. These will be written into a text file and will be shown on the textblocks by reading from them. 
* The decreased products will be shown by the following query:
```
SELECT malzemeadi FROM urun WHERE adet<10 and adet>0;
```
* The products that ran out will be shown by the following query:
```
SELECT malzemeadi FROM urun WHERE adet=0;
```
![depoyon](https://user-images.githubusercontent.com/46112568/129474505-7ea879e0-e677-42c0-a53d-efec7e6dae88.png)

* Stock management page is similar to Main Window. This window includes two buttons "Depo Çıkış (Check In / Disposal from Stock)" and "Depo Giriş (Adding to Stock)". There is also a chart from Live Charts which is supposesed to show a graph about products and their numbers. 

![giris](https://user-images.githubusercontent.com/46112568/129474609-545a6ab9-eb5e-4738-8fe9-bb37a999e913.png)

* Depo Girişi Window is where you add products to the stock. You are actually suppossed to use a barcode scanner in this window that is why it focuses on barcode textbox, but you can type the barcode as well. Then when you press "Enter" or Search icon on the right, the program will run the following query which searches the barcode in the database:
```
SELECT CASE WHEN EXISTS (SELECT * FROM urun WHERE barkod=<searched_barcode>) THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END;
```

![newprod](https://user-images.githubusercontent.com/46112568/129474977-765a3b8b-761c-4358-ab41-c70c0650a36c.png)

* If it returns false the program will pop up a message box that says "Yeni ürün bulundu (New product found)", then you will have to fill the textboxes and editable comboboxes about the products. And product will be added to the database.
```
INSERT INTO urun(tur,malzemeadi,barkod,birim,adet,tedarikci) VALUES() WHERE <searched_barcode>;
```

![exisprod](https://user-images.githubusercontent.com/46112568/129475009-28e0b50a-8030-41c5-a804-b56e0e523311.png)

![filled](https://user-images.githubusercontent.com/46112568/129475015-9d8e0203-8633-43f6-afe1-5d761a648f9a.png)

* If the query returns true the program will fill the blank boxes by itself, then all you have to do will be to type in the number of products.
* After that the number of the product will be incremented.
```
UPDATE urun SET adet = adet + <number_of_products> WHERE barkod=<searched_barcode>;
```
* Then if you click the button on the left "Kaydet ve Devam Et (Save and Continue)" it will save and empty boxes to add new products.
* If you click the button in the middle "Kaydet (Save)" it will save and close the window.
* If you click the button on the right "İptal (Cancel)" it will cancel and close the window.

![azalt](https://user-images.githubusercontent.com/46112568/129475164-db12a392-a0c8-40c6-8eb0-7e3b2b3f23c2.png)

 * Depo Çıkış Window is where you exit or in other words decrement the number of products from the stock. Just like the previous window it will focus on barcode textbox first. If you perform a search it will search the database with the barcode you entered. 
 
![cant](https://user-images.githubusercontent.com/46112568/129475219-8364a161-c9c6-4abb-9836-ab0d65a98103.png)

* If search returns false, the barcode cannot be found then it will pop up a message box that says "Ürün bulunamadı (Product could not be found)". If the product is found it will fill the blanks and the number of products you input will be decremented from the number of products in database *only if the number of products is greater than zero* 
* So the query below must return false in order for you to decrement:
````
SELECT CASE WHEN EXISTS(SELECT * FROM urun WHERE adet<>0) THEN CAST (1 AS BIT) ELSE CAST(0 AS BIT) END
````
* Decrementing is performed using the query below:
````
UPDATE urun SET adet = adet - <number_of_products> WHERE barkod=<searched_barcode> AND adet>0;
````

![envyon](https://user-images.githubusercontent.com/46112568/129475570-a13b464f-2e70-4fb6-82a7-00332db934a4.png)

* Envanter Yönetimi means Inventory Management. In this window the user can perform Update and Delete functions. Again when you open the window it will focus on barcode textbox. 
* If you search an existing barcode it will fill the blanks it self. 
* If you change the textboxes and click "Güncelle (Update)" it will change the value in the database. 
* If you click "Sil (Delete)" button it will delete the found row with the searched barcode.


## ----Translation of MainWindow----
* Anasayfa=MainWindow
* Depo Yönetimi=Stock Management
* Envanter Yönetimi=Inventory Management

* Stokkodu=Stock id
* Tur=Type
* Malzemeadi=Name of the product
* Barkod=Barcode
* Birim=Unit
* Adet=Number of product
* Tedarikci=Supplier

* Bildiriminiz yok=You do not have a notification
* Bildiriminiz var=You have a notification

## ----Translation of Stock Management Window----
* Depo Girişi=Adding to Stock
* Depo Çıkışı=Disposal from Stock
* Stokkodu=Stock id
* Tur=Type
* Malzemeadi=Name of the product
* Barkod=Barcode
* Birim=Unit
* Adet=Number of product
* Tedarikci=Supplier

  ### ->Translation of Adding to Stock Window<-
  * Tür=Type of the product
  * Malzeme Adı=Name of the product
  * Barkod=Barcode
  * Birim=Unit of the product
  * Adet=Number of the product
  * Tedarikçi=Supplier
  * Kaydet ve Devam Et=Save and Continue
  * Kaydet=Continue
  * İptal=Cancel
  
  ### ->Translation of Disposal from stock<-
  * Tür=Type of the product
  * Malzeme Adı=Name of the product
  * Barkod=Barcode
  * Birim=Unit of the product
  * Adet=Number of the product
  * Tedarikçi=Supplier
  * Azalt ve Devam Et=Decrement and Continue
  * Azalt=Decrement
  * İptal=Cancel


## ----Translation of Inventory Management Window----
* Ürün türü=Type of the product
* Ürün adı=Name of the product
* Barkod=Barcode
* Ürün birimi=Unit of the product
* Tedarikçi=Supplier

* Bul=Find
* Güncelle=Update
* Sil=Delete
