namespace MyModernFormsApp.prac3
{
    using System.Drawing;
    using Microsoft.VisualBasic;
    using Modern.Forms;
    using SkiaSharp;

    public class ListBoxForm : Form
    {
        private Label h1 = null!;
        private Label h2_letters = null!;
        private Label h2_Add_letters = null!;
        private TextBox textbox1 = null!;
        private Button add_button1 = null!;
        private Button sort_button1 = null!;
        private Button exit_button = null!;
        private ListBox box1 = null!;
        private Button rShift = null!;

        private Label h2_nums = null!;
        private Label h2_Add_nums = null!;
        private TextBox textbox2 = null!;
        private Button add_button2 = null!;
        private Button sort_button2 = null!;
        private ListBox box2 = null!;
        private Button lShift = null!;


        public ListBoxForm()
        {

            Text = "Home";
            Size = new Size(1000, 1000);
            initComponents_LEFT();
            initComponents_RIGHT();
            addComponentsLEFT();
            addComponentsRIGHT();

        }

        private void initComponents_LEFT()
        {
            h1 = new Label
            {
                Text = "List Box Exercise",
                Left = 20,
                Top = 20,
                Width = 310,
                Height = 100
            };
            h1.Style.FontSize = 40;

            h2_letters = new Label
            {
                Text = "List of letters",
                Left = 20,
                Top = 120,
                Width = 310,
                Height = 100,
            };
            h2_letters.Style.FontSize = 30;
        


            box1 = new ListBox
            {
                Left = 20,
                Top = 200,
                Width = 300,
                Height = 150
            };

            box1.Items.AddRange(new object[]
            {
                "A",
                "B",
                "C",
                "D"
            });

            rShift = new Button
            {
                Text = "Right Shift",
                Left = 20,
                Top = 380,
                Height = 30
            };
            rShift.Click += (sender, e) => moveItems(box1,box2);

            h2_Add_letters = new Label
            {
                Text = "Enter letters to add...",
                Left = 20,
                Top = 450,
                Width = 500,
                Height = 60
            };
            h2_Add_letters.Style.FontSize = 30;


            textbox1 = new TextBox
            {
                Left = 20,
                Top = 520,
                Width = 250,
                Height = 40
            };

            add_button1 = new Button
            {
                Text = "Add Letter",
                Left = 20,
                Top = 590,
                Height = 30 
            };
            add_button1.Click += (sender, e) => addItems(textbox1, box1);

            sort_button1 = new Button
            {
                Text = "Sort Letters",
                Left = 20,
                Top = 650,
                Height = 30 
            };
            sort_button1.Click += (sender, e) => sortitems(box1);


            exit_button = new Button
            {
                Text = "Exit",
                Left = 20,
                Top = 710,
                Height = 30 
            };
            exit_button.Click += (sender,e) => Close();
        }

        private void initComponents_RIGHT()
        {

            h2_nums = new Label
            {
                Text = "List of numbers",
                Left = 520,
                Top = 120,
                Width = 310,
                Height = 100,
            };
            h2_nums.Style.FontSize = 30;
        


            box2 = new ListBox
            {
                Left = 520,
                Top = 200,
                Width = 300,
                Height = 150
            };

            box2.Items.AddRange(new object[]
            {
                "1",
                "2",
                "3",
                "4"
            });


            lShift = new Button
            {
                Text = "Left Shift",
                Left = 520,
                Top = 380,
                Height = 30
            };
            lShift.Click += (sender, e) => moveItems(box2, box1);

            h2_Add_nums = new Label
            {
                Text = "Enter numbers to add...",
                Left = 520,
                Top = 450,
                Width = 500,
                Height = 60
            };
            h2_Add_nums.Style.FontSize = 30;


            textbox2 = new TextBox
            {
                Left = 520,
                Top = 520,
                Width = 250,
                Height = 40
            };

            add_button2 = new Button
            {
                Text = "Add Number",
                Left = 520,
                Top = 590,
                Height = 30 
            };
            add_button2.Click += (sender, e) => addItems(textbox2, box2);

            sort_button2 = new Button
            {
                Text = "Sort Numbers",
                Left = 520,
                Top = 650,
                Height = 30 
            };
            sort_button2.Click += (sender, e) => sortitems(box2);


        }
        private void addComponentsLEFT()
        {
            Controls.Add(h1);
            Controls.Add(h2_letters);
            Controls.Add(box1);
            Controls.Add(rShift);
            Controls.Add(h2_Add_letters);
            Controls.Add(textbox1);
            Controls.Add(add_button1);
            Controls.Add(sort_button1);
            Controls.Add(exit_button);
        }

        private void addComponentsRIGHT()
        {
            Controls.Add(h2_nums);
            Controls.Add(box2);
            Controls.Add(lShift);
            Controls.Add(h2_Add_nums);
            Controls.Add(textbox2);
            Controls.Add(add_button2);
            Controls.Add(sort_button2);
        }


        private void moveItems(ListBox source, ListBox destination)
        {
            var selectedItem = source.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            source.Items.Remove(selectedItem);
            destination.Items.Add(selectedItem);
        }

        private void addItems(TextBox textBox, ListBox listBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(item))
            {
                return;
            }
            listBox.Items.Add(item);
            textBox.Text = "";
        }

        private void sortitems(ListBox listBox)
        {
            string[] sortedItems;
            if (listBox == box1)
            {
                sortedItems = listBox.Items.Cast<string>().OrderBy(item => item).ToArray();
            }
            else
            {
                sortedItems = listBox.Items.Cast<string>().OrderBy(item => int.Parse(item)).ToArray();
            }

            listBox.Items.Clear();
            listBox.Items.AddRange(sortedItems);
        }

    }

}
