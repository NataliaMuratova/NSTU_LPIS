using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1LIS
{
    public partial class Form1 : Form
    {
        String fileName;
        Boolean flagTextChanged = false;
        public Form1()
        {
            InitializeComponent();
            fileName = Properties.Resources.defaultFileName;

            //richTextBox1.ForeColor = Color.Red;
            //richTextBox1.Font = new Font("Arial", 10);
            //richTextBox1.AppendText(string.Format(" Искать Слово \r\n"));


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripSeparator1_Click_1(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            fileName = Properties.Resources.defaultFileName;
            flagTextChanged = false;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;
            }
        }

        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СоздатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }


        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            keyWords();
            flagTextChanged = true;
        }

        private void СохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                fileName = saveFileDialog1.FileName;
                flagTextChanged = false;
            }
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (fileName.Equals(Properties.Resources.defaultFileName))
            {
                СохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else richTextBox1.SaveFile(fileName);
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {

                if (flagTextChanged == true)
                {
                    DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?", " Сообщение ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                    {
                        сохранитьToolStripMenuItem_Click(sender, e);
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Close();
                    }
                    else if (result == DialogResult.Cancel) { }
                }
                else Close();

 
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName.Equals(Properties.Resources.defaultFileName))
            {
                СохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                richTextBox1.SaveFile(fileName);
                flagTextChanged = false;
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) {
                richTextBox1.Copy();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength != 0)
            {
                richTextBox1.Cut();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength != 0)
            {
                richTextBox1.Cut();
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void keyWords()
        {
            int position_save = richTextBox1.SelectionStart; // сохраняем позицию курсора из начально


            string str = "Console";
            int i = 0;
            while (i <= richTextBox1.Text.Length - str.Length)
            {
                //выделение цветом
                i = richTextBox1.Text.IndexOf(str, i);
                if (i < 0) break;
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = str.Length;
                richTextBox1.SelectionColor = Color.Blue;
                i += str.Length;
                richTextBox1.SelectionStart = position_save; // ставим как было
                richTextBox1.SelectionColor = Color.Black; // чужое красим в черное
            }
        }
    

    }
}
