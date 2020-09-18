﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            fileName = Properties.Resources.defaultFileName;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripSeparator1_Click_1(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
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

        }

        private void СохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                fileName = saveFileDialog1.FileName;
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
            if (string.IsNullOrEmpty(richTextBox1.Text)){
                Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?", " Сообщение ",MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    Close();
                }
            }
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName.Equals(Properties.Resources.defaultFileName))
            {
                СохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else richTextBox1.SaveFile(fileName);
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
            if (richTextBox1.SelectionLength != 0)
            {
                richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                richTextBox1.Paste();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
                richTextBox1.Redo();
        }
    }
}