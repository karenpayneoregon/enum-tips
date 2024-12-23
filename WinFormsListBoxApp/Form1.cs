using Bogus;
using WinFormsListBoxApp.Classes;

namespace WinFormsListBoxApp;

public partial class Form1 : Form
{
    private string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "companies.txt");
    public Form1()
    {

        InitializeComponent();

        if (!File.Exists(_fileName))
        {
            File.WriteAllLines(_fileName, new List<string>()
            {
                "Microsoft",
                "Apple"
            });
        }

        listBox1.Items.LoadFromFile(_fileName);
        listBox1.SelectedIndex = 0;

    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        var f = new Faker();
        listBox1.Items.Add(f.Company.CompanyName());
        listBox1.Items.SaveToFile(_fileName);
        listBox1.SelectedIndex = listBox1.Items.Count - 1;
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        listBox1.Items.LoadFromFile(_fileName);
    }

    private void FreshStartButton_Click(object sender, EventArgs e)
    {
        
        listBox1.Items.Clear();

        File.WriteAllLines(_fileName, new List<string>()
        {
            "Microsoft",
            "Apple"
        });

        listBox1.Items.LoadFromFile(_fileName);
        listBox1.SelectedIndex = 0;

    }
}