Aufgabenstellung:

Parameterbestimmung

Erstellen Sie ein Programm, das diese Populationsdynamik modellieren kann (Lösung eines DGL-Systems). Weiterhin soll mit einem genetischen Algorithmus (GA) eine Parameterbestimmung durchgeführt werden, sodass diejenigen Parameterwerte des DGL-Systems gefunden werden, sodass die DGL-Lösungen die Messdaten optimal beschreiben. Weiterhin sollen die Verläufe der Prozessgrößen dargestellt und diese sowie die Parameterwerte interpretiert werden.
Insgesamt können sie sich hierbei viele Programmbausteine aus unseren Übungsaufgaben holen, aber es wird auch Dinge geben, die sich selbst erarbeiten müssen! (Internet, Literatur etc.)
Es soll ein GA mit folgenden Einstellungen bzw. Eigenschaften verwendet werden:
 Optimierungskriterium ist die Fehlerquadratsumme (FQS) zwischen den Werten aus dem Datensatz und den DGL-Lösungen (zusammengesetzte FQS aus der Addition von 2 Teil-FQS (Hase und Luchs))
 mindestens 50 Generation (evtl. mehr)
 mindestens 500 Individuen (evtl. mehr)
 Optional: Das beste Individuum soll anschließend mit dem Simplex-Algorithmus „fertig optimiert“ werden. Hierzu müssten Sie, zusätzlich zum GA, natürlich einen Simplex-Algorithmus programmieren. Ob sie dies wirklich tun wollen, überlasse ich Ihnen.
 Der GA ist in einer eigenen Klasse programmiert und i.W. derjenige, der zur Lösung der String-Aufgabe schon verwendet wurde. Sie nutzen Ihre schon begonnene Individuen-Klassenhierarchie, um ein double-Array-Individuum hinzuzufügen und passen die GA-Klasse entsprechend an. Die Fitnessfunktion (= Berechnung der DGL-Lösung basierend auf dem Genom eines Individuums + Berechnung der FQS) ist weder in der GA-Klasse noch in einer der Individuen-Klassen codiert, sondern wird über einen Delegate abgehandelt.
 Wie genau Sie Selektion, Crossover, Mutation und weitere Schritte implementieren, überlasse ich Ihnen.
 Wenn man den Parameterraum nicht einschränkt, kann es passieren, dass die Parameteroptimierung nicht gelingt
o sie dürfen davon ausgehen, dass alle 6 Parameterwerte positiv und größer als 0.1 sind
o ferner dürfen sie annehmen, dass a, b, d und r kleiner als 5 sind, sowie c kleiner als 60 und k kleiner als 150 ist
o sie brauchen also im Code eine Möglichkeit diese Einschränkung ihrem GA mitzuteilen (und die dann auch beim Erstellen der Startpopulation und bspw. bei der Mutation Beachtung findet)
 führen sie den GA in einer for-Schleife mindestens 5 Mal aus und speichern sie von den erhaltenen Fehlerquadratsummen (FQS) nur

Diagramm

Fertigen Sie ein Diagramm an, in dem Folgendes dargestellt ist:
1. Die Messwerte (Punkte, nicht verbunden, 2 verschiedene Farben) und die Lösungen des DGL-Systems mit den optimalen Parameterwerten (durchgezogene Linien, passende Farben) werden in 1 Koordinatensystem gegen die Zeit aufgetragen.
2. In einem 2. Koordinatensystem werden die Lösungen H(t) und L(t) des DGL-Systems gegeneinander aufgetragen. Sie können selbst wählen, ob sie H(t) auf der x-Achse gegen L(t) auf der y-Achse auftragen, oder anders herum. KEINE Achse enthält die Zeit! Die Zeit ist IN der sich ergebenden Kurve. Zeichnen Sie zur Klarheit, wo t0 ist, einen andersfarbigen Punkt an H(0)/L(0) ein.
Idealerweise stellen sie beide Koordinatensysteme nebeneinander dar, sodass man beide Ansichten auf die Daten und Lösungen gemeinsam vorliegen hat.
Die 2. Darstellung trägt den Namen Phasenebene. Mit dieser Darstellung kann man bestimmte Eigenschaften dynamischer Modelle, insbesondere Oszillationen, besser analysieren.
Achten Sie auf wissenschaftlich sinnvolle Beschriftungen der Achsen sowie der Legende.
Dieses Diagramm dient ihnen auch während der Entwicklung ihrer Programme als Kontrolle:
 Klappt die Parameteroptimierung?
 Liegen die Lösungen wenigstens in der Nähe der Messdaten?
 Muss man ggf. mehr Individuen/Generationen verwenden?

Hinweise

 Tasten sie sich langsam vorwärts! Nicht gleich ein Programm mit zig Individuen und Generationen schreiben und sofort starten. Nachher läuft das 3 Tage und in ihrem Code, der die Ergebnisse speichern bzw. darstellen soll, ist ein Fehler und dann stürzt das ab! Machen Sie zunächst Mini-Durchgänge als "proof-of-concept".
 Ihr Programm stürzt trotz sorgfältiger Programmierung ab? Nutzen Sie Haltepunkte und Debugging, um die Ursache dafür zu finden! Überlegen Sie dann eine Lösungsstrategie, um das Problem zu verhindern!
 Das Programm läuft und es sind mehrfache GAs mit vielen Individuen und Generationen gerechnet worden, aber extrem überzeugend passen die DGL-Lösungen nicht zu den Messdaten? Wenn es wirklich wie Kraut und Rüben aussieht und die Lösungen noch nicht einmal prinzipiell die Dynamik und die zyklischen Schwankungen der Populationen widerspiegeln, haben Sie in der Tat etwas falsch gemacht. Ansonsten überlegen Sie selbst: Woran mag es liegen, dass die Messdaten nicht absolut exakt beschrieben werden können?
 Stellen Sie, zusätzlich zu dem oben beschriebenen Diagramm, die optimalen Parameter in einer Tabelle dar. Beschreiben und interpretieren Sie sowohl die Parameterwerte als auch die im Diagramm dargestellten Daten!