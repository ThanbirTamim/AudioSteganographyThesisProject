using AudioSteganographyThesisProject.Algorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using System.Drawing;


namespace AudioSteganographyThesisProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowseCoverAudio_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Browse WAV File";
                openFileDialog.Filter = "wav files (*.wav)|*.wav";
                openFileDialog.Multiselect = false;
                string fileWav = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileWav = openFileDialog.FileName;
                }
                if (String.IsNullOrEmpty(fileWav))
                    throw new Exception("Please select a wav file....");
                txtFileName.Text = fileWav;


                if (radioProposed.Checked == true)
                {
                    radioProposed_CheckedChanged();
                }
                else if (radioAlgorithm1.Checked == true)
                {
                    radioAlgorithm1_CheckedChanged();
                }
                else if (radioAlgorithm2.Checked == true)
                {
                    radioAlgorithm2_CheckedChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pausePicBox_Click(object sender, EventArgs e)
        {
            try
            {
                pausePicBox.Visible = false;
                playPicBox.Visible = true;

                if (player != null)
                    player.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public SoundPlayer player;

        private void playPicBox_Click(object sender, EventArgs e)
        {

            try
            {
                if (!File.Exists(txtFileName.Text.Trim()))
                    throw new Exception("Selected file is not exist.");

                if (player == null)
                    player = new SoundPlayer(txtFileName.Text.Trim());

                player.Play();

                playPicBox.Visible = false;
                pausePicBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSecretMessage_TextChanged(object sender, EventArgs e)
        {
            lblTxtCount.Text = "Letter Count: " + txtSecretMessage.Text.Trim().Length;
        }

        public string stegoFileAddress = "";
        private void btnHide_Click(object sender, EventArgs e)
        {
            try
            {
                string secret_meaage = txtSecretMessage.Text.Trim();
                if (String.IsNullOrEmpty(secret_meaage))
                    throw new Exception("Please write some text to hide!");

                if (DialogResult.Yes == MessageBox.Show("Do you want to hide message into selected cover audio?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //here we are going to save our stago file
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Where you going to save your stego wav file?",
                        Filter = "Wav file (*.wav)|*.wav",
                        FileName = "Stego.wav"
                    };

                    string stegoFileAddress = "";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        stegoFileAddress = saveFileDialog.FileName;
                    }

                    if (String.IsNullOrEmpty(stegoFileAddress))
                        throw new Exception("Save file is not be empty. Try again later!");

                    string status = "Failed";
                    if (radioProposed.Checked == true)
                    {
                        //param <message, stego_file, cover_file>
                        status = Helper.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                        //param <cover_file, stego_file>
                        CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                    }
                    else if (radioAlgorithm1.Checked == true)
                    {
                        //(https://ieeexplore.ieee.org/abstract/document/8628458)
                        //Hashim, Jibran, et al. "LSB Modification based audio steganography using advanced encryption standard (AES-256) technique." 2018 12th International Conference on Mathematics, Actuarial Science, Computer Science and Statistics (MACS). IEEE, 2018.
                        status = ExistingTechnique1.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                        //param <cover_file, stego_file>
                        CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                    }
                    else if (radioAlgorithm2.Checked == true)
                    {
                        //(https://www.researchgate.net/profile/Dac-Nhuong-Le/publication/348438262_Securing_Technique_Using_Pattern-Based_LSB_Audio_Steganography_and_Intensity-Based_Visual_Cryptography/links/6030c6394585158939b7c47a/Securing-Technique-Using-Pattern-Based-LSB-Audio-Steganography-and-Intensity-Based-Visual-Cryptography.pdf)
                        //(Rakshit, Pranati, et al. "Securing Technique Using Pattern-Based LSB Audio Steganography and Intensity-Based Visual Cryptography." CMC-COMPUTERS MATERIALS & CONTINUA 67.1 (2021): 1207-1224.)

                        status = ExistingTechnique2.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                        //param <cover_file, stego_file>
                        CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                    }
                    else if (radioAlgorithm3.Checked == true)
                    {
                        //(https://link.springer.com/article/10.1007/s42452-019-0875-8)
                        //(Al-Juaid, Nouf, and Adnan Gutub. "Combining RSA and audio steganography on personal computers for enhancing security." SN Applied Sciences 1.8 (2019): 1-11.)

                        status = ExistingTechnique3.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                        //param <cover_file, stego_file>
                        CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                    }
                    else if (radioAlgorithm4.Checked == true)
                    {
                        //(https://sci-hub.se/10.1109/NILES.2019.8909206)
                        //(Hemeida, F., Alexan, W., & Mamdouh, S. (2019). Blowfish–Secured Audio Steganography. 2019 Novel Intelligent and Leading Emerging Sciences Conference (NILES). doi:10.1109/niles.2019.8909206)
                        status = ExistingTechnique4.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                        //param <cover_file, stego_file>
                        CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                    }



                    ShowCoverWave(txtFileName.Text.Trim());
                    ShowStegoWave(stegoFileAddress);


                    MessageBox.Show(status, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowStegoWave(string file)
        {
            // 1. Configure Providers
            MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
            RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200); // e.g. 200
            SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200); // e.g. 200
            AveragePeakProvider averagePeakProvider = new AveragePeakProvider(2); // e.g. 4

            // 2. Configure the style of the audio wave image
            StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
            myRendererSettings.Width = 3000;
            myRendererSettings.TopHeight = 250;
            myRendererSettings.BottomHeight = 250;

            // Set background of the chart as transparent
            myRendererSettings.BackgroundColor = Color.Transparent;

            // Change the color of the peaks
            myRendererSettings.TopPeakPen = new Pen(Color.DarkGreen);
            myRendererSettings.BottomPeakPen = new Pen(Color.Green);

            // 3. Define the audio file from which the audio wave will be created and define the providers and settings
            WaveFormRenderer renderer = new WaveFormRenderer();
            String audioFilePath = file;
            Image image = renderer.Render(audioFilePath, averagePeakProvider, myRendererSettings);
            pictureBoxCoverWave.Image = image;

            btnCoverWavDownload.Visible = true;
            // 4. Store the image 
            //image.Save(@"D:\Varsity\SampleAudio\myfile.png", ImageFormat.Png);
        }

        private void ShowCoverWave(string file)
        {
            // 1. Configure Providers
            MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
            RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200); // e.g. 200
            SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200); // e.g. 200
            AveragePeakProvider averagePeakProvider = new AveragePeakProvider(2); // e.g. 4

            // 2. Configure the style of the audio wave image
            StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
            myRendererSettings.Width = 3000;
            myRendererSettings.TopHeight = 250;
            myRendererSettings.BottomHeight = 250;

            // Set background of the chart as transparent
            myRendererSettings.BackgroundColor = Color.Transparent;

            // Change the color of the peaks
            myRendererSettings.TopPeakPen = new Pen(Color.DarkGreen);
            myRendererSettings.BottomPeakPen = new Pen(Color.Green);

            // 3. Define the audio file from which the audio wave will be created and define the providers and settings
            WaveFormRenderer renderer = new WaveFormRenderer();
            String audioFilePath = file;
            Image image = renderer.Render(audioFilePath, averagePeakProvider, myRendererSettings);
            pictureBoxStegoWave.Image = image;
            btnStegoWavDownload.Visible = true;
            // 4. Store the image 
            //image.Save(@"D:\Varsity\SampleAudio\myfile.png", ImageFormat.Png);
        }

        private void CheckMeaturementMetrix(string v, string stegoFileAddress)
        {
            try
            {
                if (radioProposed.Checked == true)
                {
                    string validation = Helper.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgorithm1.Checked == true)
                {
                    string validation = ExistingTechnique1.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgorithm2.Checked == true)
                {
                    string validation = ExistingTechnique2.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgorithm3.Checked == true)
                {
                    string validation = ExistingTechnique3.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgorithm4.Checked == true)
                {
                    string validation = ExistingTechnique4.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to extract message from selected stego audio?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    if (radioProposed.Checked == true)
                    {
                        string secretMessage = Helper.ExtractSecretMessage(txtFileName.Text.Trim());
                        txtSecretMessage.Text = secretMessage;
                    }
                    else if (radioAlgorithm1.Checked == true)
                    {
                        string secretMessage = ExistingTechnique1.ExtractSecretMessage(txtFileName.Text.Trim());
                        txtSecretMessage.Text = secretMessage;
                    }
                    else if (radioAlgorithm2.Checked == true)
                    {
                        string secretMessage = ExistingTechnique2.ExtractSecretMessage(txtFileName.Text.Trim());
                        txtSecretMessage.Text = secretMessage;
                    }
                    else if (radioAlgorithm3.Checked == true)
                    {
                        string secretMessage = ExistingTechnique3.ExtractSecretMessage(txtFileName.Text.Trim());
                        txtSecretMessage.Text = secretMessage;
                    }
                    else if (radioAlgorithm4.Checked == true)
                    {
                        string secretMessage = ExistingTechnique4.ExtractSecretMessage(txtFileName.Text.Trim());
                        txtSecretMessage.Text = secretMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to refresh application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                txtMeaturement.Text = "";
                txtFileName.Text = "";
                txtSecretMessage.Text = "";
            }

        }

        public void radioProposed_CheckedChanged()
        {
            if (String.IsNullOrEmpty(txtFileName.Text.Trim()) || !File.Exists(txtFileName.Text.Trim()))
                return;
            WaveAudio waveAudio = new WaveAudio(new FileStream(txtFileName.Text.Trim(), FileMode.Open, FileAccess.Read));
            int leftStream = waveAudio.GetLeftStream().Count;
            int rightStream = waveAudio.GetRightStream().Count;

            lblMaxLetter.Text = "Max Letter: " + Math.Round(((leftStream * 2) - 500.0f) / 8).ToString();
        }

        public void radioAlgorithm1_CheckedChanged()
        {
            if (String.IsNullOrEmpty(txtFileName.Text.Trim()) || !File.Exists(txtFileName.Text.Trim()))
                return;
            WaveAudio waveAudio = new WaveAudio(new FileStream(txtFileName.Text.Trim(), FileMode.Open, FileAccess.Read));
            int leftStream = waveAudio.GetLeftStream().Count;
            int rightStream = waveAudio.GetRightStream().Count;

            lblMaxLetter.Text = "Max Letter: " + Math.Round(((leftStream * 2) - 500.0f) / 8).ToString();
        }
        public void radioAlgorithm2_CheckedChanged()
        {
            if (String.IsNullOrEmpty(txtFileName.Text.Trim()) || !File.Exists(txtFileName.Text.Trim()))
                return;
            WaveAudio waveAudio = new WaveAudio(new FileStream(txtFileName.Text.Trim(), FileMode.Open, FileAccess.Read));
            int leftStream = waveAudio.GetLeftStream().Count;
            int rightStream = waveAudio.GetRightStream().Count;

            lblMaxLetter.Text = "Max Letter: " + (Math.Round(((leftStream * 2) - 500.0f) / 8) * 4).ToString();
        }
        public void radioAlgorithm3_CheckedChanged()
        {
            if (String.IsNullOrEmpty(txtFileName.Text.Trim()) || !File.Exists(txtFileName.Text.Trim()))
                return;
            WaveAudio waveAudio = new WaveAudio(new FileStream(txtFileName.Text.Trim(), FileMode.Open, FileAccess.Read));
            int leftStream = waveAudio.GetLeftStream().Count;
            int rightStream = waveAudio.GetRightStream().Count;

            lblMaxLetter.Text = "Max Letter: " + Math.Round(((leftStream * 2) - 500.0f) / 8).ToString();
        }
        public void radioAlgorithm4_CheckedChanged()
        {
            if (String.IsNullOrEmpty(txtFileName.Text.Trim()) || !File.Exists(txtFileName.Text.Trim()))
                return;
            WaveAudio waveAudio = new WaveAudio(new FileStream(txtFileName.Text.Trim(), FileMode.Open, FileAccess.Read));
            int leftStream = waveAudio.GetLeftStream().Count;
            int rightStream = waveAudio.GetRightStream().Count;

            lblMaxLetter.Text = "Max Letter: " + Math.Round(((leftStream * 2) - 500.0f) / 8).ToString();
        }


        private void radioProposed_CheckedChanged(object sender, EventArgs e)
        {
            radioProposed_CheckedChanged();
        }

        private void radioAlgorithm1_CheckedChanged(object sender, EventArgs e)
        {
            radioAlgorithm1_CheckedChanged();
        }

        private void radioAlgorithm2_CheckedChanged(object sender, EventArgs e)
        {
            radioAlgorithm2_CheckedChanged();
        }

        private void radioAlgorithm3_CheckedChanged(object sender, EventArgs e)
        {
            radioAlgorithm3_CheckedChanged();
        }

        private void radioAlgorithm4_CheckedChanged(object sender, EventArgs e)
        {
            radioAlgorithm4_CheckedChanged();
        }

        private void btnCoverWavDownload_Click(object sender, EventArgs e)
        {
            if(pictureBoxCoverWave.Image != null)
            {
                Image image = pictureBoxCoverWave.Image;


                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Where you going to save your cover wave image file?",
                    Filter = "Image file (*.png)|*.png",
                    FileName = "CoverWave.png"
                };

                string CoverImageFileAddress = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CoverImageFileAddress = saveFileDialog.FileName;
                }

                if (String.IsNullOrEmpty(CoverImageFileAddress))
                    throw new Exception("Save file is not be empty. Try again later!");

                image.Save(CoverImageFileAddress, ImageFormat.Png);
            }
        }
        private void btnStegoWavDownload_Click(object sender, EventArgs e)
        {
            if (pictureBoxStegoWave.Image != null)
            {
                Image image = pictureBoxStegoWave.Image;


                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Where you going to save your stego wave image file?",
                    Filter = "Image file (*.png)|*.png",
                    FileName = "StegoWave.png"
                };

                string StegoImageFileAddress = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StegoImageFileAddress = saveFileDialog.FileName;
                }

                if (String.IsNullOrEmpty(StegoImageFileAddress))
                    throw new Exception("Save file is not be empty. Try again later!");

                image.Save(StegoImageFileAddress, ImageFormat.Png);
            }
        }
    }
}
