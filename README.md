# saga-pattern
order-service
payment-service
inventory-service

bu 3 servisler arasında orkestrasyon saga pattern ile bağlantı oluşturuldu. 
order-service içerisinde çalışan api ile sipariş oluşturulduğunda payment servisi için kuyruğa mesaj bırakılır.
payment-service ödemesi (dummy) olduğunda order-servisine işlemin durumunu bildirmek için kuyruğa mesaj bırakır.
order-service payment-service ten aldığı ödeme durumuna göre inventory-service kuyruğuna stok azaltmak için mesaj bırakır.
