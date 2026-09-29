using Modern.Forms;
using System.Drawing;

namespace MyModernFormsApp
{
    public class RegistrationForm : Form
    {
        private TextBox _idInput = null!;
        private TextBox _nameInput = null!;
        private TextBox _emailInput = null!;

        private TextBox _contactInput = null!;

        private RadioButton _maleRadio = null!;
        private RadioButton _femaleRadio = null!;
        private CheckBox _subscribeCheck = null!;
        private Button _submitBtn = null!;
        private Button _clearBtn = null!;

        private Label _resultLabel = null!;

        public RegistrationForm()
        {
            Text = "User Registration";
            Size = new Size(450, 440);
            BuildLayout();
        }

        private void BuildLayout()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 7,
                Padding = new Padding(20)
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            var idLabel = new Label { Text = "ID" };
            _idInput = new TextBox { Width = 200 };
            layout.Controls.Add(idLabel, 0, 0);
            layout.Controls.Add(_idInput, 1, 0);
            layout.SetColumnSpan(_idInput, 2);

            var nameLabel = new Label { Text = "Name" };
            _nameInput = new TextBox { Width = 200 };
            layout.Controls.Add(nameLabel, 0, 1);
            layout.Controls.Add(_nameInput, 1, 1);
            layout.SetColumnSpan(_nameInput, 2);

            var emailLabel = new Label { Text = "Email" };
            _emailInput = new TextBox { Width = 200 };
            layout.Controls.Add(emailLabel, 0, 2);
            layout.Controls.Add(_emailInput, 1, 2);
            layout.SetColumnSpan(_emailInput, 2);

            var contactLabel = new Label { Text = "Contact" };
            _contactInput = new TextBox { Width = 200 };
            layout.Controls.Add(contactLabel, 0, 3);
            layout.Controls.Add(_contactInput, 1, 3);
            layout.SetColumnSpan(_contactInput, 2);

            var genderLabel = new Label { Text = "Gender" };
            _maleRadio = new RadioButton { Text = "Male", Checked = true };
            _femaleRadio = new RadioButton { Text = "Female" };
            layout.Controls.Add(genderLabel, 0, 4);
            layout.Controls.Add(_maleRadio, 1, 4);
            layout.Controls.Add(_femaleRadio, 2, 4);

            _subscribeCheck = new CheckBox
            {
                Text = "Subscribe to newsletter",
                Width = 220,
                AutoSize = false
            };
            layout.Controls.Add(_subscribeCheck, 1, 5);
            layout.SetColumnSpan(_subscribeCheck, 2);

            _submitBtn = new Button { Text = "Submit", Width = 100 };
            _submitBtn.Click += SubmitBtn_Click;
            layout.Controls.Add(_submitBtn, 1, 6);

            _clearBtn = new Button
            {
                Text = "Clear",
                Width = 100
            };
            _clearBtn.Click += ClearBtn_Click;
            layout.Controls.Add(_clearBtn, 2, 6);

            Controls.Add(layout);

            _resultLabel = new Label
            {
                Text = "",
                Top = 350,
                Height = 100,
                Left = 20,
                Width = 400
            };
            Controls.Add(_resultLabel);


        }

        private void SubmitBtn_Click(object? sender, Modern.Forms.MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_nameInput.Text))
            {
                var msg = new MessageBoxForm();
                msg.Text = "Error";
                var bodyLabel = new Label 
                { 
                    Text = "Please enter your name before submitting!", 
                    Left = 20, 
                    Top = 60, 
                    Width = 350,
                    Height = 50
                };
                msg.Controls.Add(bodyLabel);
                msg.Show();
            }
            else{
                var gender = _maleRadio.Checked ? "Male" : "Female";
                var subscribed = _subscribeCheck.Checked ? "Yes" : "No";

                _resultLabel.Text = $"ID: {_idInput.Text}\nName: {_nameInput.Text}\nEmail: {_emailInput.Text}\nContact: {_contactInput.Text}\nGender: {gender}\nSubscribed: {subscribed}";
            }
        }


        private void ClearBtn_Click(object? sender, Modern.Forms.MouseEventArgs e)
        {
            _nameInput.Text = string.Empty!;
            _nameInput.Text = string.Empty;
            _idInput.Text = string.Empty;
            _emailInput.Text = string.Empty;
            _contactInput.Text = string.Empty;
            _maleRadio.Checked = true;
            _femaleRadio.Checked = false;
            _subscribeCheck.Checked = false;
            _resultLabel.Text = string.Empty;
        }


    }
}