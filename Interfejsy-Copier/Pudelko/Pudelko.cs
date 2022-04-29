using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3_pudelko
{ 
    public class Pudelko : IEquatable<Pudelko> , IEnumerable<decimal>
    {
        // przechowuje w metrach
        private decimal a;
        private decimal b;
        private decimal c;
        public UnitOfMeasure UnitOfMeasure { get; init; }
        private decimal[] _parameters;

        public decimal A
        {
            get { return Math.Round(a, 3); }
            set { a = value; }
        }

        public decimal B
        {
            get { return Math.Round(b, 3); }
            set { b = value; }
        }

        public decimal C
        {
            get { return Math.Round(c, 3); }
            set { c = value; }
        }

        public decimal Objetosc
        {
            get {
                return Math.Round(a * b * c, 9);
            }
        }
        public decimal Pole
        {
            get {
                return Math.Round(a * b * 2 + a * c * 2 + b * c * 2, 6);
            }
        }

        public Pudelko(decimal a = 0.1m, decimal b = 0.1m, decimal c = 0.1m, UnitOfMeasure unitOfMeasure = UnitOfMeasure.Meter)
        {
            if (a < 0 || b < 0 || c < 0 || a > 10 || b > 10 || c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            UnitOfMeasure = unitOfMeasure;
            A = Converter.ConvertMeters(a, UnitOfMeasure);
            B = Converter.ConvertMeters(b, UnitOfMeasure);
            C = Converter.ConvertMeters(c, UnitOfMeasure);
            _parameters = new[] { A, B, C };
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Pudelko)) return false;
            var box = (Pudelko)obj;
            var parametersCompared = new[] { box.A, box.B, box.C };
            return _parameters.All(parametersCompared.Contains) && _parameters.Length == parametersCompared.Length;
        }

        public bool Equals(Pudelko? box)
        {
            return Equals((object?)box);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C);
        }

        public static bool operator ==(Pudelko? leftBox, Pudelko? rightBox)
        {
            if (leftBox is null && rightBox is null)
            {
                return true;
            }
            if (leftBox is null && rightBox is not null)
            {
                return false;
            }
            if (leftBox is not null && rightBox is null)
            {
                return false;
            }
            return leftBox.Equals(rightBox);
        }

        public static Pudelko operator +(Pudelko leftBox, Pudelko rightBox)
        {
            var leftBoxParameters = new[] { leftBox.A, leftBox.B, leftBox.C }.OrderByDescending(a => a).ToArray();
            var rightBoxParameters = new[] { rightBox.A, rightBox.B, rightBox.C }.OrderByDescending(a => a).ToArray();
            var a = new[] { leftBoxParameters[0], rightBoxParameters[0] }.Max();
            var b = new[] { leftBoxParameters[1], rightBoxParameters[1] }.Max();
            var c = leftBoxParameters[2] + rightBoxParameters[2];
            return new Pudelko(a, b, c);
        }

        public decimal this[int index] => _parameters[index];


        public override string ToString()
        {
            return $"{A} m × {B} m × {C} m";
        }

        public string ToString(string format)
        {
            if(format == "cm")
            {
                return(
                $"{Math.Round(Converter.ConvertCentimeters(A), 1)} cm × " +
                $"{Math.Round(Converter.ConvertCentimeters(B), 1)} cm × " +
                $"{Math.Round(Converter.ConvertCentimeters(C), 1)} cm"
                );
            }
            else if(format == "mm")
            {
                return (
                $"{Math.Round(Converter.ConvertMilimeters(A), 0)} cm × " +
                $"{Math.Round(Converter.ConvertMilimeters(B), 0)} cm × " +
                $"{Math.Round(Converter.ConvertMilimeters(C), 0)} cm"
                );
            }
            else if(format == "m")
            {
                return ToString();
            }
            else
            {
                throw new FormatException();
            }
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var parameter in _parameters)
            {
                yield return parameter;
            }
        }
    }
}