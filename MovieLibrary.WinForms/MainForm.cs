using HelloWorld.Business;
using HelloWorld.Business.Models;
using System.Diagnostics;

namespace HelloWorld.WinForms
{
    public partial class MainForm : Form
    {
        private MovieService movieService;

        public MainForm()
        {

            movieService = new();
            InitializeComponent();
        }
        private void LoadMovie()
        {
            MovieList.DataSource = movieService.Get();

        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            NewMovie new_Movie = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            DialogResult dialogResult = new_Movie.ShowDialog();
            if (dialogResult == DialogResult.OK) { LoadMovie(); }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MovieList.DisplayMember = "Title";
            LoadMovie();

        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            if (MovieList.SelectedItem != null)
            {
                Movie selected = (Movie)MovieList.SelectedItem;
                NewMovie newMovie = new();
                newMovie.Current = selected;
                newMovie.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = newMovie.ShowDialog();
                if (result == DialogResult.OK)
                    LoadMovie();

            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MovieList.SelectedItems.Count > 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MovieList.SelectedItem != null)
            {
                Movie selected = (Movie)MovieList.SelectedItem;
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete {selected.Title} movie?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    movieService.Delete(selected.Id);
                    LoadMovie();
                }
            }
            
        }
    }
}