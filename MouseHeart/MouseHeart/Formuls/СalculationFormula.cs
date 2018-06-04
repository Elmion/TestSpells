using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MouseHeart
{
    public class СalculationFormula
    {
        public string Name { get; set; }
        public float this[string name]
        {
            get
            {
                return Varibles[name];
            }
            set
            {
                 Varibles[name] = value;
            }
        }
        private Dictionary<string, float> Varibles = new Dictionary<string, float>();
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
                        string name = (string)inputList[i].Value;
                        if (!Varibles.ContainsKey(name)) Varibles.Add(name, 0);
                        NumStack.Push(new MathOperation(name,this, FormulaOperation.Varible));
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
    }

    
    public class Varible
    {
        public static Dictionary<string, Varible> ListVaribles = new Dictionary<string, Varible>();

        public float Value { get; private set; }

        public static void CreateXMLMap()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            foreach (string item in ListVaribles.Keys)
            {
                XmlNode varibleNode = doc.CreateElement("varible");
                XmlAttribute attribute = doc.CreateAttribute("NameVarible");
                attribute.Value = item.ToString();
                varibleNode.InnerText = ListVaribles[item].Value.ToString();
                varibleNode.Attributes.Append(attribute);
                root.AppendChild(varibleNode);
            }
            doc.AppendChild(root);
            doc.Save("VaribleSettings.xml");
        }
        public static void LoadVaribles()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("VaribleSettings.xml");
            XmlElement root = doc.GetElementById("root");
            XmlNodeList listVaribles = doc.GetElementsByTagName("varible");
            for (int i = 0; i < listVaribles.Count; i++)
            {
                string temp = listVaribles.Item(i).Attributes.Item(0).Value;
                ListVaribles[temp].Value = float.Parse(listVaribles.Item(i).InnerText);
            }
        }

    }


}