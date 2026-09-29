using Modern.Forms;
using System.Drawing;

namespace MyModernFormsApp
{
    public class HomeForm : Form
    {
        private Label _headingLabel = null!;
        private Button _goToFormBtn = null!;

        public HomeForm()
        {
            Text = "Home";
            Size = new Size(450, 300);

            InitializeControls();
            LayoutControls();
        }

        private void InitializeControls()
        {
            _headingLabel = new Label
            {
                Text = "Welcome to My App",
                TextAlign = Modern.Forms.ContentAlignment.MiddleCenter
            };

            _goToFormBtn = new Button
            {
                Text = "Go to Registration Form",
                Width = 200,
                Height = 40
            };

            _goToFormBtn.Click += GoToFormBtn_Click;
        }

        private void LayoutControls()
        {
            _headingLabel.Top = 60;
            _headingLabel.Left = 25;
            _headingLabel.Width = 400;
            _headingLabel.Height = 50;

            _goToFormBtn.Top = 150;
            _goToFormBtn.Left = 125;

            Controls.Add(_headingLabel);
            Controls.Add(_goToFormBtn);
        }

        private void GoToFormBtn_Click(object? sender, Modern.Forms.MouseEventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.Show();
            Hide();

            registrationForm.Closed += (s, args) => Show();
        }
    }
}