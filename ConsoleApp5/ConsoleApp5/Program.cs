using System.Runtime.Intrinsics.X86;
using System.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> osvenyekLista = new List<string>();
            List<string> dobasokLista = new List<string>();

            StreamReader dobasokOlvasas = new StreamReader("dobasok.txt.txt");
            
            while (!dobasokOlvasas.EndOfStream)
            {

                dobasokLista.Add(dobasokOlvasas.ReadLine()) ;
            }
            dobasokOlvasas.Close();

            StreamReader osvenyekOlvasas = new StreamReader("osvenyek.txt.txt");
            
            while (!osvenyekOlvasas.EndOfStream)
            {

                osvenyekLista.Add(osvenyekOlvasas.ReadLine());
            }
            osvenyekOlvasas.Close();

            Console.WriteLine("2. feladat");
            Console.WriteLine($"A dobások száma: {dobasokLista.Count()}");
            Console.WriteLine($"Az ösvények száma: {osvenyekLista.Count()}");
            Console.WriteLine("3. feladat");
            string legHosszabbÖsvény = osvenyekLista[0];
            int sorSzam = -1;
            bool egyforma = false;

            for (int i = 0; i < osvenyekLista.Count; i++)
            {
                if (legHosszabbÖsvény.Length < osvenyekLista[i].Length)
                {
                    egyforma = false;
                    legHosszabbÖsvény = osvenyekLista[i];
                    sorSzam = i + 1;

                }
                else if (legHosszabbÖsvény.Length == osvenyekLista[i].Length && egyforma == false)
                {
                    egyforma = true;
                }


            }
            if (egyforma == true)
            {
                Console.WriteLine($"Az egyik leghosszabb a(z) {sorSzam}. ösvény, hossza: {legHosszabbÖsvény.Length}");
            }
            else
            {
                Console.WriteLine($"Az egyik leghosszabb a(z) {sorSzam}. ösvény, hossza: {legHosszabbÖsvény.Length}");
            }

            Console.WriteLine("4. feladat");
            Console.Write("Adja meg egy ösvény sorszámát! ");
            int bekertSorSzam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a játékosok számát!");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("5. feladat");

            string aktosv = osvenyekLista[bekertSorSzam - 1];

            char[] tipus = { 'M', 'V', 'E' };
            int[] tipusdb = new int[3];

            for (int i = 0; i < aktosv.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (aktosv[i] == tipus[j])
                    {
                        tipusdb[j]++;
                        break;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (tipusdb[i] > 0)
                {
                    Console.WriteLine($"{tipus[i]}: {tipusdb[i]} darab");
                }
            }



            Console.WriteLine("6. feladat");
            string fajlNev = "kulonleges.txt";

            
            using (StreamWriter fajl = new StreamWriter(fajlNev))
            {
                for (int i = 0; i < aktosv.Length; i++)
                {
                    if (osvenyekLista[i] != "M")
                    {
                       
                        fajl.WriteLine($"{i + 1}\t{aktosv[i]}");
                    }
                }
            }

            
            Console.WriteLine("A kiíratás és a szövegfájl lezárása sikeresen befejeződött.");

        }
    }
}