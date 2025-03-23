using System.Diagnostics;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace ardpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.openedFilePath != "")
            {
                textBox1.Text = File.ReadAllText(Program.openedFilePath);
                SetTitle();
            }
            else
                this.Text = "Ads�z.txt";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //a��lm�� dosya varsa
            if (Program.openedFilePath != "")
            {
                //dosya ayn� de�ilse (kaydet)
                if (File.ReadAllText(Program.openedFilePath) != textBox1.Text)
                    AskSave();
                else //dosya zaten ayn�
                    New();
            }
        }

        void AskSave()
        {
            DialogResult results = MessageBox.Show("Kaydetmek istiyor musunuz?", "Kaydet?", MessageBoxButtons.YesNoCancel);
            if (results == DialogResult.Yes)
            {
                Save();
                New();
            }
            else if (results == DialogResult.No)
                New();
        }

        void Save()
        {
            if (Program.openedFilePath == "")
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Metin dosyalar� (*.txt)|*.txt";
                file.FileName = this.Text;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Program.openedFilePath = file.FileName;
                    File.WriteAllText(Program.openedFilePath, textBox1.Text);
                }
            }
            else
                File.WriteAllText(Program.openedFilePath, textBox1.Text);

        }

        void SaveAs()
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Metin dosyalar� (*.txt)|*.txt|T�m dosyalar (*.*)|*.*";
            file.FileName = this.Text;
            if (file.ShowDialog() == DialogResult.OK)
            {
                Program.openedFilePath = file.FileName;
                File.WriteAllText(Program.openedFilePath, textBox1.Text);
            }
        }

        void New()
        {
            Program.openedFilePath = "";
            textBox1.Text = "";
            this.Text = "Ads�z.txt";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Metin dosyalar� (*.txt)|*.txt|T�m dosyalar (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Program.openedFilePath = file.FileName;
                textBox1.Text = File.ReadAllText(Program.openedFilePath);
                SetTitle();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.ProcessPath);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeALlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(processName))
            {
                if (process.Id != Process.GetCurrentProcess().Id)
                {
                    process.Kill();
                }
            }
            Process.GetCurrentProcess().Kill();
        }

        void SetTitle()
        {
            this.Text = Path.GetFileName(Program.openedFilePath);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.openedFilePath == "" || File.ReadAllText(Program.openedFilePath) != textBox1.Text)
                AskSave();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }
    }
}
