using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace ZXing_Verification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var testReader = new BarcodeReader();
        }

        private void btn_Click(object sender, System.EventArgs e)
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = 200,
                        Width = 200
                    }
                };

                string content = string.IsNullOrWhiteSpace(txt.Text) ? "Test" : txt.Text;
                Bitmap result = writer.Write(content);

                pic.Image = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误: " + ex.Message);
            }
        }
    }
}
