namespace Hajos_teszt
{
    public partial class Form1 : Form
    {
        List<Kerdes> OsszesKerdesek;
        List<Kerdes> AktivKerdesek;

        int AktivKerdes = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void KerdesBeolvasas()
        { List<Kerdes> kerdesek = new List<Kerdes>();
            StreamReader sr = new StreamReader("text.txt");

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine() ?? string.Empty;
                string[] tomb = sor.Split("\t");
                if (tomb.Length != 7) continue;
                Kerdes k = new Kerdes();
                k.KérdésSzöveg = tomb[1];
                k.Válasz1 = tomb[2];
                k.Válasz2 = tomb[3];
                k.Válasz3 = tomb[4];
                k.URL = tomb[5];

                int.TryParse(tomb[6], out int jóválasz);

                k.HelyesVálasz = jóválasz;

                kerdesek.Add(k);
            }
           sr.Colse();
           return kerdesek;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AktivKerdesek = new List<Kerdes>();
            OsszesKerdes = KerdesBeolvasas();
            for (int i = 0; i < 7; i++)
            {
                AktivKerdesek.Add(OsszesKerdes[0]);
                OsszesKerdes.RemoveAt(0);
            }
        }
    }
}