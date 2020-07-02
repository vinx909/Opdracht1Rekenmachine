using System;
using static Opdracht1Rekenmachine.opperatorsEnums;

namespace Opdracht1Rekenmachine
{
    internal class Sum
    {
        private int number1;
        private Sum sum1;
        private int number2;
        private Sum sum2;
        private bool internalSum;
        private opperatorsEnums.opperator opperator;

        public Sum()
        {
            Baseline();
        }
        private Sum(int number1)
        {
            this.number1 = number1;
            Baseline();
        }
        private void Baseline()
        {
            opperator = opperatorsEnums.opperator.Unset;
            internalSum = false;
        }
        private Sum CreateCopy()
        {
            Sum product = new Sum();
            product.number1 = this.number1;
            product.sum1 = this.sum1;
            product.number2 = this.number2;
            product.sum2 = this.sum2;
            product.internalSum = this.internalSum;
            product.opperator = this.opperator;
            return product;
        }
        private void Reset()
        {
            number1 = 0;
            sum1 = null;
            number2 = 0;
            sum2 = null;
            Baseline();
        }
        private void ResetWithOldAsSum1()
        {
            Sum old = CreateCopy();
            Reset();
            sum1 = old;
        }
        internal string GetSumText()
        {
            string text = "(";
            if (sum1 != null)
            {
                text += sum1.GetSumText();
            }
            else
            {
                text += number1;
            }
            switch (opperator)
            {
                case opperator.Plus:
                    text += "+";
                    break;
                case opperator.Minus:
                    text += "-";
                    break;
                case opperator.Multiply:
                    text += "*";
                    break;
                case opperator.Devide:
                    text += "/";
                    break;
                case opperator.Unset:
                    break;
            }
            if (opperator!= opperatorsEnums.opperator.Unset) {
                if (sum2 != null)
                {
                    text += sum2.GetSumText();
                }
                else
                {
                    text += number2;
                }
            }
            text += ")";
            return text;
        }

        internal void GiveNumber(int number)
        {
            if (opperator == opperatorsEnums.opperator.Unset)
            {
                number1 = int.Parse("" + number1 + number);
            }
            else
            {
                if (sum2 != null)
                {
                    sum2.GiveNumber(number);
                }
                else
                {
                    number2 = int.Parse("" + number2 + number);
                }
            }
        }

        internal void GiveOpperator(opperatorsEnums.opperator opperator)
        {
            if (this.opperator == opperatorsEnums.opperator.Unset)
            {
                this.opperator = opperator;
            }
            else if (sum2 != null && internalSum == true)
            {
                sum2.GiveOpperator(opperator);
            }
            else
            {
                ResetWithOldAsSum1();
                this.opperator = opperator;
            }
        }

        internal int CalculateResult()
        {
            if (sum1 != null)
            {
                number1 = sum1.CalculateResult();
            }
            if (sum2 != null)
            {
                number2 = sum2.CalculateResult();
            }
            int result = 0;
            switch (opperator)
            {
                case opperatorsEnums.opperator.Plus:
                    result = number1 + number2;
                    break;
                case opperatorsEnums.opperator.Minus:
                    result = number1 - number2;
                    break;
                case opperatorsEnums.opperator.Multiply:
                    result = number1 * number2;
                    break;
                case opperatorsEnums.opperator.Devide:
                    result = number1 / number2;
                    break;
                case opperatorsEnums.opperator.Unset:
                    result = number1;
                    break;
            }
            return result;
        }

        internal void StartInternalSum()
        {
            sum2 = new Sum(number2);
            internalSum = true;
        }

        private bool GetInternalSum()
        {
            return internalSum;
        }

        internal void StopInternalSum()
        {
            if (sum2 != null)
            {
                if (sum2.GetInternalSum() == true)
                {
                    sum2.StopInternalSum();
                }
                else
                {
                    ResetWithOldAsSum1();
                }
            }
        }
    }
}