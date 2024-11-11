using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InfixPrefixPostfixConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPostfix_Click(object sender, EventArgs e)
        {
            string infix = txtInfix.Text;
            string postfix = InfixToPostfix(infix);
            lblPostfix.Text = "Postfix: " + postfix;
        }

        private void btnPrefix_Click(object sender, EventArgs e)
        {
            string infix = txtInfix.Text;
            string prefix = InfixToPrefix(infix);
            lblPrefix.Text = "Prefix: " + prefix;
        }

        // Infix ifadeyi Postfix ifadeye dönüştürme fonksiyonu
        private string InfixToPostfix(string infix)
        {
            Stack<char> stack = new Stack<char>();
            string postfix = "";
            foreach (char c in infix)
            {
                if (char.IsLetterOrDigit(c))
                {
                    postfix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }
            return postfix;
        }

        // Infix ifadeyi Prefix ifadeye dönüştürme fonksiyonu
        private string InfixToPrefix(string infix)
        {
            Stack<char> stack = new Stack<char>();
            string prefix = "";
            for (int i = infix.Length - 1; i >= 0; i--)
            {
                char c = infix[i];
                if (char.IsLetterOrDigit(c))
                {
                    prefix = c + prefix;
                }
                else if (c == ')')
                {
                    stack.Push(c);
                }
                else if (c == '(')
                {
                    while (stack.Count > 0 && stack.Peek() != ')')
                    {
                        prefix = stack.Pop() + prefix;
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Precedence(c) < Precedence(stack.Peek()))
                    {
                        prefix = stack.Pop() + prefix;
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count > 0)
            {
                prefix = stack.Pop() + prefix;
            }
            return prefix;
        }

        // Operatör önceliklerini belirleme fonksiyonu
        private int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }
    }
}

