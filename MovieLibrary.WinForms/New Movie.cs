using HelloWorld.Business;
using HelloWorld.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld.WinForms
{
    public partial class NewMovie : Form
    {
        public Movie Current { get; set; }
        public NewMovie()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            MovieService movieService = new();

         
                Movie movie = new()
                {
                    Plot = txtPlot.Text,
                    Title = txtTitle.Text,
                    WatchedDate = dateTimePicker.Value,
                    Seen = movieSeen.Checked,
                };
            if (Current == null)
            {
                movieService.Create(movie);

            }
            else
            {
                movie.Id = Current.Id;
                movieService.Update(movie);
            }
            DialogResult = DialogResult.OK;
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
