using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        static ExcelHelper excel = new ExcelHelper();                               //gets class ExcelHelper
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 5; i < CheckedListBoxHotCaffe.Items.Count; i++)
            {
                CheckedListBoxHotCaffe.SetItemChecked(i, true);
            }

            for (int i = 4; i < CheckedListBoxHotCaff.Items.Count; i++)
            {
                CheckedListBoxHotCaff.SetItemChecked(i, true);
            }

            for (int i = 3; i < checkedListBoxCold.Items.Count; i++)
            {
                checkedListBoxCold.SetItemChecked(i, true);
            }

            for (int i = 8; i < checkedListBoxTreats.Items.Count; i++)
            {
                checkedListBoxTreats.SetItemChecked(i, true);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Review.Text = "waiting...";

            string excelFilePath = @"S:\mhs\students\!Byle Bambretz\hi jabroini -from other kyle\test.xlsx";

            var excelInfo = excel.CreatingOuputWorksheet(excelFilePath);

            Worksheet x1WorkSheet = excelInfo.Item1;              //new worksheet named the date
            Workbook xlWorkbook = excelInfo.Item2;                //workbook that has the worksheet in it
            Range x1Range = excelInfo.Item3;

            for (int i = 0; i < CheckedListBoxHotCaffe.CheckedItems.Count; i++)
            {
                x1Range.Cells[i+1][1] = CheckedListBoxHotCaffe.CheckedItems[i].ToString(); // add selected Item text to the String .  
            }
            
            for (int i = 0; i < CheckedListBoxHotCaff.CheckedItems.Count; i++)
            {
                x1Range.Cells[20 + i][1] = CheckedListBoxHotCaff.CheckedItems[i].ToString(); // add selected Item text to the String .  
            }

            for (int i = 0; i < checkedListBoxCold.CheckedItems.Count; i++)
            {
                x1Range.Cells[40 + i][1] = checkedListBoxCold.CheckedItems[i].ToString(); // add selected Item text to the String .  
            }

            for (int i = 0; i < checkedListBoxTreats.CheckedItems.Count; i++)
            {
                x1Range.Cells[60 +i][1] = checkedListBoxTreats.CheckedItems[i].ToString(); // add selected Item text to the String .  
            }
            
            excel.SaveExcelFile(excelFilePath, xlWorkbook);

            Review.Text = "COMPLETE";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBoxCold_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedHot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxTreats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckedListBoxHotDecaf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckedListBoxHotCaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckedListBoxHotCaffe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
