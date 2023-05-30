using EnumGetDescriptions.Classes;
using EnumGetDescriptions.Models;

namespace EnumGetDescriptions;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Shown += OnShown;
    }

    private void OnShown(object? sender, EventArgs e)
    {
        categoriesComboBox.DataSource = EnumHelper.Container<BookCategories>();
    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        BookContainer container = (categoriesComboBox.SelectedItem as BookContainer)!;
        if (container.Name.Equals(BookCategories.Select))
        {
            MessageBox.Show("Please make a selection");
        }
        else
        {
            MessageBox.Show($"Selection is {container.Name}");
        }
    }


    private void SetCurrentButton_Click(object sender, EventArgs e)
    {
        // here is how to set the selected index if needed
        categoriesComboBox.SelectedIndex = 
            categoriesComboBox.FindString(BookCategories.Adventure.ToString());
    }
}
