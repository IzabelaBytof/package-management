Aplikacja konsolowa, która umożliwia procesowanie zamówienia.
Zamówienie może posiadać jeden z 6 statusów:
1.	Nowe
2.	W magazynie
3.	W wysyłce
4.	Zwrócono do klienta
5.	Błąd
6.	Zamknięte

   
Aplikacja powinna umożliwiać 5 operacji: 
1.	Utworzenie przykładowego zamówienia
2.	Przekazanie zamówienia do magazynu
3.	Przekazanie zamówienia do wysyłki
4.	Przegląd zamówień
5.	Wyjście

   
Zamówienie składa się co najmniej z właściwości: 
•	kwota zamówienia
•	nazwa produktu
•	typ klienta (firma, osoba fizyczna)
•	adres dostawy
•	sposób płatności (karta, gotówka przy odbiorze)


Warunki biznesowe:
•	Zamówienia za nie mniej niż 2500 z płatnością gotówką przy odbiorze powinny zostać zwrócone do klienta przy próbie przekazania do magazynu.
•	Zamówienia przekazane do wysyłki powinny po co najwyżej 5 sekundach zmienić status na „wysłane”.
•	Zamówienia bez adresu wysyłki powinny kończyć się błędem.
