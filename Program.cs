namespace DolgozatCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //2
            string path = "dolgozat.txt";
            var beolvasas = File.ReadAllLines(path).Skip(1);

            List<Dolgozat> dolgozatok = new List<Dolgozat>();

            foreach (var sor in beolvasas)
            {
                string[] elvalasztas = sor.Split(";");

                string nev = elvalasztas[0];
                int kor = int.Parse(elvalasztas[1]);
                int pontszam = int.Parse(elvalasztas[2]);

                dolgozatok.Add(new Dolgozat(nev, kor, pontszam));
            }
            
            //3a
            Console.WriteLine($"A tanulók száma: {dolgozatok.Count()}");

            //3b
            Dolgozat legjobb = dolgozatok.MaxBy(x => x.pontszam);
            Console.WriteLine($"A legjobb dolgozatot író tanuló: {legjobb.nev}, pontszáma: {legjobb.pontszam}");

            //3c
            int db = 0;
            int osszesen = 0;
            foreach (var item in dolgozatok)
            {
                osszesen += item.pontszam;
                db++;
            }
            double atlag = (double)osszesen / db;
            Console.WriteLine($"A tanulók átlaga {atlag:F1}");

            //3d
            int felett = 0;
            foreach (var item in dolgozatok)
            {
                if(item.pontszam >= 80)
                {
                    felett++;
                }
            }
            Console.WriteLine($"{felett} db tanuló ért el legalább 80 pontot");

            //3e
            bool vane = false;
            foreach (var item in dolgozatok)
            {
                if(item.nev == "Tóth Éva")
                {
                    vane = true;
                    break;
                }
            }
            Console.WriteLine($"Van a tanulók közt Tóth Éva? {(vane ? "Van" : "Nincs")}");

            //4
            Console.WriteLine();
            foreach (var item in dolgozatok)
            {
                Console.WriteLine($"{item.nev} pontszáma: {item.pontszam}, jegye:{item.erdemJegy()}");
            }

            //5
            string path2 = "jotanulok.txt";
            string tartalom = "Név;Pontszám\n";
            foreach (var item in dolgozatok)
            {
                if(item.pontszam >= 85)
                {
                    tartalom += $"{item.nev};{item.pontszam}\n";
                }
            }

            try
            {
                File.WriteAllText(path2, tartalom);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
    }
}
