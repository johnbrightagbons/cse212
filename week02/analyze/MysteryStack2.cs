public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+")
                {
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

// The Run method:
// Accepts a string of space-separated tokens (numbers and operators).
// Uses a stack to process the expression.
// When it sees a number, it pushes it onto the stack.
// When it sees an operator (+, -, *, /), it:
// Pops two operands from the stack.
// Applies the operation.
// Pushes the result back to the stack.

// Example: "5 3 7 + *"
// 1. Push 5
// 2. Push 3    
// 3. Push 7
// 4. Pop 7 and 3, add them (10), push 10
// 5. Pop 10 and 5, multiply them (50), push 50
// 6. End with 50 on the stack
// 7. Return 50
