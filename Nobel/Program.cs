using System.Security.Cryptography.X509Certificates;

namespace Nobel
{
    internal class Program
    {
        static List<Nobeldij> nobeldijasok = new List<Nobeldij> ();
        static void Main(string[] args)
        {

            // 2. 

            StreamReader sr = new StreamReader(".\\DataSource\\nobel.csv");

            sr.ReadLine(); // fejléc sor beolvasása

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");

                Nobeldij adatsor = new Nobeldij(
                    int.Parse(line[0]),
                    line[1],
                    line[2],
                    line[3]
                    );

                nobeldijasok.Add(adatsor);
            }

            sr.Close();

            // 3. feladat 

            string arthurTipus =  nobeldijasok
                .Where(nobeldijas => nobeldijas.Keresztnev == "Arthur B." && nobeldijas.Vezeteknev == "McDonald")
                .Select(x => x.Tipus)
                .FirstOrDefault();

            Console.WriteLine($"3. feladat: {arthurTipus}");

            foreach (var nobeldijas in nobeldijasok)
            {
                if (nobeldijas.Keresztnev == "Arthur B." && nobeldijas.Vezeteknev == "McDonald")
                {
                    Console.WriteLine($"3. feladat: {nobeldijas.Tipus}");
                    break;
                }
            }

            // 4. feladat

            string irodalmi2017 =  nobeldijasok
                .Where(x => x.Evszam == 2017 && x.Tipus == "irodalmi")
                .Select (x => x.Keresztnev + " " + x.Vezeteknev)
                .FirstOrDefault ();

            Console.WriteLine($"4. feladat: {irodalmi2017 }");

            // 5. feladat

            Console.WriteLine("5. feladat:");

            List<Nobeldij> nobeldijasSzervezet = nobeldijasok
                .Where(x => x.Vezeteknev == "" && x.Evszam > 1990)
                .ToList ();

            nobeldijasSzervezet.ForEach (x => Console.WriteLine($"\t{x.Evszam} {x.Keresztnev}"));

            // 6. feladat

            Console.WriteLine("6. feladat:");

            List<Nobeldij> nobeldijasCuriek = nobeldijasok.Where(x => x.Vezeteknev.Contains("Curie")).ToList();

            nobeldijasCuriek.ForEach(x => Console.WriteLine($"\t{x.Evszam} {x.Keresztnev} {x.Vezeteknev}({x.Tipus})"));

            // 7. feladat

            Console.WriteLine("7. feladat:");

            var dijTipusok = nobeldijasok
                .GroupBy(x => x.Tipus)
                .Select(group => new
                {
                    Tipus = group.Key,
                    Darabszam = group.Count()
                });

            foreach (var dijTipus in dijTipusok)
            {
                Console.WriteLine($"\t{dijTipus.Tipus} {dijTipus.Darabszam}");
            }

            // 8. feladat

            List<Nobeldij> orvosiNobeldijasok =  nobeldijasok.Where(x => x.Tipus == "orvosi").OrderBy(x => x.Evszam).ToList();

            StreamWriter sw = new StreamWriter("orvosi.txt");

            foreach (var orvosinobeldijas in orvosiNobeldijasok)
            {
                sw.WriteLine($"{orvosinobeldijas.Evszam} ; {orvosinobeldijas.Keresztnev} {orvosinobeldijas.Vezeteknev}");
            }

            sw.Close();

            Console.WriteLine("8. feladat: orvosi.txt");

        }
    }
}