namespace Calculator
{
    public class Calculator
    {
        public double AddNumbers(double x, double y) {
            return x + y;
        }

        public double SubtractionNumbers(double x, double y) {
            return x - y; 
        }

        public double MultiplicationNumbers(double x, double y) {
            return x * y;
        }

        public double DivisionNumbers(double x, double y) {

            if (y == 0) {
                throw new ArgumentException("Nie można dzielić przez zero");
            }
            return x / y;
        }
    }
}