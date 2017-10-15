using System;
using System.Collections.Generic;
using System.Text;

namespace MouseHeart
{
    internal class СalculationFormula
    {
        List<Coefficient> Coefficients;

        internal float Calculation()
        {
            throw new NotImplementedException();
        }
        public bool TryParse(string ParsedString)
        {
            List<Token> r = LexicAnalysis(ParsedString);


           string[] s =  ParsedString.Split(new char[] { '(' },StringSplitOptions.RemoveEmptyEntries);
            return true;
        }
        public List<Token> LexicAnalysis(string inputString)
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
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при обработке  числа");
                    }
                }

                //Обрабатываем буквы
                buff.Clear();
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

        public List<MathOperation> GetFormula(List<Token> inputList)
        {
            List<MathOperation> operations = new List<MathOperation>();
            Stack<Token> OpStack = new Stack<Token>();
            Stack<Token> NumStack = new Stack<Token>();

            for (int i = 0; i < inputList.Count; i++)
            {




            }

            return operations;
        }
   
        private int Priority(FormulaOperation op)
        {
            int OUT = 0;
            switch (op)
            {
                case FormulaOperation.OpeningParenthesis:
                    OUT = 6;
                    break;
                case FormulaOperation.ClosingParenthesis:
                    OUT = 6;
                    break;
                case FormulaOperation.Plus:
                    OUT = 2;
                    break;
                case FormulaOperation.Minus:
                    OUT = 2;
                    break;
                case FormulaOperation.Div:
                    OUT = 4;
                    break;
                case FormulaOperation.Multi:
                    OUT = 4;
                    break;
            }
            return OUT;
        }
        public class Token
        {
           public FormulaOperation operation { get; set; }
           public  object Value { get; set; }
        }
        
        public class MathOperation
        {
            Coefficient a;
            FormulaOperation operation;
            public MathOperation(ref Coefficient a,ref Coefficient b, FormulaOperation operation)
            {
                this.a = a;
                this.b = b;
                this.operation = operation;
            }
            public float Calc()
            {

            }
        }
        public interface Calculation
        {
            float Calc();
        }
    }

    public enum FormulaOperation
    {
        Const ,
        Varible ,
        OpeningParenthesis,
        ClosingParenthesis ,
        Plus ,
        Minus ,
        Div ,
        Multi
    }
}