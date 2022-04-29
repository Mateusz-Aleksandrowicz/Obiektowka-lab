
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_pudelko
{
	public static class Converter
	{
		public static decimal ConvertMeters(decimal value, UnitOfMeasure unitOfMeasure = UnitOfMeasure.Meter)
        {
            if (unitOfMeasure == UnitOfMeasure.Unknown)
			{
				throw new ArgumentException("Unit of measure cannot be unknown");
			}
			else if (unitOfMeasure == UnitOfMeasure.Milimeter)
			{
				return value / 1000;
			}
			else if (unitOfMeasure == UnitOfMeasure.Centimeter)
			{
				return value / 100;
			}
			else
			{
				return value;
			}
        }
        public static decimal ConvertCentimeters(decimal value, UnitOfMeasure unitOfMeasure = UnitOfMeasure.Meter)
		{
			if (unitOfMeasure == UnitOfMeasure.Unknown)
			{
				throw new ArgumentException("Unit of measure cannot be unknown");
			}
			else if (unitOfMeasure == UnitOfMeasure.Milimeter)
			{
				return value / 10;
			}
			else if (unitOfMeasure == UnitOfMeasure.Meter)
			{
				return value * 100;
			}
			else
			{
				return value;
			}
		}
		public static decimal ConvertMilimeters(decimal value, UnitOfMeasure unitOfMeasure = UnitOfMeasure.Meter)
		{
			if (unitOfMeasure == UnitOfMeasure.Unknown)
			{
				throw new ArgumentException("Unit of measure cannot be unknown");
			}
			else if (unitOfMeasure == UnitOfMeasure.Centimeter)
			{
				return value * 10;
			}
			else if (unitOfMeasure == UnitOfMeasure.Meter)
			{
				return value * 1000;
			}
			else
			{
				return value;
			}
		}
	}
}