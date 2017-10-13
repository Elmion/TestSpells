using System;
using System.Collections.Generic;
namespace MouseHeart
{
    internal class СalculationFormula
    {
        List<Сoefficient> Coefficients;

        internal float Calculation()
        {
            throw new NotImplementedException();
        }
        public bool TryParse(string ParsedString,out FormulaTreeNode ftn)
        {
            ftn = new FormulaTreeNode();
            List<Deep> r =  SplitForLogicalBlock(ParsedString);
           string[] s =  ParsedString.Split(new char[] { '(' },StringSplitOptions.RemoveEmptyEntries);
            return true;
        }

        List<Deep> SplitForLogicalBlock(string input)
        {
            List<Deep> d = new List<Deep>();
            int CuplesDeepCount = 0;
            int maxDeep = 0;
            Stack<int> indexStartCulpe = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexStartCulpe.Push(i);
                    CuplesDeepCount++;
                }
                if (input[i] == ')')
                {
                    CuplesDeepCount--;

                    Deep deep = new Deep() { id = Guid.NewGuid().ToString().Replace("-", string.Empty),
                                             Depper = CuplesDeepCount,
                                             ss = input.Substring(indexStartCulpe.Peek(), i - indexStartCulpe.Pop() + 1) };
                    d.Add(deep);
                    if(deep.Depper > maxDeep) maxDeep = x.Depper;
                }
            }
          
            for (int i = 0; i < maxDeep; i++)
            {
               


            }
            return d;
        }
        class Deep
        {
           public  string id;
           public  int Depper;
           public  string ss;
        }
    }
    internal class FormulaTreeNode
    {
        FormulaOperation Operation;
        Сoefficient Value;
        FormulaTreeNode left;
        FormulaTreeNode right;

        public FormulaTreeNode()
        {
            Operation = FormulaOperation.None;
            Value = null;
            left = null;
            right = null;
        }

        public float GetValue()
        {
            if (left == null || right == null) return Value.Value;
            switch (Operation)
            {
                case FormulaOperation.Plus:
                    return  left.GetValue() + right.GetValue();
                case FormulaOperation.Minus:
                    return left.GetValue() - right.GetValue();
                case FormulaOperation.Div:
                    return left.GetValue() / right.GetValue();
                case FormulaOperation.Multi:
                    return left.GetValue() * right.GetValue();
            }
            return 0;
        }
        public void  SetLeft(Сoefficient co)
        {
            left = new FormulaTreeNode();
            left.Value = co;
        }
        public void SetLeft(FormulaOperation op)
        {
            left = new FormulaTreeNode();
            left.Operation = op;
        }
        public void SetRight(Сoefficient co)
        {
            right = new FormulaTreeNode();
            right.Value = co;
        }
        public void SetRight(FormulaOperation op)
        {
            right = new FormulaTreeNode();
            right.Operation = op;
        }
        public bool ChangeСoefficient(string name, Сoefficient co)
        {
            bool ok = false;
            if (Value.Name == name)
            {
                Value = co;
                ok = true;
            }
            else
            {

                if (left != null)
                {
                    ok = left.ChangeСoefficient(name, co);
                }
                if ( !ok && right != null)
                {
                    ok = left.ChangeСoefficient(name, co);
                }
                
            }
            return ok;
        }
        public bool ChangeСoefficient(Guid id, Сoefficient co)
        {
            bool ok = false;
            if (Value.id == id)
            {
                Value = co;
                ok = true;
            }
            else
            {
                if (left != null)
                {
                    ok = left.ChangeСoefficient(id, co);
                }
                if (!ok && right != null)
                {
                    ok = left.ChangeСoefficient(id, co);
                }
            }
            return ok;
        }
    }
    public enum FormulaOperation : sbyte
    {
        None = 0,
        Plus = 1,
        Minus = 2,
        Div = 3,
        Multi = 4
    }
}