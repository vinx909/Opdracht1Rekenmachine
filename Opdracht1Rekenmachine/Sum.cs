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
            opperator = opperatorsEnums.opperator.Unset;
            internalSum = false;
        }
        public Sum(Sum sum1)
        {
            opperator = opperatorsEnums.opperator.Unset;
            this.sum1 = sum1;
            internalSum = false;
        }
        public Sum(int number1)
        {
            this.number1 = number1;
            opperator = opperatorsEnums.opperator.Unset;
            internalSum = false;
        }
        public Sum(Sum sum1, opperatorsEnums.opperator opperator)
        {
            if (opperator != opperatorsEnums.opperator.Unset)
            {
                this.sum1 = sum1;
                this.opperator = opperator;
                internalSum = false;
            }
            else
            {
                throw new NotImplementedException();
                //shout throw wrong call exception
            }
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

        internal Sum GiveOpperator(opperatorsEnums.opperator opperator)
        {
            if (this.opperator == opperatorsEnums.opperator.Unset)
            {
                this.opperator = opperator;
                return this;
            }
            else if (sum2 != null && internalSum == true)
            {
                sum2.GiveOpperator(opperator);
                return this;
            }
            else
            {
                return new Sum(this, opperator);
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

        internal bool GetInternalSum()
        {
            return internalSum;
        }

        internal Sum StopInternalSum()
        {
            if (sum2 != null)
            {
                if (sum2.GetInternalSum() == true)
                {
                    sum2.StopInternalSum();
                }
                else
                {
                    return new Sum(this);
                }
            }
            return this;
        }
    }
}