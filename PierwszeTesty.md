# Pierwsze testy

## Kilka pojęć

### System under test (SUT)

Pod nazwą System Under Test (SUT) kryje się system (aplikacja), który testujemy. W szczególności dla testów jednostkowych będzie to pojedynczy fragment tego systemu, np. pojedyncza klasa.

### Asercja

Asercja jest to założenie które definiujemy w celu określenia warunków uznania danego testu za pozytywnie wykonany.
Przykładem może być np. założenie że wynik operacji dodawania na liczbach całkowitych 3 i 5 jest równy liczbie całkowitej 8.
Asercją może być również sprawdzenie czy nasz SUT wykonał spodziewaną metodę, przekazał jej odpowiednie parametry czy wyrzucił spodziewany wyjątek.

### Wzorzec AAA

Arrange-Act-Assert - wzorzec tworzenia testów definiujący trzy etapy testu:
* Arrange - gdzie konfigurujemy potrzebne zależności i tworzymy nasz SUT
* Act - gdzie wywołujemy nasz testowany fragment kodu (np. metodę czy właściwość)
* Assert - gdzie sprawdzamy czy wynik testu jest zgodny z oczekiwaniem

### Test jednostkowy

Jest to test który sprawdza jeden przypadek użycia naszego SUT. W przypadku kodu obiektowego jest to zwykle pojedyncza metoda danej klasy.
W takim przypadku do jednej metody możemy utworzyć kilka testów jednostkowych (możemy np. sprawdzić jak metoda zachowa się dla prawidłowych i nieprawidłowych parametrów).
Gdy nasz SUT jest testowany jednostkowo wszystkie zewnętrzne zależności są zastępowane obiektami zastępczymi - szczegóły w dalszej części prezentacji.

## Frameworki do testów - wprowadzenie

Na naszych zajęciach będziemy głównie korzystać z frameworka [NUnit](http://www.nunit.org/). Powstał on na bazie jUnit (a następnie xUnit) i został przeportowany z Javy na platformę .NET na początku jej istnienia.
Obecnie jest to jedna z najbardziej rozbudowanych i najczęściej używanych bibliotek do testowania na platformie .NET.

Ponadto w każdej standardowej instalacji Visual Studio mamy dostępny framework [MSTest](https://msdn.microsoft.com/en-us/library/hh598960.aspx).
Koncepcyjnie jest bardzo zbliżony do NUnit, jednak ze względu na silne związanie z Visual Studio jest nieco mniej uniwersalny niż NUnit.

Innym popularnym frameworkiem do testowania na platformie .NET jest [xUnit.net](http://xunit.github.io/).

### Odpalanie testów z poziomu Visual Studio

Do uruchamiania testów z poziomu Visual Studio możemy użyć standardowego narzędzia nazwanego Test Explorer. Pozwala ono na uruchamianie i debugowanie testów oraz analizę ich wyników.

Jeżeli korzystamy z frameworka NUnit to musimy zainstalować wtyczkę do Visual Studio (NUnit Test Adapter), która umożliwia współpracę pomiędzy NUnit i Test Explorerem.

Ponadto jeżeli posiadamy zainstalowane rozszerzenie [ReSharper firmy JetBrains](https://www.jetbrains.com/resharper/) możemy wygodnie odpalać testy z jego pomocą.
Dla studentów wtyczka ta jest udostępniana bezpłatnie - [szczegóły tutaj](https://www.jetbrains.com/student/).

## NUnit i MSTest - porównanie    

### Atrybuty

Poniżej znajduje się porównanie podstawowych atrybutów używanych przez NUnit i MSTest do oznaczania kluczowych komponentów zestawu testów:

| NUnit                 | MSTest             | Opis |
|-----------------------|--------------------|------|
| (brak 1) )            | AssemblyInitialize | Kod wykonywany przed wykonaniem pierwszej metody testowj w assembly |
| TestFixtureSetUp      | ClassInitialize    | kod wykonywany przed uruchumieniem pierwszej metody testowej w klasie kod wykonywany po wykonaniu wszystkich metod testowych w assembly|
| SetUp                 | TestInitialize     | Kod wykonywany przed uruchumieniem każdej pojedynczej metody testowej w klasie kod wykonywany po wykonaniu wszystkich metod testowych w assembly|
| TestFixture           | TestClass          | Oznacza klasę zawierającą testy |
| Test                  | TestMethod         | Oznacza metodę testująca |
| TearDown              | MethodCleanup      | Kod wykonywany po wykonaniu każdej pojedynczej metody testowek w klasie |
| TestFixtureTearDown   | ClassCleanup       | Kod wykonywany po wykonaniu wszystkich metod testowych w klasie |
| (brak 1) )            | AssemblyCleanup    | Kod wykonywany po wykonaniu wszystkich metod testowych w assembly |
| Ignore                | Ignore             | Wymusza zignoranie testu / zestawu testów |

1) Ta funkcjonalność jest rozwiązana w inny sposób w przypadku NUnit.

### Asercje

Poniżej znajduje się porównanie klas używanych do tworzenia asercji w NUnit i MSTest

| NUnit            | MSTest           | Opis |
|------------------|------------------|------|
| Assert           | Assert           | Klasa używana do budowania asercji         |
| StringAssert     | StringAssert     | Specjalny rodzaj asercji na ciągach znaków |
| CollectionAssert | CollectionAssert | Specjalny rodzaj asercji dla kolekcji      |
| FileAssert       | (brak)           | Specjalny rodzaj asercji na plikach        |
| DirectoryAssert  | (brak)           | Specjalny rodzaj asercji na katalogach     |

Należy zauważyć że asercje w NUnit są dużo bardziej rozbudowane. Dostępne są m.in.:
* Assert.Throws<T>() - pozwala na bardziej szczegółowe sprawdzanie wystąpień wyjątków
* Asert.That() - tzw. fluent API do budowania asercji

## Obiekty testowe - fakes / doubles

Gdy tworzymy testy jednostkowe wszelkie zależności, jakie posiada nasza klasa, powinniśmy podmienić na obiekty zastępcze (fake, double).
Pozwala to na oddzielenie naszego SUT od świata zewnętrznego i testowanie go w izolacji.
Dzięki temu mamy pewność, że wszelkie potencjalne błędy w zależnych klasach nie wpłyną na wynik testu naszego SUT.
Jeżeli nasz test kończy się porażką (failure) to oznacza, że mamy błąd w naszym SUT (albo w jego teście) a nie w innej części aplikacji.

### Typy obiektów zastępczych 

Wyróżniamy kilka typów obiektów zastępczych, w zależności od tego jak są zaimplementowane:
* *Dummy* - obiekt "zaślepkowy" który spełnia absolutne minimum (np. implementuje wymagane metody z interfejsu, które nic nie robią)
* *Stub* - obiekt "zalążek" który zawiera minimalną implementację, np. metoda zawsze zwraca ten sam wynik lub jest bardzo uproszczona logika
* *Mock* - najbardziej rozbudowana wersja obiektu zastępczego który testuje zachowania naszego SUT (np. czy metoda została wykonana, czy dostała odpowiednie parametry itp.) 

### Frameworki do tworzenia fake'ów

Oprócz samodzielnej implementacji obiektów zastępczych (co czasami może być czasochłonne) możemy posłużyć się jednym z wielu dostępnych frameworków które nas w tym wspomogą.
Do najpopularniejszych należą:
* [Moq](https://github.com/Moq/moq4)
* [FakeItEasy](http://fakeiteasy.github.io/)
* [Rhino Mocks](http://hibernatingrhinos.com/oss/rhino-mocks)
* [NSubstitute](http://nsubstitute.github.io/)
* [Microsoft Fakes](https://msdn.microsoft.com/en-us/library/hh549175.aspx)

Każdy z tych frameworków udostępnia rozbudowany zestaw narzędzi do tworzenia obiektów zastępczych.
W większości z nich możemy tworzyć obiekty typy dummy, stub i mock, zwykle w nie więcej niż kilku linijkach kodu.

Na naszych zajęciach będziemy głównie korzystać z frameworka FakeItEasy.
