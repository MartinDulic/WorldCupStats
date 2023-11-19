using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    internal class QuestionViewModel
    {
        public QuestionViewModel(string question)
        {
            questionText = question;
            btnYesText = "Yes";
            btnNoText = "No";
        }

        private string questionText;
        public string QuestionText { get => questionText; }

        private string btnYesText;
        public string BtnYesText { get => btnYesText; }

        private string btnNoText;
        public string BtnNoText { get => btnNoText; }


    }
}
