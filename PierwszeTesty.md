#Pierwsze testy

## Anatomia testu jednostkowego

* Stan przed
* Akcja
* Stan po

## System under test

## Uruchamianie przykładów 
```
calculator.exe & echo %errorlevel%
```
## MSTest

###Atrybuty

* TestClass - oznacza klasę zawirającą testy
* TestMethod - oznacza metodę testująca
* TestInitialize - kod wykonywany przed uruchumieniem każdej pojedynczej metody testowej w klasie
* ClassInitialize - kod wykonywany przed uruchumieniem pierwszej metody testowej w klasie
* AssemblyInitialize - kod wykonywany przed wykonaniem pierwszej metody testowj w assembly
* AssemblyCleanup - kod wykonywany po wykonaniu wszystkich metod testowych w assembly
* ClassCleanup - kod wykonywany po wykonaniu wszystkich metod testowych w klasie
* MethodCleanup - kod wykonywany po wykonaniu każdej pojedynczej metody testowek w klasie
* Ignore - Wymusza zignoranie testu / zestawu testów

###Asercje

* Assert
* CollectionAssert

## Inne frameworki

* Nunit

### Obiekty testowe - fakes

* Stub
* Mock
