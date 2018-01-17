using System;
using System.Collections.Generic;
using System.Text;

namespace MouseHeart
{
    public class СalculationFormula
    {
        public string Name { get; set; }
        public Dictionary<string, СalculationFormula> Varibles = new Dictionary<string, СalculationFormula>();

        private MathOperation Formula;



        public СalculationFormula(string ParsedString)
        {
            List<Token> lexic = LexicAnalysis(ParsedString);
            Formula = GetFormula(lexic);
        }
        public СalculationFormula(string Name,string ParsedString)
        {
            this.Name = Name;
            List<Token> lexic = LexicAnalysis(ParsedString);
            Formula = GetFormula(lexic);
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public float Calc()
        {
            return Formula.Calc();
        }

        private List<Token> LexicAnalysis(string inputString)
        {
            
            List<Token> tokens = new List<Token>();
            int i = 0;
            while( i < inputString.Length)
            {
                Token t = new Token();
                int charCode = inputString[i];
                StringBuilder buff = new StringBuilder();
                //обрабатываем цифры
                while (((charCode >= 48 && charCode <= 57) || charCode == 46|| charCode == 44 ))//добавляем пока не закончились цифры
                {
                    buff.Append(inputString[i]);
                    if (i + 1 < inputString.Length)
                        charCode = inputString[++i];
                    else
                        break;
                }
                if(buff.Length >0)
                {
                    float buffValue;

                    if(float.TryParse(buff.ToString().Replace('.',','), out buffValue))
                    {
                        t.Value = buffValue;
                        t.operation = FormulaOperation.Const;
                        tokens.Add(t);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при обработке  числа");
                    }
                }

                //Обрабатываем буквы
                while ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122))//добавляем пока не закончились цифры
                {
                    buff.Append(inputString[i]);
                    if (i + 1 < inputString.Length)
                        charCode = inputString[++i];
                    else
                        break;
                }
                if (buff.Length > 0)
                {
                    t.operation = FormulaOperation.Varible;
                    t.Value = buff.ToString();
                    tokens.Add(t);

                    continue;
                }

                switch (charCode)
                {
                    case 40:
                        {
                            t.operation = FormulaOperation.OpeningParenthesis;
                            t.Value = 40;
                            break;
                        }
                    case 41:
                        {
                            t.operation = FormulaOperation.ClosingParenthesis;
                            t.Value = 41;
                            break;
                        }
                    case 42:
                        {
                            t.operation = FormulaOperation.Multi;
                            t.Value = 42;
                            break;
                        }
                    case 43:
                        {
                            t.operation = FormulaOperation.Plus;
                            t.Value = 43;
                            break;
                        }
                    case 45:
                        {
                            t.operation = FormulaOperation.Minus;
                            t.Value = 45;
                            break;
                        }
                    case 47:
                        {
                            t.operation = FormulaOperation.Div;
                            t.Value = 47;
                            break;
                        }
                }
                if (t.Value != null && t.operation != FormulaOperation.Const) tokens.Add(t);
                i++;
            }
            return tokens;
        }
        private MathOperation GetFormula(List<Token> inputList)
        {
            //MathOperation opOut;
            Stack<Token> OpStack = new Stack<Token>();
            Stack<MathOperation> NumStack = new Stack<MathOperation>();

            for (int i = 0; i < inputList.Count; i++)
            {
                switch (inputList[i].operation)
                {
                    case FormulaOperation.Varible:
                        Varibles.Add((string)inputList[i].Value, new СalculationFormula( FormulaOperation.Varible);
                        NumStack.Push(new MathOperation(Varibles[(string)inputList[i].Value], FormulaOperation.Varible));
                        break;
                    case FormulaOperation.Const:
                        NumStack.Push(new MathOperation((float)inputList[i].Value, FormulaOperation.Const));
                        break;
                    case FormulaOperation.OpeningParenthesis:
                        OpStack.Push(inputList[i]);
                        break;
                    case FormulaOperation.ClosingParenthesis:
                        while (OpStack.Peek().operation != FormulaOperation.OpeningParenthesis)
                        {
                            Token t = OpStack.Pop();
                            MathOperation op2 = NumStack.Pop();
                            MathOperation op1 = NumStack.Pop();
                            NumStack.Push(new MathOperation(op1, op2, t.operation));
                        }
                        OpStack.Pop();//Выкинули скобку
                        break;
                    case FormulaOperation.Div:
                    case FormulaOperation.Minus:
                    case FormulaOperation.Plus:
                    case FormulaOperation.Multi:
                        if (Priority(OpStack.Peek().operation) < Priority(inputList[i].operation))
                        {
                            OpStack.Push(inputList[i]);
                        }
                        else
                        {
                            Token t = OpStack.Pop();
                            OpStack.Push(inputList[i]);
                            MathOperation op2 = NumStack.Pop();
                            MathOperation op1 = NumStack.Pop();
                            NumStack.Push(new MathOperation(op1, op2, t.operation));
                        }
                        break;
                }
            }


            return NumStack.Peek();
        }
        private int Priority(FormulaOperation op)
        {
            int OUT = 0;
            switch (op)
            {
                case FormulaOperation.OpeningParenthesis:
                    OUT = 1;
                    break;
                case FormulaOperation.ClosingParenthesis:
                    OUT = 1;
                    break;
                case FormulaOperation.Plus:
                    OUT = 4;
                    break;
                case FormulaOperation.Minus:
                    OUT = 4;
                    break;
                case FormulaOperation.Div:
                    OUT = 6;
                    break;
                case FormulaOperation.Multi:
                    OUT = 6;
                    break;
            }
            return OUT;
        }
        private class Token
        {
            public FormulaOperation operation { get; set; }
            public object Value { get; set; }
        }
        private class MathOperation
        {
            object Value;
            object Value2;
            FormulaOperation operation;
            public MathOperation(СalculationFormula a, FormulaOperation operation)
            {
                Value = a;
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
                            return ((СalculationFormula)Value).Calc();
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
        private enum FormulaOperation
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


}