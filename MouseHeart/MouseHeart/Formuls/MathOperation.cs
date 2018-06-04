using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart
{
    public class MathOperation
    {
        object Value;
        object Value2;
        FormulaOperation operation;
        public MathOperation(string name, СalculationFormula root, FormulaOperation operation)
        {
            Value = name;
            Value2 = root;
            this.operation = FormulaOperation.Varible;
        }
        public MathOperation(float a, FormulaOperation operation)
        {
            Value = a;
            this.operation = FormulaOperation.Const;
        }
        public MathOperation(MathOperation a, MathOperation b, FormulaOperation operation)
        {
            switch (operation)
            {
                case FormulaOperation.Plus:
                case FormulaOperation.Minus:
                case FormulaOperation.Div:
                case FormulaOperation.Multi:
                    Value = a;
                    Value2 = b;
                    this.operation = operation;
                    break;

            }
        }
        public float Calc()
        {
            switch (operation)
            {
                case FormulaOperation.Const:
                    return (float)Value;
                case FormulaOperation.Varible:
                    {
                        return ((СalculationFormula)Value2)[(string)Value];
                    }
                case FormulaOperation.Plus:
                    return ((MathOperation)Value).Calc() + ((MathOperation)Value2).Calc();
                case FormulaOperation.Minus:
                    return ((MathOperation)Value).Calc() - ((MathOperation)Value2).Calc();
                case FormulaOperation.Div:
                    return ((MathOperation)Value).Calc() / ((MathOperation)Value2).Calc();
                case FormulaOperation.Multi:
                    return ((MathOperation)Value).Calc() * ((MathOperation)Value2).Calc();
            }
            return 0;
        }

    }
    public class Token
    {
        public FormulaOperation operation { get; set; }
        public object Value { get; set; }
    }
    public enum FormulaOperation
    {
        Const,
        Varible,
        OpeningParenthesis,
        ClosingParenthesis,
        Plus,
        Minus,
        Div,
        Multi
    }
}

