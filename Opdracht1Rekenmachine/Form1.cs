using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht1Rekenmachine
{
    public partial class Form1 : Form
    {
        private const int NUMBERBUTTON0VALUE = 0;
        private const int NUMBERBUTTON1VALUE = 1;
        private const int NUMBERBUTTON2VALUE = 2;
        private const int NUMBERBUTTON3VALUE = 3;
        private const int NUMBERBUTTON4VALUE = 4;
        private const int NUMBERBUTTON5VALUE = 5;
        private const int NUMBERBUTTON6VALUE = 6;
        private const int NUMBERBUTTON7VALUE = 7;
        private const int NUMBERBUTTON8VALUE = 8;
        private const int NUMBERBUTTON9VALUE = 9;

        private const opperatorsEnums.opperator OPPERATORBUTTONPLUSVALUE = opperatorsEnums.opperator.Plus;
        private const opperatorsEnums.opperator OPPERATORBUTTONMINUSVALUE = opperatorsEnums.opperator.Minus;
        private const opperatorsEnums.opperator OPPERATORBUTTONMULTIPLYVALUE = opperatorsEnums.opperator.Multiply;
        private const opperatorsEnums.opperator OPPERATORBUTTONDEVIDEVALUE = opperatorsEnums.opperator.Devide;

        Sum sum = new Sum();
        List<Sum> history = new List<Sum>();
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateSumDisplay()
        {
            labelSumDisplay.Text = sum.GetSumText();
        }
        private void UpdateResultDisplay()
        {
            labelResultDisplay.Text = "="+sum.CalculateResult();
        }
        private void UpdateHistoryDisplay()
        {
            String text = "";
            for(int i=history.Count-1;i>=0;i--)
            {
                text += history[i].GetSumText()+"="+ history[i].CalculateResult()+ System.Environment.NewLine;
            }
            labelHistory.Text = text;
        }

        private void AddNumber(int value)
        {
            sum.GiveNumber(value);
            UpdateSumDisplay();
        }
        private void AddOpperator(opperatorsEnums.opperator opperator)
        {
            sum.GiveOpperator(opperator);
            UpdateSumDisplay();
        }
        private void AddInternalSum()
        {
            sum.StartInternalSum();
            UpdateSumDisplay();
        }
        private void StopInternalSum()
        {
            sum.StopInternalSum();
        }
        private void EndSumPushToHistory()
        {
            history.Add(sum);
            sum = new Sum();
            UpdateSumDisplay();
            UpdateHistoryDisplay();
        }


        private void NumberButton0_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON0VALUE);
        }
        private void NumberButton1_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON1VALUE);
        }
        private void NumberButton2_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON2VALUE);
        }
        private void NumberButton3_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON3VALUE);
        }
        private void NumberButton4_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON4VALUE);
        }
        private void NumberButton5_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON5VALUE);
        }
        private void NumberButton6_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON6VALUE);
        }
        private void NumberButton7_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON7VALUE);
        }
        private void NumberButton8_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON8VALUE);
        }
        private void NumberButton9_Click(object sender, EventArgs e)
        {
            AddNumber(NUMBERBUTTON9VALUE);
        }

        private void ButtonOpperatiorPlus_Click(object sender, EventArgs e)
        {
            AddOpperator(OPPERATORBUTTONPLUSVALUE);
        }
        private void ButtonOpperatiorMinus_Click(object sender, EventArgs e)
        {
            AddOpperator(OPPERATORBUTTONMINUSVALUE);
        }
        private void ButtonOpperatiorMultiply_Click(object sender, EventArgs e)
        {
            AddOpperator(OPPERATORBUTTONMULTIPLYVALUE);
        }
        private void ButtonOpperatiorDivide_Click(object sender, EventArgs e)
        {
            AddOpperator(OPPERATORBUTTONDEVIDEVALUE);
        }

        private void ButtonActionEquals_Click(object sender, EventArgs e)
        {
            UpdateResultDisplay();
        }

        private void buttonActionStartInternalSum_Click(object sender, EventArgs e)
        {
            AddInternalSum();
        }
        private void buttonActionEndInternalSum_Click(object sender, EventArgs e)
        {
            StopInternalSum();
        }

        private void buttonActionEndSum_Click(object sender, EventArgs e)
        {
            EndSumPushToHistory();
        }
    }
}
