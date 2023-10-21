using Microsoft.AspNetCore.Mvc;

public class CalcService
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }
    public double Multiplication(double a, double b)
    {
        return a * b;
    }
    public double Division(double a, double b)
    {
        return a / b;
    }
}

public class CalculatorController
{
    private CalcService calcService;

    public CalculatorController(CalcService calcService)
    {
        this.calcService = calcService;
    }

    public double Add(double a, double b)
    {
        return calcService.Add(a, b);
    }

    public double Subtract(double a, double b)
    {
        return calcService.Subtract(a, b);
    }
    public double Multiplication(double a, double b)
    {
        return calcService.Multiplication(a, b);
    }
    public double Division(double a, double b)
    {
        return calcService.Division(a, b);
    }
}