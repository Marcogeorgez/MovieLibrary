using MovieLib.Domain;
using System.Text;
using System.Text.Json;

namespace MovieLib.WinForms
{
	public partial class NewMovie : Form
	{
		readonly string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]!;

		public Movie Current { get; set; }
		public NewMovie()
		{
			InitializeComponent();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			Movie movie = new()
			{
				Id = Current == null ? 0 : Current.Id,
				Plot = txtPlot.Text,
				Title = txtTitle.Text,
				WatchedDate = dateTimePicker.Value,
				Seen = movieSeen.Checked,
			};
			if (!movie.Validate(out string validationMessage))
			{
				MessageBox.Show(validationMessage);
				return;
			}
			string jsonData = JsonSerializer.Serialize(movie);

			StringContent content = new(jsonData, Encoding.UTF8, "application/json");

			string Url = Current == null ? baseUrl : $"{baseUrl}/{movie.Id}";


			using (HttpClient client = new())
			{
				HttpResponseMessage? response;
				if (Current == null)
				{
					response = client.PostAsync(Url, content).Result;
				}
				else
				{
					response = client.PutAsync(Url, content).Result;
				}

				if (!response.IsSuccessStatusCode)
				{
					MessageBox.Show("Something went wrong while saving the movie");
					DialogResult = DialogResult.Cancel;
				}
				else
				{
					DialogResult = DialogResult.OK;
				}


				DialogResult = DialogResult.OK;
			}

			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void New_Movie_Load(object sender, EventArgs e)
		{
			if (Current != null)
			{
				txtPlot.Text = Current.Plot;
				txtTitle.Text = Current.Title;
				movieSeen.Checked = Current.Seen;
				dateTimePicker.Value = Current.WatchedDate;

				createButton.Text = "Update";
			}
			else
			{
				createButton.Text = "Create";
			}
		}
	}
}
