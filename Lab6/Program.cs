using System;
using System.Windows.Forms;

namespace TrianglePerimeterCalculator
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public partial class MainForm : Form
    {
        private TextBox sideATextBox;
        private TextBox sideBTextBox;
        private TextBox sideCTextBox;
        private Button calculateButton;
        private Label perimeterLabel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.sideATextBox = new TextBox();
            this.sideBTextBox = new TextBox();
            this.sideCTextBox = new TextBox();
            this.calculateButton = new Button();
            this.perimeterLabel = new Label();
            this.SuspendLayout();
            // 
            // sideATextBox
            // 
            this.sideATextBox.Location = new System.Drawing.Point(50, 50);
            this.sideATextBox.Name = "sideATextBox";
            this.sideATextBox.Size = new System.Drawing.Size(100, 20);
            this.sideATextBox.TabIndex = 0;
            // 
            // sideBTextBox
            // 
            this.sideBTextBox.Location = new System.Drawing.Point(50, 100);
            this.sideBTextBox.Name = "sideBTextBox";
            this.sideBTextBox.Size = new System.Drawing.Size(100, 20);
            this.sideBTextBox.TabIndex = 1;
            // 
            // sideCTextBox
            // 
            this.sideCTextBox.Location = new System.Drawing.Point(50, 150);
            this.sideCTextBox.Name = "sideCTextBox";
            this.sideCTextBox.Size = new System.Drawing.Size(100, 20);
            this.sideCTextBox.TabIndex = 2;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(50, 200);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 30);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Обчислити";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // perimeterLabel
            // 
            this.perimeterLabel.AutoSize = true;
            this.perimeterLabel.Location = new System.Drawing.Point(50, 250);
            this.perimeterLabel.Name = "perimeterLabel";
            this.perimeterLabel.Size = new System.Drawing.Size(0, 13);
            this.perimeterLabel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(200, 300);
            this.Controls.Add(this.perimeterLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.sideCTextBox);
            this.Controls.Add(this.sideBTextBox);
            this.Controls.Add(this.sideATextBox);
            this.Name = "MainForm";
            this.Text = "Периметр трикутника";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double sideA = double.Parse(sideATextBox.Text);
                double sideB = double.Parse(sideBTextBox.Text);
                double sideC = double.Parse(sideCTextBox.Text);
                double perimeter = CalculatePerimeter(sideA, sideB, sideC);
                perimeterLabel.Text = "Периметр трикутника: " + perimeter.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть дійсні числа.", "Помилка");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private double CalculatePerimeter(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Довжина сторін не може бути менше або рівна нулю.");
            }

            return a + b + c;
        }
    }
}
