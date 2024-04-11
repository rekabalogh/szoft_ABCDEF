using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace Adatkotes
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new();
        public Form1()
        {
            InitializeComponent();
            countryDataBindingSource.DataSource = countryList;
            dataGridView1.DataSource = countryDataBindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("european_countries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var t�mb = csv.GetRecords<CountryData>();
            foreach (var item in t�mb)
            {
                countryList.Add(item);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            countryDataBindingSource.RemoveCurrent();
        }
    }
}