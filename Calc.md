# Aplikacja Calc

Prosta aplikacja konsolowa nieużywająca standardowego wejścia/wyjścia.
Dane są przekazywane przez parametry natomiast wyniki zwracane są poprzez result code.

	Przykładowe wywołanie
	calc.exe & echo %errorlevel
Wymagania funcjonalne:
* Jeżeli pierwszy argument to słowo **sum** aplikacja powinna zwrócić sumę wszystkich kolejnych argumentów lub 0 gdy nie podano żadnych 
* Jeżeli pierwszy argument to słowo **product** aplikacja powinna zwócić iloczyn wszystkich kolejnych argumentów lub 1 gdy nie podano żadnych 
* Jeżeli pierwszy argument to słowo **aseq** aplikacja powinna:
	* zwócić 1 w przypadku gdy kolejne argumenty tworzą ciąg arytmetyczny
	* zwócić 0 gdy tak nie jest 
* Jeżeli pierwszy argument to słowo **ndec** aplikacja powinna:
	* zwócić 1 w przypadku gdy kolejne argumenty tworzą ciąg niemalejący
	* zwócić 0 gdy tak nie jest
* W każdym innym przypadku (tj. błędne dane, błędne wejście, itp) aplikacja powinna zrócić wartość **-2147483648**

[Żródła aplikacji](https://github.com/UAM-TTA-2015/Lab02/tree/master/kod)