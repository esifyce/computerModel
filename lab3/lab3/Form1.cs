using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form, IForm
    {

        IImageProcessor ImageProcessor;
        private bool IsOpened;

        public Form1()
        {
            ImageProcessor = new ImageProcessor(new Model(), this);
            InitializeComponent();
            IsOpened = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageProcessor.LoadKernel(Application.StartupPath + "\\SVMCORE.svm");
        }

        public void ShowView()
        {
            if (!IsOpened) { IsOpened = true; Application.Run(this); }
        }
        public void CloseView()
        {
            Close();
        }
        public void DisplayImage(Bitmap image)
        {
            pictureBox.Image = image;
        }
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void LoadSVM_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".svm";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.LoadKernel(dialog.FileName);
            }
        }

        private void SaveSVM_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".svm";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.SaveKernel(dialog.FileName);
            }
        }

        private void TrainSVM_Button_Click(object sender, EventArgs e)
        {
            ImageProcessor.StartTraining();
        }

        private void LoadImage_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.ShowDialog();
            try
            {
                ImageFileName.Text = dialog.FileName;
                pictureBox.Image = Image.FromFile(ImageFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecognizeImage_Button_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox.Image);
            ImageProcessor.AnalyzeImage(ref image);
        }

        private void SelectFolder_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            try
            {
                ImageFolderName.Text = dialog.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecognizeFolder_Button_Click(object sender, EventArgs e)
        {
            ImageProcessor.LoadImages(ImageFolderName.Text);
        }
    }
}