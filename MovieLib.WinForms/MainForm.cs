global using System.Configuration;
using MovieLib.Domain;
using System.Text.Json;


namespace MovieLib.WinForms
{
	public partial class MainForm : Form
	{
		string url = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public string Url { get => this.url; }

		public MainForm()
		{
			InitializeComponent();
		}
		private void LoadMovie()
		{
			List<Movie> movies = new();
			using (HttpClient client = new())
			{
				HttpResponseMessage response = client.GetAsync(Url).Result;
				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine(response.Content);
					string content = response.Content.ReadAsStringAsync().Result;
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					};
					MovieList.DataSource = JsonSerializer.Deserialize<List<Movie>>(content, options) ?? throw new Exception("Movies are null");
				}
				else
					MessageBox.Show("Error");
			}
		}
		private void CreateButton_Click(object sender, EventArgs e)
		{
			NewMovie new_Movie = new()
			{
				StartPosition = FormStartPosition.CenterParent
			};
			DialogResult dialogResult = new_Movie.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{ LoadMovie(); }
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
				Movie selected = (Movie) MovieList.SelectedItem;
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
				Movie selected = (Movie) MovieList.SelectedItem;
				DialogResult confirm = MessageBox.Show($"Are you sure you want to delete {selected.Title} movie?", "Confirm", MessageBoxButtons.YesNo);
				if (confirm == DialogResult.Yes)
				{
					using (HttpClient client = new())
					{
						HttpResponseMessage response = client.DeleteAsync($"{Url}/{selected.Id}").Result;

						if (response.IsSuccessStatusCode)
						{
							LoadMovie();
						}
						else
						{
							MessageBox.Show("Error, Movie can't be deleted.");
						}
					}
				}
			}

		}
	}
}
