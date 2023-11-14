﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using DAL.Repositories;
using DAL;
using System.Globalization;

namespace MenForms
{
    public partial class ClosingConfirmationForm : Form
    {
        private ResourceManager rm = new ResourceManager("MenForms.FavouriteTeamForm", typeof(FavouriteTeamForm).Assembly);
        FormClosingEventArgs args;
        public ClosingConfirmationForm(FormClosingEventArgs e)
        {
            InitializeComponent();
            args = e;
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));
        }
        public void ChangeCulture(string cultureName)
        {
            CultureInfo newCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            // Update text of controls
            UpdateControlTexts();

            // Invalidate the form to ensure it's redrawn with the updated text
            Invalidate();
            Refresh();
        }

        private void UpdateControlTexts()
        {
            //btnNo.Text = rm.GetString("btnNo.Text");
            //btnYes.Text = rm.GetString("btnYes.Text");
            //lblQuesion.Text = rm.GetString("lblQuesion.Text");

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            args.Cancel = true;
            Close();
        }
    }
}
